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
        private OrderSC orderService = new OrderSC();

        // GET: api/Orders
        [HttpGet(Name ="GetOrders")]
        public IActionResult Get()
        {
            var orders = orderService.GetAllOrders().ToList();
            return Ok(orders);
        }

        // GET: api/Orders/5
        [HttpGet("{id}", Name = "GetOrdersById")]
        public IActionResult Get(int id)
        {
            var order = orderService.GetOrderById(id).FirstOrDefault();
            return Ok(order);
        }

        // POST: api/Orders
        [HttpPost(Name = "NewOrder")]
        public IActionResult Post([FromBody] OrderModel newOrder)
        {
            orderService.NewOrder(newOrder);
            return Ok();
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return Ok();
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}", Name = "DeleteOrder")]
        public IActionResult Delete(int id)
        {
            orderService.DeleteOrderById(id);
            return Ok();
        }
    }
}
