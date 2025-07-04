﻿using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMTDotNetTrainingBatch2.ConsoleApp
{
    internal class DapperExample
    {
        private readonly SqlConnectionStringBuilder _stringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            UserID = "sa",
            InitialCatalog = "DotNetTrainingBatch2",
            TrustServerCertificate = true,
            Password = "sasa@123"

        };
        public void Read()
        {
            using (IDbConnection db = new SqlConnection(_stringBuilder.ConnectionString))
            {
                db.Open();
                List<BlogDTO> items = db.Query<BlogDTO>("SELECT * FROM Tbl_Blogs").ToList();
                foreach (BlogDTO item in items)
                {
                    Console.WriteLine("=> " + item.blogId);
                    Console.WriteLine("=> " + item.blogTitle);
                    Console.WriteLine("=> " + item.blogAuthor);
                }
            }
             ;
        }
        public void Edit()
        {
        FirstPage:
            Console.WriteLine("Enter Blog Id : ");
            bool isInt = int.TryParse(Console.ReadLine(), out int blogId);
            if (!isInt)
            {
                Console.WriteLine("Invalid Blog Id. Please enter a valid integer.");
                goto FirstPage;
            }
            using (IDbConnection db = new SqlConnection(_stringBuilder.ConnectionString))
            {
                db.Open();
                BlogDTO? item = db.QueryFirstOrDefault<BlogDTO>("SELECT * FROM Tbl_Blogs WHERE BlogId = @blogId", new { blogId });
                if (item == null)
                {

                    Console.WriteLine("No record found with the given Blog Id.");
                    return;
                }

                Console.WriteLine("=> " + item.blogId);
                Console.WriteLine("=> " + item.blogTitle);
                Console.WriteLine("=> " + item.blogAuthor);
            }
        }
        public void Update()
        {
        FirstPage:
            Console.WriteLine("Enter Blog Id to update: ");
            bool isInt = int.TryParse(Console.ReadLine(), out int blogId);
            if (!isInt)
            {
                Console.WriteLine("Invalid Blog Id. Please enter a valid integer.");
                goto FirstPage;
            }
            using (IDbConnection db = new SqlConnection(_stringBuilder.ConnectionString))
            {
                db.Open();
                BlogDTO? item = db.QueryFirstOrDefault<BlogDTO>("SELECT * FROM Tbl_Blogs WHERE BlogId = @blogId", new { blogId });
                if (item == null)
                {
                    Console.WriteLine("No record found with the given Blog Id.");
                    return;
                }

                Console.WriteLine("Enter New Title: ");
                string newTitle = Console.ReadLine()!;
                Console.WriteLine("Enter New Author: ");
                string newAuthor = Console.ReadLine()!;

                string query = @"UPDATE Tbl_Blogs SET BlogTitle = @newTitle, BlogAuthor = @newAuthor WHERE BlogId = @blogId";
                int result = db.Execute(query, new { newTitle, newAuthor, blogId });
                Console.WriteLine(result > 0 ? "Blog updated successfully." : "Failed to update blog.");
            }

        }
        public void Create()
        {
            Console.WriteLine("Enter Blog Title: ");
            string title = Console.ReadLine()!;
            Console.WriteLine("Enter Blog Author: ");
            string author = Console.ReadLine()!;
            using (IDbConnection db = new SqlConnection(_stringBuilder.ConnectionString))
            {
                db.Open();
                string query = @"INSERT INTO [dbo].[Tbl_Blogs]
                                 ([BlogTitle]
                                  ,[BlogAuthor])
                                 VALUES
                                 (@BlogTitle
                                 ,@BlogAuthor)";
                int result = db.Execute(query, new { BlogTitle = title, BlogAuthor = author });
                Console.WriteLine(result > 0 ? "Blog created successfully." : "Failed to create blog.");
            }
        }
       public void Delete()
        {
        FirstPage:
            Console.WriteLine("Enter Blog Id to delete: ");
            bool isInt = int.TryParse(Console.ReadLine(), out int blogId);
            if (!isInt)
            {
                Console.WriteLine("Invalid Blog Id. Please enter a valid integer.");
                goto FirstPage;
            }
            using (IDbConnection db = new SqlConnection(_stringBuilder.ConnectionString))
            {
                db.Open();
                string query = "DELETE FROM Tbl_Blogs WHERE BlogId = @blogId";
                int result = db.Execute(query, new { blogId });
                Console.WriteLine(result > 0 ? "Blog deleted successfully." : "Failed to delete blog.");

            }
        }
    }
}
