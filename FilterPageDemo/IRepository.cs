using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FilterPageDemo
{
    public interface IRepository
    {
        IQueryable<TEntity> Filter<TEntity>() where TEntity : class;
        Task<PagingResult<TDto>> FilterPagedAsync<TEntity, TDto>(PagingParams<TDto> pagingParams, params Expression<Func<TDto, bool>>[] predicates)
    where TEntity : class;
    }

}
