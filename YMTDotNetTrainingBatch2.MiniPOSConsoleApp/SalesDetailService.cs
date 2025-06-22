using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMTDotNetTrainingBatch2.Database.AppDbContextModels;
using AppDbContext = YMTDotNetTrainingBatch2.Database.AppDbContextModels.AppDbContextModels;

namespace YMTDotNetTrainingBatch2.MiniPOSConsoleApp
{
    public class SalesDetailService
    {
        public void Create()
        {
        EnterSaleId:
            Console.Write("Enter Sale Id : ");
            bool isInt = int.TryParse(Console.ReadLine(), out int saleId);
            if (!isInt)
            {
                Console.WriteLine("Invalid input. Please enter an integer value for id");
                goto EnterSaleId;
            }
        EnterProdId:
            Console.Write("Enter Product Id : ");
            isInt = int.TryParse(Console.ReadLine(), out int prodId);
            if (!isInt)
            {
                Console.WriteLine("Invalid input. Please enter an integer value for id");
                goto EnterProdId;
            }
        EnterQuantity:
            Console.Write("Enter Quantity : ");
            bool isDec = decimal.TryParse(Console.ReadLine(), out decimal quantity);
            if (!isDec)
            {
                Console.WriteLine("Invalid input. Please enter a decimal value for quantity");
                goto EnterQuantity;
            }
        EnterPrice:
            Console.Write("Enter Product Price : ");
            isDec = decimal.TryParse(Console.ReadLine(), out decimal price);
            if (!isDec)
            {
                Console.WriteLine("Invalid input. Please enter a decimal value for price");
                goto EnterPrice;
            }
            TblSalesDetail saleDetail = new TblSalesDetail()
            {
                SaleId = saleId,
                ProductId = prodId,
                Quantity = quantity,
                Price = price
            };
            AppDbContext db = new AppDbContext();
            db.Add(saleDetail);
            int res = db.SaveChanges();
            Console.WriteLine();
            Console.WriteLine(res > 0 ? "Sale Detail Created Successfully" : "Failed To Create Sale Detail");
            Console.WriteLine();

        }

        public void Read()
        {
            Console.WriteLine("Obtaining Sales Detail Table From DB");
            Console.WriteLine("------------------------------------\n");

            AppDbContext db = new AppDbContext();
            List<TblSalesDetail> sales = db.TblSalesDetails.ToList();
            Console.WriteLine();
            printTableData(sales);
        }

        public void Edit()
        {
        EnterId:
            Console.Write("Enter Sales Detail Id To View : ");
            bool isInt = int.TryParse(Console.ReadLine(), out int id);
            if (!isInt)
            {
                Console.WriteLine("Invalid Input. Please enter an integer value for id.");
                goto EnterId;
            }
            AppDbContext db = new AppDbContext();
            TblSalesDetail? saleDetail = db.TblSalesDetails.FirstOrDefault(sd => sd.SaleDetailId == id);
            if (saleDetail == null)
            {
                Console.WriteLine($"Sale detail with id : {id} do not exist.");
                return;
            }
            printTableData(saleDetail);
        }

        //Print table data for only 1 row
        private void printTableData(TblSalesDetail sale)
        {

            Console.WriteLine("{0,-18} {1,-18} {2,-18} {3, -18} {4, -18}",
                 "Sale Detail Id", "Sale Id", "Product Id", "Quantity", "Price");
            Console.WriteLine("{0,-18} {1,-18} {2,-18} {3, -18} {4, -18}",
        "----------", "----------", "----------", "----------", "----------");
            Console.WriteLine("{0,-18} {1,-18} {2,-18} {3, -18} {4, -18}", sale.SaleDetailId , sale.SaleId, sale.ProductId, sale.Quantity, sale.Price);
            Console.WriteLine();
        }

        //Print table data for a list of rows
        private void printTableData(List<TblSalesDetail> salesList)
        {
            Console.WriteLine("{0,-18} {1,-18} {2,-18} {3, -18} {4, -18}",
                 "Sale Detail Id", "Sale Id", "Product Id", "Quantity" , "Price");
            Console.WriteLine("{0,-18} {1,-18} {2,-18} {3, -18} {4, -18}",
        "----------", "----------", "----------", "----------", "----------");
            salesList.ForEach(row =>
            Console.WriteLine("{0,-18} {1,-18} {2,-18} {3, -18} {4, -18}", row.SaleDetailId , row.SaleId, row.ProductId, row.Quantity, row.Price)
            );
            Console.WriteLine(new string('-', 86));
            Console.WriteLine();
        }
    }
}
