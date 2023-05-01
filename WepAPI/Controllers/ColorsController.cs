using Business.Abstract;
using Business.Constants;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _colorService.GetAll();
            if (result.Success)
            {

                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id) 
        {
            var result = _colorService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("Add")]
        public IActionResult Add(Color color)
        {
            _colorService.Add(color);
            return Ok($"{color.ColorName} rengi eklendi.");
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Color color)
        {
            _colorService.Delete(color);
            return Ok();
        }
        [HttpPost("Update")]
        public IActionResult Update(Color color)
        {
            _colorService.Update(color);
            return Ok("Renk Güncellendi");
        }
    }
}
