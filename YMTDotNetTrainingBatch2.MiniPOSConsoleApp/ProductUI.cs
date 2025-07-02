using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMTDotNetTrainingBatch2.Database.AppDbContextModels;
using YMTDotNetTrainingBatch2.Domain.Features;
using YMTDotNetTrainingBatch2.Domain.Features.ProductService;
namespace YMTDotNetTrainingBatch2.MiniPOSConsoleApp

    //Note have to change ProdService after updating other services!!! ***
{
    public class ProductUI
    {
        public void Read()
        {
            Console.WriteLine("\nObtaining Product Table From DB");
            Console.WriteLine("-------------------------------\n");
            ProductService productService = new ProductService();
            List<TblProduct> products = productService.GetProducts();
            printTableData(products);
        }

        public void Create()
        {
            Console.WriteLine("\nCreating a new Product");
            Console.WriteLine("-----------------------");
            Console.Write("\nEnter a product name : ");
            string productName = Console.ReadLine()!;
        EnterPrice:
            Console.Write("\nEnter the price for the product : ");
            bool isDecimal = decimal.TryParse(Console.ReadLine(), out decimal price);
            if (!isDecimal)
            {
                Console.WriteLine("Invalid input. Please enter a decimal value");
                goto EnterPrice;
            };

            ProductService productService = new ProductService();
            int result = productService.CreateProduct(productName, price);
            Console.WriteLine(result > 0 ? "Successfully added new product" : "Failed to add new product");
        }

        public void Edit()
        {
        EnterId:
            Console.Write("\nEnter Product Id To View : ");
            bool isInt = int.TryParse(Console.ReadLine(), out int id);
            if (!isInt)
            {
                Console.WriteLine("Invalid Id. Please Enter An Integer Value.");
                goto EnterId;
            }
            ProductService productService = new ProductService();
            TblProduct? product = productService.FindProduct(id);
            if(product == null)
            {
                Console.WriteLine($"Product with id : {id} doesn't exist");
                goto EnterId;
            }
            printTableData(product);
        }

        public void Update()
        {
        EnterId:
            Console.Write("\nEnter Product Id To Update : ");
            bool isInt = int.TryParse(Console.ReadLine(), out int id);
            if (!isInt)
            {
                Console.WriteLine("Invalid Id. Please Enter An Integer Value.");
                goto EnterId;
            }
            ProductService productService = new ProductService();
            TblProduct? product = productService.FindProduct(id);
            if (product == null) {
                Console.WriteLine($"Product with id : {id} doesn't exist");
                goto EnterId;
            }
            printTableData(product);
            Console.Write("Enter New Product Name : ");
            string newProductName = Console.ReadLine()!;
        EnterPrice:
            Console.Write("Enter New Product Price : ");
            bool isDec = decimal.TryParse(Console.ReadLine(), out decimal newPrice);
            if (!isDec)
            {
                Console.WriteLine("Invalid Price Input. Please Enter A Decimal Value.");
                goto EnterPrice;
            }
          int result =  productService.UpdateProduct(id, newProductName, newPrice);
            Console.WriteLine(result > 0 ? "Product updated successfully" : "Failed to update product");

        }

        public void Delete()
        {
        EnterId:
            Console.Write("\nEnter Product Id To Delete : ");
            bool isInt = int.TryParse(Console.ReadLine(), out int id);
            if (!isInt)
            {
                Console.WriteLine("Invalid Id. Please Enter An Integer Value.");
                goto EnterId;
            }
            ProductService productService = new ProductService();
            TblProduct? product = productService.FindProduct(id);
            if (product == null)
            {
                Console.WriteLine($"Product with id : {id} doesn't exist");
                goto EnterId;
            }
            int result = productService.DeleteProduct(id);
            Console.WriteLine(result > 0 ? "Product deleted successfully" : "Failed to delete product");
        }

        public void Show()
        {
        Menu:
            Console.WriteLine("\nThis Is Product Menu");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("\n1. Add a new product");
            Console.WriteLine("2. List all products");
            Console.WriteLine("3. View a product detail");
            Console.WriteLine("4. Update a product");
            Console.WriteLine("5. Delete a product");
            Console.WriteLine("6. Exit");
            Console.WriteLine("--------------------------------");

            Console.Write("\nChoose menu : ");
            bool isInt = int.TryParse(Console.ReadLine(), out int no);
            if (!isInt)
            {
                Console.WriteLine("Invalid input. Please choose a number between 1 and 6");
                goto Menu;
            }
            EnumProductMenu menu = (EnumProductMenu)no;

            switch (menu)
            {
                case EnumProductMenu.NewProduct:
                    Create();
                    break;
                case EnumProductMenu.ListProduct:
                    Read();
                    break;
                case EnumProductMenu.EditProduct:
                    Edit();
                    break;
                case EnumProductMenu.UpdateProduct:
                    Update();
                    break;
                case EnumProductMenu.DeleteProduct:
                    Delete();
                    break;
                case EnumProductMenu.Exit:
                    goto End;
                case EnumProductMenu.None:
                default:
                    Console.WriteLine("Invalid input. Please choose a number between 1 and 6");
                    goto Menu;
            }

            Console.WriteLine("--------------------------------");
            goto Menu;


        End:
            Console.WriteLine("\nExiting Product Menu");
        }

        #region Print Table Data With Table Format
        //Print table data for 1 row
        private void printTableData(TblProduct product)
        {

            Console.WriteLine("{0,-18} {1,-18} {2,-18}",
                "Product Id", "Product Name", "Price");
            Console.WriteLine("{0, -18} {1, -18} {2, -18}",
                "-------------", "-------------", "-------------");
            Console.WriteLine("{0,-18} {1,-18} {2,-18}", product.ProductId, product.ProductName, product.Price);
            Console.WriteLine();
        }
        //Print table data for a list of rows
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
        #endregion

        public enum EnumProductMenu
        {
            None,
            NewProduct,
            ListProduct,
            EditProduct,
            UpdateProduct,
            DeleteProduct,
            Exit
        }

    }
}
