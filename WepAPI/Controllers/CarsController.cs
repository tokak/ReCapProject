using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            if (result.Success)
            {

                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getallbybrandid")]
        public IActionResult GetAllByBrandId(int id)
        {
            var result = _carService.GetAllByBrandId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getallbycolorid")]
        public IActionResult GetAllByColorId(int id)
        {
            var result = _carService.GetAllByColorId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("Add")]
        public IActionResult Add(Car car)
        {
            _carService.CarAdded(car);
            return Ok($"{car.CarDescription} açıklama eklendi.");
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Car car)
        {
            _carService.Delete(car);
            return Ok();
        }
        [HttpPost("Update")]
        public IActionResult Update(Car car)
        {
            _carService.Update(car);
            return Ok($"{car.CarDescription}  Güncellendi");
        }

        [HttpGet("getcardetails")]
        public IActionResult GetCarDetails()
        {
            var result = _carService.GetCarDetails();
            return Ok(result);
        }
        [HttpGet("getbyunitprice")]
        public IActionResult GetByUnitPrice(decimal min, decimal max)
        {
            var result = _carService.GetByUnitPrice(min,max);
            return Ok(result);
        }
    }
}
