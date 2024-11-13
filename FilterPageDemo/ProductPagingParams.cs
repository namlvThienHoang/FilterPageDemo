using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FilterPageDemo
{
    public class ProductPagingParams : PagingParams<ProductDto>
    {
        public string Filter { get; set; }

        // Phương thức tạo mảng các biểu thức lọc dựa trên các giá trị đã được thiết lập
        public Expression<Func<ProductDto, bool>>[] GetFilters()
        {
            var filters = new List<Expression<Func<ProductDto, bool>>>();

            if (!string.IsNullOrEmpty(Filter))
            {
                filters.Add(product => product.Name.Contains(Filter));
            }

            return filters.ToArray();
        }
    }

}
