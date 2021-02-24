namespace IO.Controllers
{
    using IO.Model;
    using IO.Services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System.Collections.Generic;

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

        [HttpPost]
        [Route("/users/addUser")]
        public void Add(User val)
        {
            _userService.Create(val);
        }
        [HttpDelete]
        [Route("/users/delteUser")]
        public void Delete(string id)
        {
            _userService.Remove(id);
        }


    }


}
