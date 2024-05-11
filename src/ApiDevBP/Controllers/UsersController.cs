using ApiDevBP.Business.Contract;
using ApiDevBP.Business.Implementation;
using ApiDevBP.Entities;
using ApiDevBP.Model.InputDTO;
using ApiDevBP.Models;
using Microsoft.AspNetCore.Mvc;
using SQLite;
using System.Reflection;

namespace ApiDevBP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {   
        private readonly ILogger<UsersController> _logger;

        private readonly IUserBusiness _userBusiness;

        public UsersController(IUserBusiness userBusiness, ILogger<UsersController> logger)
        {
            _logger = logger;
            _userBusiness = userBusiness;
        }

        [HttpPost]
        public async Task<IActionResult> SaveUser(UserModelInputDTO user)
        {
            return Ok(await _userBusiness.SaveUser(user));
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = _userBusiness.GetUsers();
            if (users != null)
            {
                return Ok(users);
            }
            return NotFound();
        }

    }
}
