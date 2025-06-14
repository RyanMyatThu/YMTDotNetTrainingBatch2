using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMTDotNetTrainingBatch2.ConsoleApp
{
    public class AdoDotnetExample
    {
        SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "DotNetTrainingBatch2",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };

        public void Read()
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            string query = "SELECT * FROM Tbl_Blogs";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            connection.Close();
           
            for(int i =0; i < dataTable.Rows.Count; i++)
            {
                DataRow row = dataTable.Rows[i];
                Console.WriteLine("=> " + row["BlogId"]);
                Console.WriteLine("=> " + row["BlogTitle"]);
                Console.WriteLine("=> " + row["BlogAuthor"]);
            }

            Console.ReadLine();
        }

        public void Create()
        {
            Console.WriteLine("Enter Blog Title: ");
            string title = Console.ReadLine()!;
            Console.WriteLine("Enter Blog Author: ");
            string author = Console.ReadLine()!;

            string query = @"INSERT INTO [dbo].[Tbl_Blogs]
           ([BlogTitle]
           ,[BlogAuthor])
     VALUES
           (@title
           ,@author)";

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@title", title);
            command.Parameters.AddWithValue("@author", author);
            int result = command.ExecuteNonQuery();
            connection.Close();
            Console.WriteLine(result > 0 ? "Insert Success!" : "Insert Failed!");
        }

        public void Update()
        {
            Console.WriteLine("Enter Blog Id to Update: ");
            string blogId = Console.ReadLine()!;
            Console.WriteLine("Enter New Blog Title: ");
            string title = Console.ReadLine()!;
            Console.WriteLine("Enter New Blog Author: ");
            string author = Console.ReadLine()!;

            string query = @"UPDATE [dbo].[Tbl_Blogs]
                            SET [BlogTitle] = @newTitle
                              ,[BlogAuthor] = @newAuthor
                             WHERE BlogId = @blogId
";

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@newTitle", title);
            command.Parameters.AddWithValue("@newAuthor", author);
            command.Parameters.AddWithValue("@blogId", blogId);
            int result = command.ExecuteNonQuery();
            connection.Close();
            Console.WriteLine(result > 0 ? "Update Success!" : "Update Failed!");

        }
         
        public void Delete()
        {
            Console.WriteLine("Enter Blog Id to Delete: ");
            string blogId = Console.ReadLine()!;

            string query = @"DELETE FROM [dbo].[Tbl_Blogs]
                             WHERE BlogId = @blogId";
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@blogId", blogId);
            int result = command.ExecuteNonQuery();
            connection.Close();
            Console.WriteLine(result > 0 ? "Delete Success!" : "Delete Failed!");
        }


    }

   
}
