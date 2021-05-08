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
        // GET: api/Products
        [HttpGet(Name ="GetProducts")]
        public List<Products> Get()
        {
            var products = new ProductSC().GetAllProducts().ToList();
            return products;
        }

        // GET: api/Products/5
        [HttpGet("{id}", Name = "GetProductById")]
        public Products Get(int id)
        {
            var product = new ProductSC().GetProductByID(id).FirstOrDefault();
            return product;
        }

        // POST: api/Products
        [HttpPost(Name = "NewCommodity")]
        public void Post([FromBody] CommodityModel newCommodity)
        {
            new ProductSC().AddProduct(newCommodity);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
