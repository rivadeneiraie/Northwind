using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Northwind.UnitOfWork;
using Northwind.Models;

namespace Northwind.WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class SupplierController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public SupplierController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_unitOfWork.Supplier.GetById(id));
        }


        [HttpGet]
        [Route("GetPaginatedSupplier/{page:int}/{rows:int}")]
        public IActionResult GetPaginatedCustomer(int page, int rows)
        {
            return Ok(_unitOfWork.Supplier.SupplierPageList(page, rows));
        }

        [HttpPost]
        public IActionResult Post([FromBody]Supplier supplier)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(_unitOfWork.Supplier.Insert(supplier));
        }

        [HttpPut]
        public IActionResult Put([FromBody]Supplier supplier)
        {
            if (ModelState.IsValid && _unitOfWork.Supplier.Update(supplier))
            {
                return Ok(new { Message = "The customer is updatedes." });
            }
            
            return BadRequest();

        }

        [HttpDelete]
        public IActionResult Delete([FromBody]Supplier supplier)
        {
            if (supplier.Id > 0)
                return Ok(_unitOfWork.Supplier.Delete(supplier));

            return BadRequest();
        }
    }

}