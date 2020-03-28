using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using eCommerceAPI.Interfaces;
using eCommerceAPI.Repositories;
using eCommerceAPI.Services;
using eCommerceAPI.Utility;
using farmersAPi.Interfaces;
using farmersAPi.Models;
using farmersAPi.Repositories;
using farmersAPi.Services;
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

using ProductService = eCommerceAPI.Services.ProductService;

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
            var emailSection = Configuration.GetSection("EmailSender");
            services.Configure<EmailSender>(emailSection);
            var emailSettingSection = emailSection.Get<EmailSender>();

           
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
            services.AddSingleton<IMailService, MailService>();   
                                              
                                          
            services.AddSwaggerGen(c=>c.SwaggerDoc("v1", new OpenApiInfo { Title="eCommerceAPI", Version="v1"}));
            services.AddDbContext<APIContext>(options => options.UseSqlServer(Configuration.GetConnectionString("APIContext")));
            services.AddScoped<CategoryRepository>();
            services.AddScoped<ProductRepository>();
            services.AddScoped<OrdersRepository>();
            services.AddScoped<OrderDetailsRepository>();
            services.AddHttpContextAccessor();

            services.AddScoped<CategoryService>();
            services.AddScoped<ProductService>();
            services.AddScoped<OrdersService>();
            services.AddScoped<OrderDetailsService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

           
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
                );
            app.UseCors(x =>
                  x.AllowAnyOrigin()
                 .AllowAnyMethod()
               .AllowAnyHeader()
             );
            app.UseAuthorization();

            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "eCommerceAPI"));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }

    
    

       
    }






