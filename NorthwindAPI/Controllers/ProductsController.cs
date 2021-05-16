using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tarea1DWB_DBFirst_EFCore.Services;
using Tarea1DWB_DBFirst_EFCore.DataAccess;
using DBFirst.Models;

namespace NorthwindAPI.Controllers
{
    /* https://api/Products/ */
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private ProductSC productService = new ProductSC();

        // GET: api/Products
        [HttpGet(Name ="GetProducts")]
        public IActionResult Get()
        {
            var products = productService.GetAllProducts().ToList();
            return Ok(products);
        }

        // GET: api/Products/5
        [HttpGet("{id}", Name = "GetProductById")]
        public IActionResult Get(int id)
        {
            var product = productService.GetProductByID(id).FirstOrDefault();
            return Ok(product);
        }

        // POST: api/Products
        [HttpPost(Name = "NewCommodity")]
        public IActionResult Post([FromBody] CommodityModel newCommodity)
        {
            productService.AddProduct(newCommodity);
            return Ok();
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return Ok();
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}", Name = "DeleteProduct")]
        public IActionResult Delete(int id)
        {
            productService.DeleteProductById(id);
            return Ok();
        }
    }
}
