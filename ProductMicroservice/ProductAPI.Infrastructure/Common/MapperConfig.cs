using AutoMapper;
using ProductAPI.ApplicationCore.Entities;
using ProductAPI.ApplicationCore.Models;

namespace ProductAPI.Infrastructure.Common;

public class MapperConfig
{
    public static Mapper InitializeAutomapper()
    {
        //Provide all the Mapping Configuration
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Product, ProductViewModel>();
           

            // Reverse Mapping
            cfg.CreateMap<ProductViewModel, Product>();
           
        });

        var mapper = new Mapper(config);
        return mapper;
    }
}