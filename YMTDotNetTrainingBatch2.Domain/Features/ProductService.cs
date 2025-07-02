using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMTDotNetTrainingBatch2.Database.AppDbContextModels;
using AppDbContext = YMTDotNetTrainingBatch2.Database.AppDbContextModels.AppDbContextModels;
namespace YMTDotNetTrainingBatch2.Domain.Features.ProductService;

public class ProductService
{
    public List<TblProduct> GetProducts()
    {
        AppDbContext db = new AppDbContext();
        List<TblProduct> products = db.TblProducts.Where(x => x.DeleteFlag == false).ToList();
        return products;
    }

    public int CreateProduct(string name, decimal price)
    {
        AppDbContext db = new AppDbContext();
        TblProduct newProduct = new TblProduct()
        {
            ProductName = name,
            Price = price,
            DeleteFlag = false,
        };
        db.TblProducts.Add(newProduct);
        int result = db.SaveChanges();
        return result;
    }



    public TblProduct? FindProduct(int id)
    {
        AppDbContext db = new AppDbContext();
        TblProduct? product = db.TblProducts.FirstOrDefault(prod => prod.ProductId == id && prod.DeleteFlag == false);
        return product;
    }

    public int UpdateProduct(int id, string updatedProductName, decimal updatedPrice)
    {
        AppDbContext db = new AppDbContext();
        TblProduct? product = db.TblProducts
            .FirstOrDefault(prod => prod.ProductId == id && prod.DeleteFlag == false);
        if (product == null) return -1;
        product.ProductName = updatedProductName;
        product.Price = updatedPrice;
        int result = db.SaveChanges();
        return result;
    }

    public int DeleteProduct(int id)
    {
        AppDbContext db = new AppDbContext();
        TblProduct? product = db.TblProducts
            .Where(prod => prod.DeleteFlag == false)
            .FirstOrDefault(prod => prod.ProductId == id);
        if (product == null) return -1;
        product.DeleteFlag = true;
        int result = db.SaveChanges();
        return result;
    }

    


}
