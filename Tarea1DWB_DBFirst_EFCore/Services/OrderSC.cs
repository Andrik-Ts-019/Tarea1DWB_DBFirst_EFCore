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
        public void UpdateShipAdressOrder(int orderId, string shipAdress)
        {
            var currentOrder = GetOrderById(orderId);

            if (currentOrder == null)
                throw new Exception("\nID de Orden no escontrado");

            currentOrder.ShipAddress = shipAdress;

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
        public Orders GetOrderById(int orderId)
        {
            return GetAllOrders().Where(w => w.OrderId == orderId).FirstOrDefault(); ;
        }
        #endregion
    }
}
