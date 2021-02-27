namespace IO.Controllers
{
    using IO.Model;
    using IO.Model.Users;
    using IO.Services;
    using IO.Settings;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using System;
    using System.Collections.Generic;

    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("/users")]
        public IActionResult Register(RegistrationUser registrationUser)
        {
            try
            {
                // save 
                _userService.Create(registrationUser);
                return Ok();
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
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
            return _userService.GetById(id);
        }

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
