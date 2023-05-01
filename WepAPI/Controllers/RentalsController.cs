using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _rentalService.GetAll();
            if (result.Success)
            {

                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _rentalService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("Add")]
        public IActionResult Add(Rental rental)
        {
            _rentalService.Add(rental);
            return Ok($"Araç kiralama eklendi.");
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Rental rental)
        {
            _rentalService.Delete(rental);
            return Ok();
        }
        [HttpPost("Update")]
        public IActionResult Update(Rental rental)
        {
            _rentalService.Update(rental);
            return Ok("Araç Kiralama Güncellendi");
        }
        [HttpGet("getcustomercarrentaldetails")]
        public IActionResult GetCustomerCarRentalDetails()
        {
            var result = _rentalService.GetCustomerCarRentalDetails();
            return Ok(result);
        }
    }
}
