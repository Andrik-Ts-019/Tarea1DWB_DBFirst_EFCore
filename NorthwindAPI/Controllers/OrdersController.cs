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
    // https://localhost:5001/api/[controller]/...
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        // GET: api/Orders
        [HttpGet(Name ="GetOrders")]
        public List<Orders> Get()
        {
            var orders = new OrderSC().GetAllOrders().ToList();
            return orders;
        }

        // GET: api/Orders/5
        [HttpGet("{id}", Name = "GetOrdersById")]
        public Orders Get(int id)
        {
            var order = new OrderSC().GetOrderById(id).FirstOrDefault();
            return order;
        }

        // POST: api/Orders
        [HttpPost(Name = "NewOrder")]
        public void Post([FromBody] OrderModel newOrder)
        {
            new OrderSC().NewOrder(newOrder);
        }

        // PUT: api/Orders/5
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
