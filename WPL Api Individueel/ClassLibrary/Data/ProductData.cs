using ClassLibrary.Business.Entities;
using ClassLibrary.Data.Framework;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ClassLibrary.Data
{
    public class ProductData : SqlServer
    {
        public SelectResult Select()
        {
            return base.Select("SportProductsYens");
        }

        public SelectResult GetProductById(int productId)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM SportProductsYens WHERE ProductID = @ProductId");
            command.Parameters.AddWithValue("@ProductId", productId);
            return base.Select(command);
        }
        public InsertResult Insert(Product product)
        {
            var result = new InsertResult();
            try
            {
                //SQL Command
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append("INSERT INTO dbo.SportProductsYens ");
                insertQuery.Append("(ProductName, ProductDescription, PricePerUnit, Stock, Category, Size) VALUES ");
                insertQuery.Append("(@ProductName, @ProductDescription, @PricePerUnit, @Stock, @Category, @Size);");
                using (SqlCommand insertCommand = new SqlCommand(insertQuery.ToString()))
                {
                    insertCommand.Parameters.Add("@ProductName", SqlDbType.NVarChar, 100).Value = product.ProductName;
                    insertCommand.Parameters.Add("@ProductDescription", SqlDbType.NVarChar, 500).Value = product.ProductDescription;
                    insertCommand.Parameters.Add("@PricePerUnit", SqlDbType.Int).Value = product.PricePerUnit;
                    insertCommand.Parameters.Add("@Stock", SqlDbType.Int).Value = product.Stock;
                    insertCommand.Parameters.Add("@Category", SqlDbType.Int).Value = product.Category;
                    insertCommand.Parameters.Add("@Size", SqlDbType.Char, 1).Value = product.Size.ToString();
                    result = InsertRecord(insertCommand);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            result.Succeeded = true;
            return result;
        }

        public UpdateResult Update(Product product)
        {
            SqlCommand command = new SqlCommand("UPDATE SportProductsYens SET ProductName = @ProductName, ProductDescription = @ProductDescription, PricePerUnit = @PricePerUnit, Stock = @Stock, Category = @Category, Size = @Size WHERE ProductID = @ProductID;");
            command.Parameters.AddWithValue("@ProductName", product.ProductName);
            command.Parameters.AddWithValue("@ProductDescription", product.ProductDescription);
            command.Parameters.AddWithValue("@PricePerUnit", product.PricePerUnit);
            command.Parameters.AddWithValue("@Stock", product.Stock);
            command.Parameters.AddWithValue("@Category", product.Category);
            command.Parameters.AddWithValue("@Size", product.Size);
            command.Parameters.AddWithValue("@ProductID", product.ProductID);

            return base.UpdateRecord(command);
        }
    }
}
