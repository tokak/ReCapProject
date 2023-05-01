using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _customerService.GetAll();
            if (result.Success)
            {

                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _customerService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("Add")]
        public IActionResult Add(Customer customer)
        {
            _customerService.Add(customer);
            return Ok($"{customer.CompanyName} kampanya eklendi.");
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Customer customer)
        {
            _customerService.Delete(customer);
            return Ok();
        }
        [HttpPost("Update")]
        public IActionResult Update(Customer customer)
        {
            _customerService.Update(customer);
            return Ok("Campanya Güncellendi");
        }
    }
}
