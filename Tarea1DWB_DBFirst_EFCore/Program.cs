using System;
using System.Linq;
using Tarea1DWB_DBFirst_EFCore.DataAccess;

namespace Tarea1DWB_DBFirst_EFCore
{
    class Program
    {
        //Objeto por el cual accedemos a las entidades de la BD
        public static NorthwindContext dbContext = new NorthwindContext();

        //Mostramos todos los productos
        public static void selectProducts()
        {
            //Variable que recibe a la entidad Product pero no materializada. Select * From Products:
            var productsQuery = GetAllProducts();

            //Materialización de productQuery
            var outPut = productsQuery.ToList();
        }

        //Mostramos los datos de un producto en especial
        public static void selectProducts(string productName)
        {
            //Variable que recibe a la entidad Products pero no materializada.
            var productQuery = GetAllProducts().Where(w => w.ProductName == productName).Select(p => new
            {
                ID = p.ProductId,
                Producto = p.ProductName,
                CantporUnidad = p.QuantityPerUnit,
                Precio = p.UnitPrice,
                Disponibilidad = p.UnitsInStock,
                Continuidad = p.Discontinued
            });

            //Materialización de productQuery
            var outPut = productQuery.ToList();
        }

        //Mostramos a todos los empleados
        public static void selectEmployees()
        {
            //Variable que recibe a la entidad Employees pero no materializada. Select * From Employees:
            var employeesQuery = GetAllEmployees();

            //Materialización de employeesQuery
            var outPut = employeesQuery.ToList();
        }

        //Mostramos los datos de un empleado en especial
        public static void selectEmployees(string employeeFirstName, string employeeLastName)
        {
            //Variable que recibe a la entidad Employees pero no materializada.
            var employeesQuery = GetAllEmployees().
                Where(w => (w.FirstName == employeeFirstName) && (w.LastName == employeeLastName)).Select(e => new
            {
                ID = e.EmployeeId,
                Nombre = e.FirstName,
                Apellido = e.LastName,
                Puesto = e.Title,
                Dirección = e.Address,
                Telefono = e.HomePhone
            });

            //Materialización de employeesQuery
            var outPut = employeesQuery.ToList();
        }

        //Actualización del nombre o apellido de un empleado
        public static void updateEmployeeName(int employeeID, string employeeName, int isFirstName = 1)
        {
            //Variable que guarda el dato a acualizar.
            var currentEmployee = GetAllEmployees().Where(e => e.EmployeeId == employeeID).FirstOrDefault();

            if (currentEmployee == null)
                throw new Exception("\nID de empleado no escontrado");
            
            if (isFirstName == 1)
                //Actualizamos FistName en currentEmployee
                currentEmployee.FirstName = employeeName;
            else
                //Actualizamos Lastame en currentEmployee
                currentEmployee.LastName = employeeName;

            //Guardamos cambios pues currentEmployee está enlazado a dbContext
            dbContext.SaveChanges();
        }

        //Actualización del nombre de un producto
        public static void updateProductName(int productId, string productName)
        {
            Products currentProduct = getProductByID(productId);

            if (currentProduct == null)
                throw new Exception("ID de producto no escontrado");

            //Actualizamos ProductName en currentProduct
            currentProduct.ProductName = productName;

            //Guardamos cambios pues currentProduct está enlazado a dbContext
            dbContext.SaveChanges();
        }

        //Nuevo registro en Products
        public static void addProduct(string productName, int? supplierId, int? categoryId, decimal? unitPrice, short? unitsInStock, short? unitsOnOrder, short? reorderLevel, bool discontinued = false, string quantityPerUnit = "")
        {
            //Variable que guarda el nuevo producto.
            var newProduct = new Products();

            //Asignamos datos
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

        //Nuevo registro en Products
        public static void deleteProduct(int productId)
        {
            //Variable que guarda el producto a borrar.
            var dProduct = getProductByID(productId);

            //Borramos registro
            dbContext.Products.Remove(dProduct);
            //Guardamos los cambios
            dbContext.SaveChanges();
        }

        //Devuelve el producto, cliente y empleado por OrderID
        public static void orderProducts(int orderId)
        {
            //Obtenermos el pedido
            var ordersQuery = GetAllOrders().Where(w => w.OrderId == orderId)
                .Select(ord => new
                {
                    Cliente = ord.Customer.CompanyName,
                    Empleado = ord.Employee.FirstName,
                    Productos = ord.OrderDetails.Select(ordDet => ordDet.Product.ProductName)
                });
        }

        //Métodos privados
        #region HelperMethods
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
            return dbContext.Orders.Select(o => o);
        }

        private static Products getProductByID(int productId)
        {
            return dbContext.Products.Where(prod => prod.ProductId == productId).FirstOrDefault();
        }
        #endregion

        static void Main(string[] args)
        {
            //addProduct(productName: "Agua loca", unitsInStock: 6, unitsOnOrder: 0, unitPrice: 30, quantityPerUnit: "20 boxes", supplierId: null, categoryId: null, reorderLevel: null);
            //joinProductClientEmployee(10248);
            Console.WriteLine("Hello World!");
        }
    }
}
