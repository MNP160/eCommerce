using AutoMapper;
using farmersAPi.DTOs;
using farmersAPi.Interfaces;
using farmersAPi.Models;
using farmersAPi.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace farmersAPi.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService userService;
        private readonly Secret _secret;
        private IMapper mapper;
        private readonly APIContext context;
        public UserController(IUserService service, IOptions<Secret> secret, IMapper map, APIContext _con)
        {
            userService = service;
            _secret = secret.Value;
            mapper = map;
            context = _con;
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public IActionResult Authenticate([FromBody] AuthenticateModel model)
        {
            // var user = userService.Authenticate(model.Email, model.Password);
            var user = context.Users.FirstOrDefault(x => x.Email == model.Email);

            if (user == null)
            {
                return BadRequest("User does not exist");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secret.secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }
                    ),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                IssuedAt = DateTime.UtcNow,
                Issuer = "usersAPI",
                Audience = "everybody"

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);



            return Ok(new
            {
                Id = user.Id,
                Username = user.Email,
                Token = tokenString,


            });
        }


        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]RegisterModel model)
        {
            var user = mapper.Map<Users>(model);
            try
            {
                userService.Create(user, model.Password);
                var registeredUser = context.Users.FirstOrDefault(x => x.Email == model.Email);
                
                var mappedUser = mapper.Map<UserDto>(registeredUser);
                return Ok(mappedUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }


        }

        [HttpGet("")]

        public IActionResult GetAll()
        {
            var users = userService.GetAll();
            var dtos = mapper.Map<IList<UserDto>>(users);

            return Ok(dtos);
        }

        [HttpGet("{id}")]

        public IActionResult GetById([FromRoute]int id)        //check when sending request
        {
            var user = userService.GetById(id);
            var dto = mapper.Map<UserDto>(user);
            

            return Ok(dto);
        }

    }
}


