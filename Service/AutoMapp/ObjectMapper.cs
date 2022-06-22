using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.AutoMapp
{
    public static class ObjectMapper
    {
        // Lazy loading sadece ben çağırdığımda yüklensin mermory'e ancak o zaman geçsin.
        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>( () =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                // Birden fazla Mapper sınıfımız olduğunda bu şekilde ekleyebiliyoruz.
                cfg.AddProfile<DtoMapper>();
            });
            return config.CreateMapper();


        });

        public static IMapper Mapper => lazy.Value;
    }
}
