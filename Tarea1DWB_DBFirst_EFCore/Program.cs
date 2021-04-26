using System;
using System.Linq;
using Tarea1DWB_DBFirst_EFCore.Services;

namespace Tarea1DWB_DBFirst_EFCore
{
    class Program
    {

        public static EmployeeSC employeeService = new EmployeeSC();
        public static ProductSC productService = new ProductSC();
        public static OrderSC orderService = new OrderSC();

        #region Methods
        public static void SelectProducts()
        {
            var productsQuery = productService.GetAllProducts();

            var outPut = productsQuery.ToList();
        }

        public static void SelectProduct(string productName)
        {
            var productQuery = productService.GetAllProducts().Where(w => w.ProductName == productName).Select(p => new
            {
                ID = p.ProductId,
                Producto = p.ProductName,
                CantporUnidad = p.QuantityPerUnit,
                Precio = p.UnitPrice,
                Disponibilidad = p.UnitsInStock,
                Continuidad = p.Discontinued
            });

            var outPut = productQuery.ToList();
        }

        public static void ChangeProductName(int productId, string productName)
        {
            productService.UpdateProductName(productId, productName);
        }

        public static void AddProduct(string productName, int? supplierId, int? categoryId, decimal? unitPrice, short? unitsInStock, short? unitsOnOrder, short? reorderLevel, bool discontinued = false, string quantityPerUnit = "")
        {
            productService.AddNewProduct(productName, supplierId, categoryId, unitPrice, unitsInStock, unitsOnOrder, reorderLevel, discontinued, quantityPerUnit);
        }

        public static void RemoveProducto(int productId)
        {
            productService.DeleteProduct(productId);
        }


        public static void OrderProducts(int orderId)
        {
            var ordersQuery = orderService.GetOrderById(orderId).Select(o => new
                {
                    Cliente = o.Customer.CompanyName,
                    Empleado = o.Employee.FirstName,
                    Productos = o.OrderDetails.Select(ordDet => ordDet.Product.ProductName)
                });

            var outPut = ordersQuery.ToList();
        }

        public static void SelectEmployees()
        {
            var employeesQuery = employeeService.GetAllEmployees();
            var outPut = employeesQuery.ToList();
        }

        public static void SelectEmployee(string employeeFirstName, string employeeLastName)
        {
            var employeeQuery = employeeService.GetAllEmployees().
                Where(w => (w.FirstName == employeeFirstName) && (w.LastName == employeeLastName)).Select(e => new
                {
                    ID = e.EmployeeId,
                    Nombre = e.FirstName,
                    Apellido = e.LastName,
                    Puesto = e.Title,
                    Dirección = e.Address,
                    Telefono = e.HomePhone
                });
            var outPut = employeeQuery.ToList();

        }

        public static void ChangeEmployeeName(int employeeID, string employeeName, int isFirstName = 1)
        {
            employeeService.UpdateEmployeeName(employeeID, employeeName, isFirstName);
        }
        #endregion

        static void Main(string[] args)
        {
            //SelectProducts();
            //SelectProduct("Chang");
            //ChangeProductName(2,"Chong");
            //addProduct(productName: "Agua loca", unitsInStock: 6, unitsOnOrder: 0, unitPrice: 30, quantityPerUnit: "20 boxes", supplierId: null, categoryId: null, reorderLevel: null);
            //RemoveProducto(78);
            //OrderProducts(2);
            //SelectEmployees();
            //SelectEmployee("Andrew", "Fuller");
            //ChangeEmployeeName(3, "Jennifer", 1);

            //Console.WriteLine("Hello World!");
        }
    }
}
