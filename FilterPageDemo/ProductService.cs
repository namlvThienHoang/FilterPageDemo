using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FilterPageDemo
{
    public class ProductService 
    {
        private readonly IRepository _repository;

        public ProductService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagingResult<ProductDto>> GetPagedProducts(PagingParams<ProductDto> pagingParams)
        {
            // Các điều kiện lọc bổ sung, nếu có
            Expression<Func<ProductDto, bool>>[] filters = new Expression<Func<ProductDto, bool>>[]
            {
                product => product.Price > 10, // Ví dụ lọc các sản phẩm có giá lớn hơn 10
                product => product.Name.Contains("Wine") 
            };

            // Gọi phương thức FilterPagedAsync để lấy dữ liệu phân trang
            var result = await _repository.FilterPagedAsync<Product, ProductDto>(pagingParams, filters);

            return result;
        }

        public List<Product> GetProducts()
        {

            return _repository.Filter<Product>().ToList();

        }
    }

}
