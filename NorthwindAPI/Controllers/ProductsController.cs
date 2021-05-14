﻿using System;
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
        public List<Products> Get()
        {
            var products = productService.GetAllProducts().ToList();
            return products;
        }

        // GET: api/Products/5
        [HttpGet("{id}", Name = "GetProductById")]
        public Products Get(int id)
        {
            var product = productService.GetProductByID(id).FirstOrDefault();
            return product;
        }

        // POST: api/Products
        [HttpPost(Name = "NewCommodity")]
        public void Post([FromBody] CommodityModel newCommodity)
        {
            productService.AddProduct(newCommodity);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}", Name = "DeleteProduct")]
        public void Delete(int id)
        {
            productService.DeleteProductById(id);
        }
    }
}
