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

    public List<TblSalesDetail> GetSaleDetails()
    {
        AppDbContext db = new AppDbContext();
        List<TblSalesDetail> saleDetails = db.TblSalesDetails.ToList();
        return saleDetails;
    }

    public List<TblSalesSummary> GetSaleSummaries()
    {
        AppDbContext db = new AppDbContext();
        List<TblSalesSummary> salesSummaries = db.TblSalesSummaries.ToList();
        return salesSummaries;
    }

    public List<TblSalesDetail> FindSaleDetail(int saleId)
    {
        AppDbContext db = new AppDbContext();
        List<TblSalesDetail> saleDetails = db.TblSalesDetails.Where(sale => sale.SaleId == saleId).ToList();
        return saleDetails;

    }

    public TblSalesSummary? FindSaleSummary(int saleId) {
        AppDbContext db = new AppDbContext();
        TblSalesSummary? saleSummary = db.TblSalesSummaries.FirstOrDefault(sale => sale.SaleId == saleId);
        return saleSummary;
    }

    

}
