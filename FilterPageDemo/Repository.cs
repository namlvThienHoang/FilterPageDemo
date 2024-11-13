using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FilterPageDemo
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public Repository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IQueryable<TEntity> Filter<TEntity>() where TEntity : class
        {
            return _context.Set<TEntity>();
        }

        public async Task<PagingResult<TDto>> FilterPagedAsync<TEntity, TDto>(PagingParams<TDto> pagingParams, params Expression<Func<TDto, bool>>[] predicates)
    where TEntity : class
        {
            // Kiểm tra nếu pagingParams là null
            if (pagingParams == null)
            {
                throw new ArgumentNullException(nameof(pagingParams));
            }

            // Khởi tạo kết quả phân trang
            var result = new PagingResult<TDto>
            {
                PageSize = pagingParams.ItemsPerPage,
                CurrentPage = pagingParams.Page
            };

            // Truy vấn cơ sở dữ liệu
            IQueryable<TEntity> entityQuery = Filter<TEntity>();
            IQueryable<TDto> query = entityQuery.ProjectTo<TDto>(_mapper.ConfigurationProvider);

            var pagingPredicates = pagingParams.GetPredicates();
            if (pagingPredicates != null && pagingPredicates.Any())
            {
                query = query.WhereMany(pagingPredicates);
            }

            if (predicates != null && predicates.Any())
            {
                query = query.WhereMany(predicates);
            }

            result.TotalRows = await query.CountAsync();
            // Ordering
            if (pagingParams.SortExpression != null)
            {
                //if (pagingParams.SortBy == "NEWID")
                //{
                //    query = query.OrderBy(x => Guid.NewGuid());
                //}
                //else
                //{
                //    query = query.OrderBy(pagingParams.SortExpression);
                //}
                //if (pagingParams.Start > 0)
                //{
                //    query = query.Skip(pagingParams.Start);
                //}
                //// Skipping only work after ordering
                //else if (pagingParams.StartingIndex > 0)
                //{
                //    query = query.Skip(pagingParams.StartingIndex);
                //}
            }

            if (pagingParams.ItemsPerPage != -1 && pagingParams.ItemsPerPage <= 0)
            {
                pagingParams.ItemsPerPage = 100;
            }

            if (pagingParams.ItemsPerPage > 0)
            {
                query = query.Take(pagingParams.ItemsPerPage);
            }
            result.Data = await query.ToListAsync();

            return result;
        }
    }

}
