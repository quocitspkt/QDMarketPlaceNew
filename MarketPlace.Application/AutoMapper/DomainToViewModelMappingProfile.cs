using AutoMapper;
using MarketPlace.Application.ViewModels.Product;
using MarketPlace.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlace.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ProductCategory, ProductCategoryViewModel>();
        }
        
    }
}
