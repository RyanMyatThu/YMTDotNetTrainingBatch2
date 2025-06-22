using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMTDotNetTrainingBatch2.Database.AppDbContextModels;
using AppDbContext = YMTDotNetTrainingBatch2.Database.AppDbContextModels.AppDbContextModels;
namespace YMTDotNetTrainingBatch2.MiniPOSConsoleApp
{
    public class ProductService
    {
        public void Create()
        {
            Console.WriteLine("Creating a new Product");
            Console.WriteLine("-----------------------");
            Console.Write("\nEnter a product name : ");
            string productName = Console.ReadLine()!;
        EnterPrice:
            Console.Write("\nEnter the price for the product : ");
            bool isDec = decimal.TryParse(Console.ReadLine(), out decimal price);
            if (!isDec)
            {
                Console.WriteLine("Invalid input. Please enter a decimal value");
                goto EnterPrice;
            };
            TblProduct product = new TblProduct()
            {
                ProductName = productName,
                Price = price,
                DeleteFlag = false
            };
            AppDbContext db = new AppDbContext();
            db.Add(product);
            int res = db.SaveChanges();
            Console.WriteLine(res > 0 ? "\nNew Product Created Successfully!" : "\nFailed To Create A New Product!");
            Console.WriteLine("\n");


        }

        public void Read()
        {
            Console.WriteLine("Obtaining Product Table From DB");
            Console.WriteLine("-------------------------------\n");

            AppDbContext db = new AppDbContext();
            List<TblProduct> products = db.TblProducts.Where(x => x.DeleteFlag == false).ToList();
            printTableData(products);
        }

        public void Edit()
        {
        EnterId:
            Console.Write("Enter Product Id To View : ");
            bool isInt = int.TryParse(Console.ReadLine(), out int id);
            if (!isInt)
            {
                Console.WriteLine("Invalid Id. Please Enter An Integer Value.");
                goto EnterId;
            }
            AppDbContext db = new AppDbContext();
            TblProduct? product = db.TblProducts.Find(id);
            if(product == null || product.DeleteFlag == true)
            {
                Console.WriteLine("Product doesn't exist\n");
                return;
            }
            Console.WriteLine("\nProduct Found\n");

            printTableData(product);

        }

        public void Update()
        {
        EnterId:
            Console.Write("Enter Product Id To Update : ");
            bool isInt = int.TryParse(Console.ReadLine(), out int id);
            if (!isInt)
            {
                Console.WriteLine("Invalid Id. Please Enter An Integer Value.");
                goto EnterId;
            }
           
            if(!isExists(id))
            {
                Console.WriteLine("Product doesn't exist\n");
                return;
            }
            AppDbContext db = new AppDbContext();
            TblProduct product = db.TblProducts.Where(prod => prod.DeleteFlag == false).First(prod => prod.ProductId == id);
            Console.Write("Enter New Product Name : ");
            string newProdName = Console.ReadLine()!;
        EnterPrice:
            Console.Write("Enter New Product Price : ");
            bool isDec = decimal.TryParse(Console.ReadLine(), out decimal newPrice);
            if (!isDec)
            {
                Console.WriteLine("Invalid Price Input. Please Enter A Decimal Value.");
                goto EnterPrice;
            }
            product.ProductName = newProdName;
            product.Price = newPrice;
            int res = db.SaveChanges();
            Console.WriteLine(res > 0 ? "Product Updated Successfully" : "Failed to Update Product");

        }

        public void Delete()
        {
        EnterId:
            Console.Write("Enter Product Id To Delete : ");
            bool isInt = int.TryParse(Console.ReadLine(), out int id);
            if (!isInt)
            {
                Console.WriteLine("Invalid Id. Please Enter An Integer Value.");
                goto EnterId;
            }
            
            if (!isExists(id))
            {
                Console.WriteLine("Product doesn't exist\n");
                return;
            }
            AppDbContext db = new AppDbContext();
            TblProduct product = db.TblProducts.Where(prod => prod.DeleteFlag == false).First(prod => prod.ProductId == id);
            product.DeleteFlag = true;
            int res = db.SaveChanges();
            Console.WriteLine(res > 0 ? "Product Deleted Successfully" : "Failed to Delete Product");

        }

        private bool isExists(int id)
        {
            AppDbContext db = new AppDbContext();
            TblProduct? item = db.TblProducts.Where(prod => prod.DeleteFlag == false).FirstOrDefault(prod => prod.ProductId == id);
            return item != null;
        }

        private void printTableData(TblProduct product)
        {
            
                Console.WriteLine("{0,-18} {1,-18} {2,-18}",
                    "Product Id", "Product Name", "Price");
                Console.WriteLine("{0, -18} {1, -18} {2, -18}",
                    "-------------", "-------------", "-------------");
                Console.WriteLine("{0,-18} {1,-18} {2,-18}", product.ProductId, product.ProductName, product.Price);
                Console.WriteLine();
        }

        private void printTableData(List<TblProduct> productList)
        {
            Console.WriteLine("{0,-18} {1,-18} {2,-18}",
               "Product Id", "Product Name", "Price");
            Console.WriteLine("{0, -18} {1, -18} {2, -18}",
                "-------------", "-------------", "-------------");

            productList.ForEach(row =>
                Console.WriteLine("{0,-18} {1,-18} {2,-18}", row.ProductId, row.ProductName, row.Price)
            );
            Console.WriteLine(new string('-', 53));
            Console.WriteLine();

        }
    }
}
