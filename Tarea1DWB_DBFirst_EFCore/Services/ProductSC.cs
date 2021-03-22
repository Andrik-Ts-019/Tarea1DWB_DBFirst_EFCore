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
        public void UpdateProductName(int productId, string productName)
        {
            Products currentProduct = GetProductByID(productId);

            if (currentProduct == null)
                throw new Exception("\nID de producto no escontrado");

            currentProduct.ProductName = productName;

            dbContext.SaveChanges();
        }

        public void DeleteProduct(int productId)
        {
            var dProduct = GetProductByID(productId);

            dbContext.Products.Remove(dProduct);
            dbContext.SaveChanges();
        }
        #endregion

        #region HelperMethods
        public IQueryable<Products> GetAllProducts()
        {
            return dbContext.Products.Select(p => p);
        }

        public Products GetProductByID(int productId)
        {
            return GetAllProducts().Where(prod => prod.ProductId == productId).FirstOrDefault();
        }

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
