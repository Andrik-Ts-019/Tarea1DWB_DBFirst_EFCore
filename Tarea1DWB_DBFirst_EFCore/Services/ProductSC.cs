using DBFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tarea1DWB_DBFirst_EFCore.DataAccess;

namespace Tarea1DWB_DBFirst_EFCore.Services
{
    public class ProductSC : BaseSC
    {
        #region Methods
        //PUT
        public void AddProduct(CommodityModel newProduct)
        {
            var newProductRegister = new Products()
            {
                ProductName = newProduct.Name,
                QuantityPerUnit = newProduct.Quantity,
                UnitPrice = newProduct.Price,
                UnitsInStock = newProduct.Stock
            };
            dbContext.Products.Add(newProductRegister);
            dbContext.SaveChanges();
        }

        //POST
        public void UpdateProductName(int productId, string productName)
        {
            Products currentProduct = GetProductByID(productId).FirstOrDefault();

            if (currentProduct == null)
                throw new Exception("\nID de producto no escontrado");

            currentProduct.ProductName = productName;

            dbContext.SaveChanges();
        }

        //DELETE
        public void DeleteProduct(int productId)
        {
            var dProduct = GetProductByID(productId).FirstOrDefault();

            dbContext.Products.Remove(dProduct);
            dbContext.SaveChanges();
        }
        #endregion

        #region HelperMethods
        //GET
        public IQueryable<Products> GetAllProducts()
        {
            return dbContext.Products.Select(p => p);
        }

        //GET
        public IEnumerable<Products> GetProductByID(int productId)
        {
            return GetAllProducts().Where(prod => prod.ProductId == productId);
        }

        //PUT
        public void AddNewProduct(string productName, int? supplierId, int? categoryId, decimal? unitPrice, short? unitsInStock, short? unitsOnOrder, short? reorderLevel, bool discontinued, string quantityPerUnit)
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
    }
}
