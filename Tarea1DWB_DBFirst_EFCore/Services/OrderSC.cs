using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tarea1DWB_DBFirst_EFCore.DataAccess;

namespace Tarea1DWB_DBFirst_EFCore.Services
{
    public class OrderSC : BaseSC
    {
        #region HelperMethods
        public IQueryable<Orders> GetAllOrders()
        {
            return dbContext.Orders;
        }

        public IQueryable<Orders> GetOrderById(int orderId)
        {
            return GetAllOrders().Where(w => w.OrderId == orderId);
        }
        #endregion
    }
}
