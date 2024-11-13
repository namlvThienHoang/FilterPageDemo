using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilterPageDemo
{
    public class PagingResult<TDto>
    {
        public int TotalRows { get; set; } // Tổng số bản ghi trong cơ sở dữ liệu
        public int PageSize { get; set; }  // Số lượng mục trên mỗi trang
        public int CurrentPage { get; set; } // Trang hiện tại
        public List<TDto> Data { get; set; } // Dữ liệu của trang hiện tại (các đối tượng DTO)
    }

}
