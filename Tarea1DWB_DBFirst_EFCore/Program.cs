using System;
using System.Linq;
using Tarea1DWB_DBFirst_EFCore.DataAccess;

namespace Tarea1DWB_DBFirst_EFCore
{
    class Program
    {
        public static NorthwindContext dbContext = new NorthwindContext();

        #region Methods
        public static void SelectProducts()
        {
            var productsQuery = GetAllProducts();

            //var outPut = productsQuery.ToList();
        }

        //Mostramos los datos de un producto en especial
        public static void SelectProduct(string productName)
        {
            var productQuery = GetAllProducts().Where(w => w.ProductName == productName).Select(p => new
            {
                ID = p.ProductId,
                Producto = p.ProductName,
                CantporUnidad = p.QuantityPerUnit,
                Precio = p.UnitPrice,
                Disponibilidad = p.UnitsInStock,
                Continuidad = p.Discontinued
            });

            //var outPut = productQuery.ToList();
        }

        public static void UpdateProductName(int productId, string productName)
        {
            Products currentProduct = GetProductByID(productId);

            if (currentProduct == null)
                throw new Exception("\nID de producto no escontrado");

            currentProduct.ProductName = productName;

            dbContext.SaveChanges();
        }

        public static void AddProduct(string productName, int? supplierId, int? categoryId, decimal? unitPrice, short? unitsInStock, short? unitsOnOrder, short? reorderLevel, bool discontinued = false, string quantityPerUnit = "")
        {
            AddNewProduct(productName, supplierId, categoryId, unitPrice, unitsInStock, unitsOnOrder, reorderLevel, discontinued, quantityPerUnit);
        }

        public static void DeleteProduct(int productId)
        {
            var dProduct = GetProductByID(productId);

            dbContext.Products.Remove(dProduct);
            dbContext.SaveChanges();
        }

        //Devuelve el producto, cliente y empleado por OrderID
        public static void OrderProducts(int orderId)
        {
            var ordersQuery = GetOrderById(orderId).Select(o => new
                {
                    Cliente = o.Customer.CompanyName,
                    Empleado = o.Employee.FirstName,
                    Productos = o.OrderDetails.Select(ordDet => ordDet.Product.ProductName)
                });

            var outPut = ordersQuery.ToList();
        }

        public static void SelectEmployees()
        {
            var employeesQuery = GetAllEmployees();

            var outPut = employeesQuery.ToList();
        }

        //Mostramos los datos de un empleado en especial
        public static void SelectEmployee(string employeeFirstName, string employeeLastName)
        {
            var employeeQuery = GetAllEmployees().
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

        public static void UpdateEmployeeName(int employeeID, string employeeName, int isFirstName = 1)
        {
            var currentEmployee = GetAllEmployees().Where(e => e.EmployeeId == employeeID).FirstOrDefault();

            if (currentEmployee == null)
                throw new Exception("\nID de empleado no escontrado");

            if (isFirstName == 1)
                currentEmployee.FirstName = employeeName;
            else
                currentEmployee.LastName = employeeName;

            dbContext.SaveChanges();
        }
        #endregion

        #region privateMethods
        private static IQueryable<Products> GetAllProducts()
        {
            return dbContext.Products.Select(p => p);
        }

        private static IQueryable<Employees> GetAllEmployees()
        {
            return dbContext.Employees.Select(e => e);
        }

        private static IQueryable<Orders> GetAllOrders()
        {
            return dbContext.Orders;
        }

        private static Products GetProductByID(int productId)
        {
            return GetAllProducts().Where(prod => prod.ProductId == productId).FirstOrDefault();
        }

        private static IQueryable<Orders> GetOrderById(int orderId)
        {
            return GetAllOrders().Where(w => w.OrderId == orderId);
        }

        private static void AddNewProduct(string productName, int? supplierId, int? categoryId, decimal? unitPrice, short? unitsInStock, short? unitsOnOrder, short? reorderLevel, bool discontinued, string quantityPerUnit)
        {
            var newProduct = new Products();

            newProduct.ProductName = productName;
            newProduct.SupplierId = supplierId;
            newProduct.CategoryId = categoryId;
            newProduct.QuantityPerUnit = quantityPerUnit;
            newProduct.UnitPrice = unitPrice;
            newProduct.UnitsInStock = unitsInStock;
            newProduct.UnitsOnOrder = unitsOnOrder;
            newProduct.ReorderLevel = reorderLevel;
            newProduct.Discontinued = discontinued;

            dbContext.Products.Add(newProduct);
            dbContext.SaveChanges();
        }
        #endregion

        static void Main(string[] args)
        {
            //addProduct(productName: "Agua loca", unitsInStock: 6, unitsOnOrder: 0, unitPrice: 30, quantityPerUnit: "20 boxes", supplierId: null, categoryId: null, reorderLevel: null);
            Console.WriteLine("Hello World!");
        }
    }
}
