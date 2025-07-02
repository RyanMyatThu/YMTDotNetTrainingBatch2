using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using YMTDotNetTrainingBatch2.Database.AppDbContextModels;
using AppDbContext = YMTDotNetTrainingBatch2.Database.AppDbContextModels.AppDbContextModels;

namespace YMTDotNetTrainingBatch2.MiniPOSConsoleApp
{
    public class SalesService
    {
        public void Create()
        {
        EnterDate:
            Console.Write("\nEnter Date Of Purchase (MM/DD/YYYY) : ");
            bool isDate = DateTime.TryParse(Console.ReadLine(), out DateTime saleDate);
            if (!isDate)
            {
                Console.WriteLine("Invalid Format. Please enter the date with the following format : (MM/DD/YYYYY)");
                goto EnterDate;
            }
            Console.Write("Enter Voucher Id (V001, V002, ...) : ");
            string voucherId = Console.ReadLine()!;
            Console.Write("Enter Total Amount Of Purchase : ");
        EnterTotalAmt:
            bool isDec = decimal.TryParse(Console.ReadLine(), out decimal totalAmt);
            if (!isDec)
            {
                Console.WriteLine("Invalid Input. Please enter the total amount as a decimal value");
                goto EnterTotalAmt;
            }

            TblSalesSummary sale = new TblSalesSummary()
            {
                Date = saleDate,
                VoucherId = voucherId,
                TotalAmount = totalAmt
            };
            AppDbContext db = new AppDbContext();
            db.Add(sale);
            int res = db.SaveChanges();
            Console.WriteLine();
            Console.WriteLine(res > 0 ? "Sale Created Successfully" : "Failed To Create Sale Summary");
            Console.WriteLine();
        }

        public void Read()
        {
            Console.WriteLine("\nObtaining Sales Summary Table From DB");
            Console.WriteLine("-------------------------------------\n");

            AppDbContext db = new AppDbContext();
            List<TblSalesSummary> sales = db.TblSalesSummaries.ToList();
            Console.WriteLine();
            printTableData(sales);
        }

        public void Edit()
        {
        EnterId:
            Console.Write("\nEnter Sales Id To View : ");
            bool isInt = int.TryParse(Console.ReadLine(), out int id);
            if (!isInt) {
                Console.WriteLine("Invalid Input. Please enter an integer value for id.");
                goto EnterId;
            }
            AppDbContext db = new AppDbContext();
            TblSalesSummary? sale = db.TblSalesSummaries.FirstOrDefault(prod => prod.SaleId == id);
            if(sale == null)
            {
                Console.WriteLine($"Sale summary with id : {id} do not exist.");
                return;
            }
            Console.WriteLine();
            printTableData(sale);

        }

        public void Execute()
        {
        Menu:
            Console.WriteLine("\nThis Is Sales Menu");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("\n1. Add a new sale summary");
            Console.WriteLine("2. List all sales");
            Console.WriteLine("3. View a sale summary");
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
                case EnumSaleMenu.CreateSale:
                    Create();
                    break;
                case EnumSaleMenu.ReadSales:
                    Read();
                    break;
                case EnumSaleMenu.ViewSale:
                    Edit();
                    break;
                case EnumSaleMenu.Exit:
                    goto End;
                case EnumSaleMenu.None:
                default:
                    Console.WriteLine("Invalid input. Please choose a number between 1 and 4");
                    goto Menu;

            }
            Console.WriteLine("--------------------------------");
            goto Menu;

        End:
            Console.WriteLine("Exiting Sale Menu..");
        }

        //Print table data for only 1 row
        private void printTableData(TblSalesSummary sale)
        {

            Console.WriteLine("{0,-22} {1,-22} {2,20} {3, 20}",
                 "Sale Id", "Date Of Purchase", "Voucher Id", "Total Amount");
            Console.WriteLine("{0, -22} {1, -22} {2, 20} {3, 20}",
          "----------------", "----------------", "----------------", "----------------");
            Console.WriteLine("{0, -22} {1, -22} {2, 20} {3, 20}", sale.SaleId, sale.Date, sale.VoucherId, sale.TotalAmount);
            Console.WriteLine();
        }

        //Print table data for a list of rows
        private void printTableData(List<TblSalesSummary> salesList)
        {
            Console.WriteLine("{0,-22} {1,-22} {2,20} {3, 20}",
                "Sale Id", "Date Of Purchase", "Voucher Id", "Total Amount");
            Console.WriteLine("{0, -22} {1, -22} {2, 20} {3, 20}",
          "----------------", "----------------", "----------------", "----------------");
            salesList.ForEach(row =>
            Console.WriteLine("{0, -22} {1, -22} {2, 20} {3, 20}", row.SaleId, row.Date, row.VoucherId, row.TotalAmount)
            );
            Console.WriteLine(new string('-',87));
            Console.WriteLine();
        }

        public enum EnumSaleMenu
        {
            None,
            CreateSale,
            ReadSales,
            ViewSale,
            Exit
        }
    }
}
