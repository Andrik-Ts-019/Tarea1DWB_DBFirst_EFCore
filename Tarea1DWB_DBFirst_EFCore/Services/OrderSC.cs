using DBFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tarea1DWB_DBFirst_EFCore.DataAccess;

namespace Tarea1DWB_DBFirst_EFCore.Services
{
    public class OrderSC : BaseSC
    {
        #region
        //POST
        public void NewOrder(OrderModel newOrder)
        {
            var newOrderRegister = new Orders() { 
                CustomerId = newOrder.ClientID,
                EmployeeId = newOrder.ClerkID,
                OrderDate = newOrder.CashOrderDate,
                RequiredDate = newOrder.RequestedDate,
                ShippedDate = newOrder.SentDate,
                ShipVia = newOrder.ShipperID,
                Freight = newOrder.Cargo,
                ShipName = newOrder.TransportName,
                ShipAddress = newOrder.TransportAddress,
                ShipCity = newOrder.TransportCity
            };
        }

        //PUT
        public void UpdateShipAdressOrder(int orderId, string shipAdress)
        {
            var currentOrder = GetOrderById(orderId).FirstOrDefault();

            if (currentOrder == null)
                throw new Exception("\nID de Orden no escontrado");

            currentOrder.ShipAddress = shipAdress;

            dbContext.SaveChanges();
        }

        //DELETE
        public void DeleteOrderById(int orderId)
        {
            var dOrder = GetOrderById(orderId).FirstOrDefault();

            dbContext.Orders.Remove(dOrder);
            dbContext.SaveChanges();
        }
        #endregion

        #region HelperMethods
        //GET
        public IQueryable<Orders> GetAllOrders()
        {
            return dbContext.Orders;
        }

        //GET
        public IEnumerable<Orders> GetOrderById(int orderId)
        {
            return GetAllOrders().Where(w => w.OrderId == orderId);
        }
        #endregion
    }
}
