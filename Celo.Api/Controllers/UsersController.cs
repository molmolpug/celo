using System;
using Celo.Domain.ViewModels;
using Celo.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Celo.Common.Constants;

namespace Celo.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserService userService,
            ILogger<UsersController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet("{id:guid}")]
        public User GetUser(Guid id)
        {
            return _userService.GetUser(id);
        }

        [HttpGet]
        public IEnumerable<User> GetUsers([FromQuery] string term, [FromQuery] int limit = SearchConstants.SearchLimit)
        {
            return _userService.GetUsers(term, limit);
        }

        [HttpPost]
        public IActionResult AddUsers([FromBody] User user)
        {
             _userService.AddUser(user);
            return Ok();
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateUsers(Guid id, [FromBody] User user)
        {
            _userService.UpdateUser(id, user);
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteUsers(Guid id)
        { 
            _userService.DeleteUser(id);
            return Ok();
        }
    }
}
