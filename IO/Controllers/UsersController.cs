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
    [Route("/users")]
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
        [Route("/users/getUsers")]
        public IEnumerable<User> Get()
        {
            return _userService.Get();
        }

        [HttpGet]
        [Route("/users/getUser/{id}")]
        public User Get(string id)
        {
            return _userService.Get(id);
        }

        [HttpPost]
        [Route("/users/addUser")]
        public void Add(User val)
        {
            _userService.Create(val);
        }

        [HttpPost]
        [Route("/users/register")]
        public string Register(RegisterationData val)
        {
                return _userService.Register(val);
        }

        [HttpDelete]
        [Route("/users/deleteUser")]
        public void Delete(string id)
        {
            _userService.Remove(id);
        }

        [HttpPut]
        [Route("/users/updateUser")]
        public void Update(User val)
        {
            _userService.Update(val.Id, val);
        }

    }


}
