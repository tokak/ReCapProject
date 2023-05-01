using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();
            if (result.Success)
            {

                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _userService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("Add")]
        public IActionResult Add(User user)
        {
            _userService.Add(user);
            return Ok($"{user.FirstName} ismi eklendi.");
        }

        [HttpPost("Delete")]
        public IActionResult Delete(User user)
        {
            _userService.Delete(user);
            return Ok();
        }
        [HttpPost("Update")]
        public IActionResult Update(User user)
        {
            _userService.Update(user);
            return Ok("Kullanıcı Güncellendi");
        }
    }
}
