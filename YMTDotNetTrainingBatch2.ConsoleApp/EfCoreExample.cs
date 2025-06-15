using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMTDotNetTrainingBatch2.ConsoleApp
{
    internal class EfCoreExample
    {

        public void Create()
        {
            Console.Write("Enter Blog Title: ");
            string title = Console.ReadLine()!;
            Console.Write("Enter Blog Author: ");
            string author = Console.ReadLine()!;
            AppDbContext db = new AppDbContext();
            BlogModel newBlog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author
            };
            db.Blogs.Add(newBlog);
            int result = db.SaveChanges();
            Console.WriteLine(result > 0 ? "Blog created successfully." : "Failed to create blog.");

        }

        public void Read()
        {
            AppDbContext db = new AppDbContext();
            List<BlogModel> list = db.Blogs.ToList();
            foreach (BlogModel item in list)
            {
                Console.WriteLine("=> " + item.BlogId);
                Console.WriteLine("=> " + item.BlogTitle);
                Console.WriteLine("=> " + item.BlogAuthor);
            }
        }

        public void Edit()
        {
        FirstPage: 
            Console.Write("Enter blog id to edit: ");
            bool isInt = int.TryParse(Console.ReadLine(), out int blogId);
            if (!isInt)
            {
                Console.WriteLine("Input an integer!");
                goto FirstPage;
            }
            AppDbContext db = new AppDbContext();
            BlogModel? item = db.Blogs.FirstOrDefault(x => x.BlogId == blogId);
            Console.WriteLine(item == null ? "Blog not found" : "Blog found");
        }

        public void Update()
        {
        FirstPage:
            Console.Write("Enter blog id to update: ");
            bool isInt = int.TryParse(Console.ReadLine(), out int blogId);
            if (!isInt)
            {
                goto FirstPage;
            }
            Console.Write("Modify blog title : ");
            string newTitle = Console.ReadLine()!;
            Console.Write("Modify blog author : ");
            string newAuthor = Console.ReadLine()!;

            bool blogExists = isExist(blogId);
            if (!blogExists) return;
            
            AppDbContext db = new AppDbContext();
            BlogModel? item = db.Blogs.FirstOrDefault(x => x.BlogId == blogId);

            item.BlogTitle = newTitle;
            item.BlogAuthor = newAuthor;

            int result = db.SaveChanges();
            Console.WriteLine(result > 0 ? "Blog updated successfully." : "Failed to update blog.");


        }

        public void Delete()
        {
        FirstPage:
            Console.Write("Enter blog id to delete: ");
            bool isInt = int.TryParse(Console.ReadLine(), out int blogId);
            if (!isInt)
            {
                goto FirstPage;
            }
            AppDbContext db = new AppDbContext();
            BlogModel? item = db.Blogs.FirstOrDefault(x => x.BlogId == blogId);
            if (item is null) return;
            db.Blogs.Remove(item);
            int result = db.SaveChanges();
            Console.WriteLine(result > 0 ? "Blog deleted successfully." : "Failed to deleted blog.");
        }

        private bool isExist(int blogId)
        {
            AppDbContext db = new AppDbContext();
            BlogModel? item = db.Blogs.FirstOrDefault(x => x.BlogId == blogId);
            return item != null;
        }
    }
}
