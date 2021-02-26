namespace IO.Controllers
{
    using IO.Model;
    using IO.Model.Users;
    using IO.Services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System.Collections.Generic;
    using System.Net.Http;

    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserService _userService;
        public UsersController(ILogger<UsersController> logger, UserService userService)
        {
            _logger = logger;

            _userService = userService;
        }

        [HttpGet]
        [Route("/users")]
        public IEnumerable<User> Get()
        {
            return _userService.Get();
        }

        [HttpGet]
        [Route("/users/{id}")]
        public User Get(string id)
        {
            return _userService.Get(id);
        }

        [HttpPost]
        [Route("/users")]
        public void Add(User val)
        {
            _userService.Create(val);
        }

        /*[HttpPost]
        [Route("/users")]
        public string Register(RegisterationData val)
        {
                return _userService.Register(val);
        }*/

        [HttpDelete]
        [Route("/users")]
        public void Delete(string id)
        {
            _userService.Remove(id);
        }

        [HttpPut]
        [Route("/users")]
        public void Update(User val)
        {
            _userService.Update(val.Id, val);
        }

    }
}
