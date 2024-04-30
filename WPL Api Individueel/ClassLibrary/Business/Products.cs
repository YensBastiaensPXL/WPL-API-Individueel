using ClassLibrary.Business.Entities;
using ClassLibrary.Data;
using ClassLibrary.Data.Framework;
using System;
using System.Collections.Generic;

namespace ClassLibrary.Business
{
    public class Products
    {
        //public static List<Product> MakeListFromDataTable(DataTable dataTable)
        //{
        //    var productList = new List<Product>();
        //    foreach (DataRow row in dataTable.Rows)
        //    {

        //        var product = new Product
        //        {
        //            ProductID = Convert.ToInt32(row["ProductID"]),
        //            ProductName = row["ProductName"].ToString(),
        //            ProductDescription = row["ProductDescription"].ToString(),
        //            PricePerUnit = Convert.ToInt32(row["PricePerUnit"]),
        //            Stock = Convert.ToInt32(row["Stock"]),
        //            Category = Convert.ToInt32(row["Category"]),
        //            Size = Convert.ToChar(row["Size"])

        //        };
        //        productList.Add(product);
        //    }
        //    return productList;
        //}

        // Haalt een lijst van alle producten op
        public static SelectResult GetProducts()
        {
            ProductData productData = new ProductData(); // Pas aan naar de naam van je Data Access klasse
            SelectResult result = productData.Select(); // Deze methode moet in ProductData worden gedefinieerd
            return result;
        }

        // Converteert een DataTable naar een lijst van SportProduct
        public static List<Product> MakeListFromDataTable(System.Data.DataTable dataTable)
        {
            List<Product> productList = new List<Product>();

            foreach (System.Data.DataRow row in dataTable.Rows)
            {
                Product product = new Product
                {
                    ProductID = Convert.ToInt32(row["ProductID"]),
                    ProductName = row["ProductName"].ToString(),
                    ProductDescription = row["ProductDescription"].ToString(),
                    PricePerUnit = Convert.ToInt32(row["PricePerUnit"]),
                    Stock = Convert.ToInt32(row["Stock"]),
                    Category = Convert.ToInt32(row["Category"]),
                    Size = (row["Size"].ToString())
                };
                productList.Add(product);
            }
            return productList;
        }

        // Een methode om een product toe te voegen
        public static InsertResult AddProduct(string productName, string productDescription, int pricePerUnit, int stock, int category, string size)
        {
            Product product = new Product();
            product.ProductName = productName;
            product.ProductDescription = productDescription;
            product.PricePerUnit = pricePerUnit;
            product.Stock = stock;
            product.Category = category;
            product.Size = size;
            ProductData productData = new ProductData();
            InsertResult result = productData.Insert(product);
            return result;


        }

        // Methode om een product bij te werken
        public static UpdateResult UpdateProduct(int productId, string productName, string productDescription, int pricePerUnit, int stock, int category, string size)
        {
            Product product = new Product
            {
                ProductID = productId,
                ProductName = productName,
                ProductDescription = productDescription,
                PricePerUnit = pricePerUnit,
                Stock = stock,
                Category = category,
                Size = size
            };

            ProductData productData = new ProductData(); // Pas aan naar de naam van je Data Access klasse
            UpdateResult result = productData.Update(product); // Deze methode moet in ProductData worden gedefinieerd
            return result;
        }
    }
}
