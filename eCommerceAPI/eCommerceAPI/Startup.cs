using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using farmersAPi.Interfaces;
using farmersAPi.Models;
using farmersAPi.Repositories;
using farmersAPi.Servces;
using farmersAPi.Utility;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Stripe;

namespace farmersAPi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options=>options.SerializerSettings
            .ReferenceLoopHandling= Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddCors();
            var stripeSection = Configuration.GetSection("Stripe");
            services.Configure<StripeSandbox>(stripeSection);
            var stripeSecrets = stripeSection.Get<StripeSandbox>();
            System.Diagnostics.Debug.WriteLine("-----------------------------------------------");
            System.Diagnostics.Debug.WriteLine(stripeSecrets.ClientId);
            System.Diagnostics.Debug.WriteLine(stripeSecrets.ClientSecret);
            System.Diagnostics.Debug.WriteLine("-----------------------------------------------");
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<Secret>(appSettingsSection);
            var appSettings = appSettingsSection.Get<Secret>();
            var key = Encoding.ASCII.GetBytes(appSettings.secret);
            services.AddAuthentication(x => { 

                  x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }

            ).AddJwtBearer(x =>
            {
            x.Events = new JwtBearerEvents
            {
                OnTokenValidated = context =>
                {
                    var userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
                    var userId = int.Parse(context.Principal.Identity.Name);
                    System.Diagnostics.Debug.WriteLine(userId);
                    var user = userService.GetById(userId);
                    if (user == null)
                    {
                        context.Fail("Unauthorized");
                    }

                    return Task.CompletedTask;
                }
            };
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateAudience = true,
                ValidateIssuer = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ClockSkew = TimeSpan.Zero,
                ValidIssuer = "usersAPI",
                ValidAudience = "everybody"

            };
        });
            services.AddScoped<IUserService, UserService>();
            services.AddTransient<IImageHandler, ImageHandler>();
            services.AddTransient<IImageWriter, ImageWriter>();
                
                                              
                                          
            services.AddSwaggerGen(c=>c.SwaggerDoc("v1", new OpenApiInfo { Title="farmersAPI", Version="v1"}));
            services.AddDbContext<APIContext>(options => options.UseSqlServer(Configuration.GetConnectionString("APIContext")));
            services.AddScoped<CathegoryRepository>();
            services.AddScoped<ProductRepository>();
            services.AddScoped<ToxinsRepository>();
            services.AddScoped<UserToxinsRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           
            StripeConfiguration.ApiKey=Configuration.GetSection("Stripe")["ClientSecret"];
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseSwagger();
            app.UseDirectoryBrowser(new DirectoryBrowserOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images")),
                RequestPath = new PathString("/images")
            }
                ) ;

            app.UseAuthorization();
            app.UseCors(x => 
            x.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader()
               );
            app.UseSwaggerUI(c=>c.SwaggerEndpoint("/swagger/v1/swagger.json", "farmersAPI"));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
