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
                    ListAllSales();
                    break;
                case EnumSaleMenu.ViewSaleDetail:
                    ListSale();
                    break;
                case EnumSaleMenu.Exit:
                    goto End;
                case EnumSaleMenu.None:
                default:
                    break;
            }

            Console.WriteLine("--------------------------------");
            goto Menu;
        End:
            Console.WriteLine("\nExiting Sale Menu");

        }

        public void ListAllSales()
        {
            Console.WriteLine("\n Obtaining Sales Data From Database");
            Console.WriteLine("--------------------------------");
            SalesService salesService = new SalesService();
            List<TblSalesDetail> salesDetails = salesService.GetSaleDetails();
            List<TblSalesSummary> saleSummaries = salesService.GetSaleSummaries();
            PrintSale(saleSummaries, salesDetails);

        }

        public void ListSale()
        {
        EnterId:
            Console.Write("Enter sale id : ");
            bool isInt = int.TryParse(Console.ReadLine(), out int id);
            if (!isInt)
            {
                Console.WriteLine("Invalid Id Input. Please Enter An Integer Value.");
                goto EnterId;
            }
            SalesService salesService = new SalesService();
            TblSalesSummary? saleSummary = salesService.FindSaleSummary(id);
            if(saleSummary == null)
            {
                Console.WriteLine($"\nSale with id : {id} doesn't exist");
                goto EnterId;
            }
            List<TblSalesDetail> saleDetails = salesService.FindSaleDetail(id);
            if(saleDetails.Count == 0)
            {
                Console.WriteLine($"\nSale with id : {id} doesn't exist");
                goto EnterId;
            }
            PrintSale(saleSummary, saleDetails);
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
            PrintTableData(product);
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

        // Print sale summary and sale detail for a given ID
        private void PrintSale(TblSalesSummary saleSummary, List<TblSalesDetail> saleDetails)
        {
            // Making sale summary table string
            string saleSummaryColumnHeader = string.Format("{0,-22} {1,-22} {2,-45} {3, 20} ", "Sale Id", "Date Of Purchase", "Voucher Id", "Total Amount");
            string underLinesForSaleSummary = string.Format("{0, -22} {1, -22} {2,-45} {3, 20}",
          "----------------", "----------------", "----------------", "----------------");
            string saleSummaryRowData = string.Format("{0, -22} {1, -22} {2,-45} {3, 20}", saleSummary.SaleId, saleSummary.Date, saleSummary.VoucherId, saleSummary.TotalAmount);

            string saleSummaryFullTable = string.Format("{0, -5}\n{1,-5}\n{2,-5}", saleSummaryColumnHeader, underLinesForSaleSummary, saleSummaryRowData);

            // Making sale detail table string
            string saleDetailColumnHeader = string.Format("{0,-18} {1,-18} {2,-18}",
                 "Product Id", "Quantity", "Price");
            string underLinesForSaleDetails = string.Format("{0,-18} {1,-18} {2,-18}",
          "----------------", "----------------", "----------------");

            string saleDetailRowData = "";
            saleDetails.ForEach(row =>
            saleDetailRowData = saleDetailRowData + string.Format("{0,-18} {1,-18} {2,-18}\n", row.ProductId, row.Quantity, row.Price)
            );

            string saleDetailsFullTable = string.Format("{0, -5}\n{1,-5}\n{2,-5}", saleDetailColumnHeader, underLinesForSaleDetails, saleDetailRowData);

            Console.WriteLine();
            Console.WriteLine("{0,-5}\n\n{1, -5}\n\n{2,-5}", saleSummaryFullTable, new string('-', 113) ,saleDetailsFullTable);
            
        }
        
        private void PrintSale(List<TblSalesSummary> saleSummaries, List<TblSalesDetail> saleDetails)
        {
            // Making sale summary table string
            string saleSummaryColumnHeader = string.Format("{0,-22} {1,-22} {2,-45} {3, 20} ", "Sale Id", "Date Of Purchase", "Voucher Id", "Total Amount");
            string underLinesForSaleSummary = string.Format("{0, -22} {1, -22} {2,-45} {3, 20}",
          "----------------", "----------------", "----------------", "----------------");
            string saleSummaryRowData = "";
            saleSummaries.ForEach(row =>
           saleSummaryRowData = saleSummaryRowData + string.Format("{0,-22} {1,-22} {2,-45} {3, 20}\n", row.SaleId, row.Date, row.VoucherId, row.TotalAmount)
           );
            string saleSummaryFullTable = string.Format("{0, -5}\n{1,-5}\n{2,-5}", saleSummaryColumnHeader, underLinesForSaleSummary, saleSummaryRowData);

            // Making sale detail table string
            string saleDetailColumnHeader = string.Format("{0,-18} {1,-18} {2,-18} {3,-18}",
               "Sale Id" , "Product Id", "Quantity", "Price");
            string underLinesForSaleDetails = string.Format("{0,-18} {1,-18} {2,-18} {3,-18}",
          "----------------", "----------------", "----------------", "----------------");
            string saleDetailRowData = "";
            saleDetails.ForEach(row =>
            saleDetailRowData = saleDetailRowData + string.Format("{0,-18} {1,-18} {2,-18} {3,-18}\n",row.SaleId , row.ProductId, row.Quantity, row.Price)
            );
            string saleDetailsFullTable = string.Format("{0, -5}\n{1,-5}\n{2,-5}", saleDetailColumnHeader, underLinesForSaleDetails, saleDetailRowData);

            Console.WriteLine();
            Console.WriteLine("{0,-5}\n\n{1, -5}\n\n{2,-5}", saleSummaryFullTable, new string('-', 113), saleDetailsFullTable);
        }

        

        
        //Print table data for 1 row for Product
        private void PrintTableData(TblProduct product)
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
