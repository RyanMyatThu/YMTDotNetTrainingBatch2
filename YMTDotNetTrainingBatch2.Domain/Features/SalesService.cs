using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMTDotNetTrainingBatch2.Database.AppDbContextModels;
using AppDbContext = YMTDotNetTrainingBatch2.Database.AppDbContextModels.AppDbContextModels;

namespace YMTDotNetTrainingBatch2.Domain.Features.SalesService;

public class SalesService
{
    public int Sale(List<TblSalesDetail> products)
    {
        AppDbContext db = new AppDbContext();
        TblSalesSummary salesSummary = new TblSalesSummary()
        {
            Date = DateTime.Now,
            VoucherId = Guid.NewGuid().ToString(),
            TotalAmount = products.Sum(prod => prod.Quantity * prod.Price)
        };
        db.TblSalesSummaries.Add(salesSummary);
        db.SaveChanges();

        foreach(TblSalesDetail product in products)
        {
            product.SaleId = salesSummary.SaleId;
        }

        db.TblSalesDetails.AddRange(products);  
        int result = db.SaveChanges();
        return result;
    }

}
