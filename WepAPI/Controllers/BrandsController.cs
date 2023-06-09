﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _brandService.GetAll();
            if (result.Success)
            {

                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _brandService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("Add")]
        public IActionResult Add(Brand brand)
        {
            var result =_brandService.Add(brand);
            if (result.Success)
            {
                return Ok($"{brand.BrandName} marka eklendi.");
                
            }
            return BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Brand brand)
        {
            _brandService.Delete(brand);
            return Ok();
        }
        [HttpPost("Update")]
        public IActionResult Update(Brand brand)
        {
            _brandService.Update(brand);
            return Ok("Marka Güncellendi");
        }
    }
}
