using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilterPageDemo
{
    public class ApplicationDbContext : DbContext
    {
        // Khai báo DbSet cho các entity mà bạn muốn ánh xạ với cơ sở dữ liệu
        public DbSet<Product> Products { get; set; }

        // Khởi tạo DbContext với các thiết lập cơ sở dữ liệu
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Tùy chọn: Override phương thức OnModelCreating nếu bạn muốn cấu hình thêm về entity mappings
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

}
