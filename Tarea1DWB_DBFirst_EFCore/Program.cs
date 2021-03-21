﻿using System;
using System.Linq;
using Tarea1DWB_DBFirst_EFCore.DataAccess;

namespace Tarea1DWB_DBFirst_EFCore
{
    class Program
    {
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

        public static void selectProducts(string productName)
        {
            //Objeto por el cual accedemos a las entidades de la BD
            NorthwindContext northwindContext = new NorthwindContext();

            //Variable que recibe a la entidad Products pero no materializada.
            var ProductQuery = northwindContext.Products.Select(p => new
            {
                p.ProductId,
                p.ProductName,
                p.QuantityPerUnit,
                p.UnitPrice,
                p.UnitsInStock,
                p.Discontinued
            }).Where(w => w.ProductName == productName);

            //Materialización de productQuery
            var outPut = ProductQuery.ToList();

            //Imprimir el nombre de los productos en la tabla Products
            outPut.ForEach(i => Console.WriteLine("Producto: " + i.ProductName));
        }

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

        public static void selectEmployees(string employeeFirstName, string employeeLastName)
        {
            //Objeto por el cual accedemos a las entidades de la BD
            NorthwindContext northwindContext = new NorthwindContext();

            //Variable que recibe a la entidad Employees pero no materializada.
            var employeesQuery = northwindContext.Employees.Select(e => new
            {
                e.EmployeeId,
                e.FirstName,
                e.LastName,
                e.Title,
                e.Address,
                e.HomePhone
            }).Where(w => w.FirstName == employeeFirstName && w.LastName == employeeLastName);

            //Materialización de employeesQuery
            var outPut = employeesQuery.ToList();

            //Imprimir el id y nombre completo de los empleados registrados en la tabla Employees
            outPut.ForEach(i => Console.WriteLine("ID: " + i.EmployeeId + " " + i.FirstName + " " + i.Title + " " + i.Address));
        }

        public static void joinOrdersOrderDetals(int id = 0)
        {
            //Objeto por el cual accedemos a las entidades de la BD
            NorthwindContext northwindContext = new NorthwindContext();

            //Variable que recibe a la entidad OrderDetails  por medio de Orders pero no materializada.
            var OrdersQuery = northwindContext.Orders.Where(order => order.OrderId == id).SelectMany(element => element.OrderDetails);

            //Materialización de productQuery
            var outPut = OrdersQuery.ToList();

            //Imprimir el nombre de los productos en la tabla Products
            outPut.ForEach(i => Console.WriteLine("Producto: " + i.OrderId));
        }

        static void Main(string[] args)
        {
            selectEmployees();
            Console.WriteLine("Hello World!");
        }
    }
}
