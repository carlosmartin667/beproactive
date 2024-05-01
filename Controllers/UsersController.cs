using ApiDevBP.Models;
using ApiDevBP.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiDevBP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserService userService, ILogger<UsersController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> SaveUser(UserModel user)
        {
            try
            {
                await _userService.SaveUser(user);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al guardar usuario.");
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpGet("ByLastName/{lastName}")]
        public async Task<IActionResult> GetUsersByLastName(string lastName)
        {
            try
            {
                var users = await _userService.GetUsersByLastName(lastName);
                if (users != null && users.Count > 0)
                {
                    return Ok(users);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener usuarios por apellido.");
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _userService.GetAllUsers();
                if (users != null && users.Count > 0)
                {
                    return Ok(users);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todos los usuarios.");
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpGet("GetUsersID")]
        public async Task<IActionResult> GetUsersID()
        {
            try
            {
                var users = await _userService.GetAllUsersId();
                if (users != null && users.Count > 0)
                {
                    return Ok(users);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todos los usuarios.");
                return StatusCode(500, "Error interno del servidor.");
            }
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsersByID(int id)
        {
            try
            {
                var users = await _userService.GetUserById(id);
                if (users != null)
                {
                    return Ok(users);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todos los usuarios.");
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserModel user)
        {
            try
            {
                await _userService.UpdateUser(id, user);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar usuario con ID {UserId}.", id);
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                await _userService.DeleteUser(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar usuario con ID {UserId}.", id);
                return StatusCode(500, "Error interno del servidor.");
            }
        }
    }
}
