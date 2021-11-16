using AutoMapper;
using Hogwarts.Domain.Entity;
using Hogwarts.Domain.Model.Home;
using Hogwarts.Domain.Model.RequestLogin;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hogwarts.Domain.Mapper
{
    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<SeapolDtoMapper>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });
        public static IMapper Mapper => Lazy.Value;
    }

    public class SeapolDtoMapper : Profile
    {
        public SeapolDtoMapper()
        {
            /**
             * Trim all strings
             * */
            CreateMap<string, string>()
                .ConvertUsing(str => (str ?? "").Trim());

            /**
             * Models
             * */
            CreateMap<RequestLogin, RequestLoginModel>()
                .ReverseMap();
            CreateMap<Home, HomeModel>()
                .ReverseMap();
         
            /**
             * DTOs
             * */
            CreateMap<RequestLogin, CreateRequestLoginDto>()
                .ReverseMap();
            CreateMap<RequestLogin, UpdateRequestLoginDto>()
                .ReverseMap();
        }
    }
}

