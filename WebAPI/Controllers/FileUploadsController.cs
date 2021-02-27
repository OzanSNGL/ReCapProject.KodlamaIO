using Business.Abstract;
using Business.Constants;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadsController : ControllerBase
    {
        public static IWebHostEnvironment _webHostEnvironment;
        ICarImageService _carImageService;

        public FileUploadsController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpPost("AddImg")]
        public IActionResult Add([FromForm(Name = ("Image"))] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImageService.Add(carImage, file);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("DeleteImg")]
        public IActionResult Delete(CarImage carImage)
        {
            var result = _carImageService.Delete(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("UpdateImg")]
        public IActionResult Update([FromForm(Name = ("Image"))] IFormFile file, [FromForm(Name = ("carId"))] int carId)
        {
            var carImage = _carImageService.Get(carId).Data;
            var result = _carImageService.Update(carImage, file);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetImgById")]
        public IActionResult GetImgById(int id)
        {
            var result = _carImageService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAllCarImg")]
        public IActionResult GetAll(int carId)
        {
            var result = _carImageService.GetAll(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
