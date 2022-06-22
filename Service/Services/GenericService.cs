using Core.Entities;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories;
using Service.AutoMapp;
using SharedLibrary.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class GenericService<TEntity, TDto> : IGenericService<TEntity, TDto> where TEntity : class where TDto : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<TEntity> _genericRepository;

        public GenericService(IUnitOfWork unitOfWork, IGenericRepository<TEntity> genericRepository)
        {
            _unitOfWork = unitOfWork;
            _genericRepository = genericRepository;
        }

        public async Task<ResponseDto<TDto>> AddAsync(TDto entity)
        {
            var newEntity = ObjectMapper.Mapper.Map<TEntity>(entity);

            await _genericRepository.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();
            var newDto = ObjectMapper.Mapper.Map<TDto>(newEntity);
            return ResponseDto<TDto>.Success(newDto, 200);
        }

        public async Task<ResponseDto<IQueryable<TDto>>> GetAllAsync()
        {
            var products = ObjectMapper.Mapper.Map<List<TDto>>(await _genericRepository.GetAllAsync()).AsQueryable();
            return ResponseDto<IQueryable<TDto>>.Success(products,200);

        }

        public async Task<ResponseDto<TDto>> GetByIdAsync(int id)
        {
            var product = await _genericRepository.GetByIdAsync(id);
            if (product ==null)
            {
                return ResponseDto<TDto>.Fail("id not found",404,true);
            }
            var newObject = ObjectMapper.Mapper.Map<TDto>(product);

            return ResponseDto<TDto>.Success(newObject, 200);
        }

        public async Task<ResponseDto<NoDataDto>> Remove(int id)
        {
            var product = await _genericRepository.GetByIdAsync(id);

            if (product == null)
            {
                
                return ResponseDto<NoDataDto>.Fail("id not found",404,true);
            }

            _genericRepository.Remove(product);
            await _unitOfWork.CommitAsync();
            return ResponseDto<NoDataDto>.Success(200);

        }

        public async Task<ResponseDto<NoDataDto>> Update(TDto entity,int id)
        {
            var product = await _genericRepository.GetByIdAsync(id);

            if (product == null)
            {
                return ResponseDto<NoDataDto>.Fail("id not found",404,true);
            }
            
            var updateEntity = ObjectMapper.Mapper.Map<TEntity>(entity);
            _genericRepository.Update(updateEntity);
            await _unitOfWork.CommitAsync();
            return ResponseDto<NoDataDto>.Success(204);

            


        }


        public async Task<ResponseDto<IEnumerable<TDto>>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            var list = _genericRepository.Where(predicate);
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<TDto>>(await list.ToListAsync());
            return ResponseDto<IEnumerable<TDto>>.Success(mapped,200);
            
        }
    }
}
