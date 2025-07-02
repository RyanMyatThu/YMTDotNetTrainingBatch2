using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMTDotNetTrainingBatch2.Database.AppDbContextModels;
using YMTDotNetTrainingBatch2.Domain.Features;
using YMTDotNetTrainingBatch2.Domain.Features.ProductService;
using YMTDotNetTrainingBatch2.Domain.Features.SalesService;
namespace YMTDotNetTrainingBatch2.MiniPOSConsoleApp
{
    public class SaleUI
    {
        public void Show()
        {
        Menu:
            Console.WriteLine("\nThis Is Sales Menu");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("\n1. New Sale");
            Console.WriteLine("2. List all sales");
            Console.WriteLine("3. View sale detail");
            Console.WriteLine("4. Exit");
            Console.WriteLine("--------------------------------");

            Console.Write("\nChoose menu : ");
            bool isInt = int.TryParse(Console.ReadLine(), out int no);
            if (!isInt)
            {
                Console.WriteLine("Invalid input. Please choose a number between 1 and 4");
                goto Menu;
            }
            EnumSaleMenu menu = (EnumSaleMenu)no;

            switch (menu)
            {
                
                case EnumSaleMenu.NewSale:
                    NewSale();
                    break;
                case EnumSaleMenu.ListSales:
                    break;
                case EnumSaleMenu.Exit:
                    goto End;
                case EnumSaleMenu.None:
                case EnumSaleMenu.ViewSaleDetail:
                    break;
            }

            Console.WriteLine("--------------------------------");
            goto Menu;
        End:
            Console.WriteLine("\nExiting Sale Menu");

        }

        public void NewSale()
        {
            List<TblSalesDetail> products = new List<TblSalesDetail>();
            Console.WriteLine("\nCreating a new sale");
            Console.WriteLine("--------------------------------");
        EnterId:
            Console.Write("Enter product id : ");
            bool isInt = int.TryParse(Console.ReadLine(), out int id);
            if (!isInt)
            {
                Console.WriteLine("Invalid Id Input. Please Enter An Integer Value.");
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
        EnterQuantity:
            Console.Write("Enter quantity : ");
            bool isDecimal = decimal.TryParse(Console.ReadLine(), out decimal quantity);
            if (!isDecimal) {
                Console.WriteLine("Invalid quantity input. Please enter a decimal value");
                goto EnterQuantity;
            }
            products.Add(new TblSalesDetail()
            {
                ProductId = id,
                Quantity = quantity,
                Price = product.Price,
            });

            Console.WriteLine("Are you sure you want to add more? Y/N");
            string response = Console.ReadLine()!;
            
            if(response != null && response.ToUpper().Equals("Y"))
            {
                goto EnterId;
            }

            SalesService salesService = new SalesService();
            int result = salesService.Sale(products);
            Console.WriteLine(result > 0 ? "\nSale added successfully\n" : "\nFailed to add sale\n");
            Console.WriteLine("--------------------------------");




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
        #endregion


    }

    enum EnumSaleMenu
        {
            None,
            NewSale,
            ListSales,
            ViewSaleDetail,
            Exit
        }
    
}
