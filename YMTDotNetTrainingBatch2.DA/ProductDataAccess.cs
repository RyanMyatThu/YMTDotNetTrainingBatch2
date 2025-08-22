using Microsoft.EntityFrameworkCore;
using YMTDotNetTrainingBatch2.DB.AppDbContextModels;

namespace YMTDotNetTrainingBatch2.DA
{
    public class ProductDataAccess
    {
        private readonly AppDbContext _db;
        public ProductDataAccess(AppDbContext db)
        {
            _db = db;
        }
        public async Task<List<TblProduct>> GetProductsAsync(int pageNo, int pageSize) {
            return await _db.TblProducts
                         .Where(x => !x.DeleteFlag)
                         .Skip((pageNo - 1) * pageSize)
                         .Take(pageSize)
                         .ToListAsync();
        }

        public async Task<int> CreateProductAsync(TblProduct newProduct)
        {
            await _db.TblProducts.AddAsync(newProduct);
            var result = await _db.SaveChangesAsync();
            return result;

        }

        public async Task<int> UpdateProductAsync(int id, TblProduct newProduct)
        {
            var item = await _db.TblProducts.FirstOrDefaultAsync(x => !x.DeleteFlag && x.ProductId == id); 
            if(item is null)
            {
                throw new Exception("Product not found");
            }
            item.ProductName = newProduct.ProductName;
            item.Price = newProduct.Price;

            var result = await _db.SaveChangesAsync();
            return result;
        }

        public async Task<int> DeleteProductAsync(int id)
        {
            var item = await _db.TblProducts.FirstOrDefaultAsync(x => !x.DeleteFlag && x.ProductId == id);
            if (item is null)
            {
                throw new Exception("Product not found");
            }
            item.DeleteFlag = true;
            int res = await _db.SaveChangesAsync();
            return res;
        }

    }
}
