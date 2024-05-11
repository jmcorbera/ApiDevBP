using ApiDevBP.Business.Contract;
using ApiDevBP.Business.Implementation;
using ApiDevBP.Model.InputDTO;
using Microsoft.AspNetCore.Mvc;
using SQLite;
using System.Reflection;

namespace ApiDevBP.Controllers
{
    /// <summary>
    /// User endpoints
    /// </summary>
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

        /// <summary>
        /// Method used to add new user
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST 
        ///     {
        ///        "name": "name",
        ///        "lastname": "lastname"
        ///     }
        ///
        /// </remarks>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <response code="200">When the response is Success</response>
        /// <response code="400">When the method has Bad Request</response>
        [HttpPost]
        [Route("SaveUser")]
        public async Task<IActionResult> SaveUser([FromBody] UserModelInputDTO user)
        {
            try
            {
                return Ok(await _userBusiness.SaveUser(user));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException?.Message ?? ex.Message);
                return BadRequest();
            }
        }

        /// <summary>
        /// Method used to get all users
        /// </summary>
        /// <returns></returns>
        /// <response code="200">When the response is Success</response>
        /// <response code="400">When the method has Bad Request </response>
        /// <response code="404">Users not found</response>
        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _userBusiness.GetUsers();
                if (users != null)
                {
                    return Ok(users);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        /// <summary>
        /// Method used to get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">When the response is Success</response>
        /// <response code="400">When the method has Bad Request </response>
        /// <response code="404">User not found</response>
        [HttpGet]
        [Route("GetUserById")]
        public async Task<IActionResult> GetUserById([FromQuery] int id)
        {
            try
            {
                var user = await _userBusiness.GetUserById(id);
                if (user == null)
                    return NotFound();

                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        /// <summary>
        /// Method used to update user
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT 
        ///     {
        ///        "id": 0,
        ///        "name": "name",
        ///        "lastname": "lastname"
        ///     }
        ///
        /// </remarks>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <response code="200">When the response is Success</response>
        /// <response code="400">When the method has Bad Request </response>
        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UserModelInputDTO user)
        {
            try
            {
                return Ok(await _userBusiness.UpdateUser(user));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException?.Message ?? ex.Message);
                return BadRequest();
            }
        }

        /// <summary>
        /// Method used to delete user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">When the response is Success</response>
        /// <response code="400">When the method has Bad Request </response>
        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<IActionResult> DeleteUser([FromQuery] int id)
        {
            try
            {
                await _userBusiness.DeleteUser(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException?.Message ?? ex.Message);
                return BadRequest();
            }
        }

    }
}
