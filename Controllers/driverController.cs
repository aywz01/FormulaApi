using FormulaApi.Core;
using FormulaApi.Data;
using FormulaApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace FormulaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class driverController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public driverController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task< IActionResult> Get()
        {
            return Ok(await _unitOfWork.Drivers.All());
        }
        [HttpGet]
        [Route(template:"GetById")]
        public async Task< IActionResult >Get(int id)
        {
            var driver = await _unitOfWork.Drivers.GetById(id);

            if (driver == null) return NotFound();
            return Ok(driver);
        }

        [HttpPost]
        [Route(template:"AddDriver")]
        public async Task<IActionResult >AddDriver(Driver driver)
        {
            await _unitOfWork.Drivers.Add(driver);
            await _unitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpDelete]
        [Route(template:"DeleteDriver")]

        public async Task<IActionResult> DeleteDriver(int id)
        {
            var driver = await _unitOfWork.Drivers.GetById(id);
            
            if (driver != null)
            {
                await _unitOfWork.Drivers.Delete(driver);
                await _unitOfWork.CompleteAsync();  
                return NoContent();
            }
            return NotFound();

        }

        [HttpPatch]
        [Route(template:"UpdateDriver")]
        public async Task<IActionResult >UpdateDriver(Driver driver)
        {
            var existDriver = await _unitOfWork.Drivers.GetById(driver.Id);
            if (existDriver == null) 
            {
                return NotFound();
            }
            await _unitOfWork.Drivers.Update(driver);
            await _unitOfWork.CompleteAsync();  

            return NoContent();
        }
    }
}
