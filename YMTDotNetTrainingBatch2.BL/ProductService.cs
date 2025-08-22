using YMTDotNetTrainingBatch2.DA;
using YMTDotNetTrainingBatch2.DB.AppDbContextModels;

namespace YMTDotNetTrainingBatch2.BL
{
    public class ProductService
    {
        private readonly ProductDataAccess _productDataAcess;
        public ProductService(ProductDataAccess productDataAccess)
        {
            _productDataAcess = productDataAccess;
        }

        public async Task<List<TblProduct>> GetProductsAsync(int pageNo, int pageSize)
        {
            if (pageNo == 0)
            {
                throw new Exception("Page number cannot be zero");
            }
            if (pageSize == 0)
            {
                throw new Exception("Page size cannot be zero");
            }
            return await _productDataAcess.GetProductsAsync(pageNo, pageSize);
        }

        public async Task<int> CreateProductAsync(TblProduct newProduct)
        {
            int result = await _productDataAcess.CreateProductAsync(newProduct);
            return result;
        }

        public async Task<int> UpdateProductAsync(int id, TblProduct updatedProduct)
        {
            if (id == 0)
            {
                throw new Exception("Invalid Product ID");
            }
            int res = await _productDataAcess.UpdateProductAsync(id, updatedProduct);
            return res;


        }

        public async Task<int> DeleteProductAsync(int id)
        {
            int res = await _productDataAcess.DeleteProductAsync(id);
            return res; 
        }
    }
}
