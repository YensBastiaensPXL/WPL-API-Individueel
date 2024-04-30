using System;
using System.Data;
using System.Data.SqlClient;

namespace ClassLibrary.Data.Framework
{
    public abstract class SqlServer
    {

        SqlConnection connection;
        SqlDataAdapter adapter;
        public SqlServer()
        {
            connection = new SqlConnection(LocalSettings.GetConnectionString());
        }
        protected SelectResult Select(SqlCommand selectCommand)
        {
            var result = new SelectResult();
            try
            {
                using (connection)
                {
                    selectCommand.Connection = connection;
                    connection.Open();
                    adapter = new SqlDataAdapter(selectCommand);
                    result.DataTable = new System.Data.DataTable();
                    adapter.Fill(result.DataTable);
                    connection.Close();
                }
                result.Succeeded = true;
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }
            return result;
        }
        protected SelectResult Select(string tableName)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = $"SELECT * FROM {tableName}";
            return Select(command);
        }

        protected InsertResult InsertRecord(SqlCommand insertCommand)
        {
            InsertResult result = new InsertResult();
            try
            {
                using (connection)
                {
                    insertCommand.CommandText += "SET @new_id = SCOPE_IDENTITY();";
                    insertCommand.Parameters.Add("@new_id", SqlDbType.Int).Direction = ParameterDirection.Output;
                    insertCommand.Connection = connection;
                    connection.Open();
                    insertCommand.ExecuteNonQuery();
                    var newIdValue = insertCommand.Parameters["@new_id"].Value;
                    int newId = newIdValue != DBNull.Value ? Convert.ToInt32(newIdValue) : 0; // Handle DBNull
                    result.NewId = newId;
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while inserting record.", ex); // Improved error message
            }
            return result;
        }

        protected UpdateResult UpdateRecord(SqlCommand updateCommand)
        {
            UpdateResult result = new UpdateResult();
            try
            {
                using (connection)
                {
                    updateCommand.Connection = connection;
                    connection.Open();
                    result.RowsAffected = updateCommand.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while updating record.", ex); // Improved error message
            }
            return result;
        }

    }
}
