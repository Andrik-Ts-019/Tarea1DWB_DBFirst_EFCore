using System;
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

        static void Main(string[] args)
        {
            selectProducts();
            Console.WriteLine("Hello World!");
        }
    }
}
