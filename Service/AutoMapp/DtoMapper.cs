using AutoMapper;
using Core.Dtos;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.AutoMapp
{
    public class DtoMapper : Profile
    {
        public DtoMapper()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<UserAppDto,UserApp>().ReverseMap();


        }
    }
}
