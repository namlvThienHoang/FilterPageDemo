using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FilterPageDemo
{
    public class PagingParams<TDto>
    {
        public int Page { get; set; } = 1; // Trang hiện tại
        public int ItemsPerPage { get; set; } = 10; // Số lượng mục trên mỗi trang
        public string SortBy { get; set; } // Cột sắp xếp
        public string SortExpression { get; set; } // Biểu thức sắp xếp

        // Lấy các biểu thức lọc từ PagingParams
        public IEnumerable<Expression<Func<TDto, bool>>> GetPredicates()
        {
            // Trả về các predicate nếu có
            return new List<Expression<Func<TDto, bool>>>();
        }
    }

}
