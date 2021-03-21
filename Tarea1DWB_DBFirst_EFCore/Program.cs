using System;
using System.Linq;
using Tarea1DWB_DBFirst_EFCore.DataAccess;

namespace Tarea1DWB_DBFirst_EFCore
{
    class Program
    {
        //Mostramos todos los productos
        public static void selectProducts()
        {
            //Objeto por el cual accedemos a las entidades de la BD
            NorthwindContext northwindContext = new NorthwindContext();
            
            //Variable que recibe a la entidad Product pero no materializada. Select * From Products:
            var productsQuery = northwindContext.Products.Select(element => element);

            //Materialización de productQuery
            var outPut = productsQuery.ToList();

            //Imprimir el nombre de los productos en la tabla Products
            outPut.ForEach(i => Console.WriteLine("Producto: " + i.ProductName));
        }

        //Mostramos los datos de un producto en especial
        public static void selectProducts(string productName)
        {
            //Objeto por el cual accedemos a las entidades de la BD
            NorthwindContext northwindContext = new NorthwindContext();

            //Variable que recibe a la entidad Products pero no materializada.
            var productQuery = northwindContext.Products.Where(w => w.ProductName == productName).Select(p => new
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

            //Imprimir el nombre de los productos en la tabla Products
            outPut.ForEach(i => Console.WriteLine("Producto: " + i.Producto));
        }

        //Mostramos a todos los empleados
        public static void selectEmployees()
        {
            //Objeto por el cual accedemos a las entidades de la BD
            NorthwindContext northwindContext = new NorthwindContext();

            //Variable que recibe a la entidad Employees pero no materializada. Select * From Employees:
            var employeesQuery = northwindContext.Employees.Select(element => element);

            //Materialización de employeesQuery
            var outPut = employeesQuery.ToList();

            //Imprimir el id y nombre completo de los empleados registrados en la tabla Employees
            outPut.ForEach(i => Console.WriteLine("ID: " + i.EmployeeId + " " + i.FirstName + " " + i.LastName));
        }

        //Mostramos los datos de un empleado en especial
        public static void selectEmployees(string employeeFirstName, string employeeLastName)
        {
            //Objeto por el cual accedemos a las entidades de la BD
            NorthwindContext northwindContext = new NorthwindContext();

            //Variable que recibe a la entidad Employees pero no materializada.
            var employeesQuery = northwindContext.Employees.
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

            //Imprimir el id y nombre completo de los empleados registrados en la tabla Employees
            outPut.ForEach(i => Console.WriteLine("ID: " + i.ID + " " + i.Nombre + " " + i.Puesto + " " + i.Dirección));
        }

        //Actualización del nombre oapellido de un empleado
        public static void updateEmployeeName(int employeeID, string employeeFLName, int isFirstName = 1)
        {
            //Objeto por el cual accedemos a las entidades de la BD
            NorthwindContext northwindContext = new NorthwindContext();
            //Variable que guarda el dato a acualizar.
            var currentEmployee = northwindContext.Employees.Where(emp => emp.EmployeeId == employeeID).FirstOrDefault();

            if (currentEmployee == null)
                throw new Exception("\nID de empleado no escontrado");
            
            if (isFirstName == 1)
                //Actualizamos FistName en currentEmployee
                currentEmployee.FirstName = employeeFLName;
            else
                //Actualizamos Lastame en currentEmployee
                currentEmployee.LastName = employeeFLName;

            //Guardamos cambios pues currentEmployee está enlazado a northwindContext
            northwindContext.SaveChanges();
        }

        //Actualización del nombre de un producto
        public static void updateProductName(int productId, string productName)
        {
            //Objeto por el cual accedemos a las entidades de la BD
            NorthwindContext northwindContext = new NorthwindContext();
            Products currentProduct = getProductByID(productId, northwindContext);

            if (currentProduct == null)
                throw new Exception("ID de producto no escontrado");

            //Actualizamos ProductName en currentProduct
            currentProduct.ProductName = productName;

            //Guardamos cambios pues currentProduct está enlazado a northwindContext
            northwindContext.SaveChanges();
        }

        private static Products getProductByID(int productId, NorthwindContext northwindContext)
        {
            return northwindContext.Products.Where(prod => prod.ProductId == productId).FirstOrDefault();
        }

        //Nuevo registro en Products
        public static void addProduct(string productName, int? supplierId, int? categoryId, decimal? unitPrice, short? unitsInStock, short? unitsOnOrder, short? reorderLevel, bool discontinued = false, string quantityPerUnit = "")
        {
            //Objeto por el cual accedemos a las entidades de la BD
            NorthwindContext northwindContext = new NorthwindContext();
            
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

            northwindContext.Products.Add(newProduct);
            northwindContext.SaveChanges();
        }

        //Nuevo registro en Products
        public static void deleteProduct(int productId)
        {
            //Objeto por el cual accedemos a las entidades de la BD
            NorthwindContext northwindContext = new NorthwindContext();

            //Variable que guarda el producto a borrar.
            var dProduct = getProductByID(productId,northwindContext);

            //Borramos registro
            northwindContext.Products.Remove(dProduct);

            northwindContext.SaveChanges();
        }

        //Devuelve el producto, cliente y empleado por OrderID
        public static void joinProductClientEmployee(int orderId)
        {
            //Objeto por el cual accedemos a las entidades de la BD
            NorthwindContext northwindContext = new NorthwindContext();

            //Obtenermos el pedido
            var ordersQuery = northwindContext.Orders.Where(w => w.OrderId == orderId)
                .Select(ord => new
                {
                    Cliente = ord.Customer.CompanyName,
                    Empleado = ord.Employee.FirstName,
                    Productos = ord.OrderDetails.Select(ordDet => ordDet.Product.ProductName)
                });

            //Materialización de productQuery
            var output = ordersQuery.ToList();

            //Imprimir el nombre de los productos en la tabla Products
            //outPut.ForEach(i => Console.WriteLine("Producto: " + i.OrderId));
        }

        static void Main(string[] args)
        {
            //addProduct(productName: "Agua loca", unitsInStock: 6, unitsOnOrder: 0, unitPrice: 30, quantityPerUnit: "20 boxes", supplierId: null, categoryId: null, reorderLevel: null);
            joinProductClientEmployee(10248);
            Console.WriteLine("Hello World!");
        }
    }
}
