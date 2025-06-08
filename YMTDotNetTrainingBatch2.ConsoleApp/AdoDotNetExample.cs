using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMTDotNetTrainingBatch2.ConsoleApp
{
    public class AdoDotNetExample
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
            string query = "SELECT * FROM Tbl_Student";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            connection.Close();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow row = dataTable.Rows[i];
                Console.WriteLine(row["StudentId"] + "|" + row["StudentNo"] + "|" + row["StudentName"] + "|" + row["Email"]);
            }

            Console.ReadLine();
        }

        public void Create()
        {
            string query = @"INSERT INTO [dbo].[Tbl_Student]
           ([StudentNo]
           ,[StudentName]
           ,[DateOfBirth]
           ,[MobileNo]
           ,[Email]
           ,[Gender]
           ,[Address]
           ,[FatherName]
           ,[DeleteFlag])
     VALUES
           ('S0001'
           ,'Ye Myat Thu'
           ,'2006-12-14'
           ,'09754364261'
           ,'ryanmyatthu@gmail.com'
           ,'Male'
           ,'Ygn MM'
           ,'U Ye'
           ,0
		   )";

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            int result = command.ExecuteNonQuery();
            connection.Close();
            Console.WriteLine(result > 0 ? "Insert Success!" : "Insert Failed!");


        }


    }

   
}
