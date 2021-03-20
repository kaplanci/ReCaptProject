using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentsController : ControllerBase
    {
        IRentService _rentService;

        public RentsController(IRentService rentService)
        {
            _rentService = rentService;
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int RentId)
        {
            var result = _rentService.GetById(RentId);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result);
        }

        [HttpGet("getrentdetails")]
        public IActionResult GetCarDetails(Rent rent)
        {
            var result = _rentService.GetRentDetails();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }








        [HttpPost("add")]
        public IActionResult Add(Rent rent)
        {
            var result = _rentService.Add(rent);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Rent rent)
        {
            var result = _rentService.Delete(rent);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Rent rent)
        {
            var result = _rentService.Update(rent);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getall")]

        public IActionResult Get(Rent rent)
        {
            var result = _rentService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }
    }
}
