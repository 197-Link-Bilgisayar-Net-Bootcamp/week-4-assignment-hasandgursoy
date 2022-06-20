using SharedLibrary.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IGenericService<TEntity,TDto> where TEntity: class where TDto: class
    {
        Task<ResponseDto<TDto>> GetByIdAsync(int id);
        Task<ResponseDto<IQueryable<TEntity>>> GetAllAsync();
        Task<ResponseDto<IEnumerable<TEntity>>> Where(Expression<Func<TEntity, bool>> predicate);
        Task<ResponseDto<TDto>> AddAsync(TEntity entity);
        Task<ResponseDto<NoDataDto>> Remove(TEntity entity);
        Task<ResponseDto<NoDataDto>> Update(TEntity entity);


    }
}
