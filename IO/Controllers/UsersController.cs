using IO.Model;
using IO.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IO.Controllers
{
    [ApiController]
    [Route("/users")]
    public class UsersController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<UsersController> _logger;

        private readonly UserService _userService;
        
        public UsersController(ILogger<UsersController> logger, UserService userService)
        {
            _logger = logger;

            _userService = userService;
        }



        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userService.Get();
        }
    }


}
