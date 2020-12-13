using AutoMapper;
using MarketPlace.Application.ViewModels.Product;
using MarketPlace.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlace.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProductCategoryViewModel, ProductCategory>().ConstructUsing(c => new ProductCategory(c.Name,c.Description,
                c.ParentId,c.HomeOrder,c.HomeFlag,c.SeoPageTitle,c.SeoAlias,c.SeoKeyWord,c.SeoDescription,c.Status,
                c.DateCreated,c.DateModified,c.SortOrder));
        }
    }
}
