using AutoMapper;
using BootcampFinalProject.Application.Features.Commands.Authentications;
using BootcampFinalProject.Application.Features.Commands.CategoryCommands.CreateCategory;
using BootcampFinalProject.Application.Features.Commands.OfferCommands;
using BootcampFinalProject.Application.Features.Queries.CategoryQueries.GetAllCategories;
using BootcampFinalProject.Application.Features.Queries.CategoryQueries.GetByIdCategory;
using BootcampFinalProject.Application.Features.Queries.CategoryQueries.SearchCategory;
using BootcampFinalProject.Application.Features.Queries.OfferQueries.GetByProductIdOffer;
using BootcampFinalProject.Application.Features.Queries.OfferQueries.GetByUserIdOffer;
using BootcampFinalProject.Application.Features.Queries.ProductQueries.GetByIdProduct;
using BootcampFinalProject.Application.Features.Queries.ProductQueries.SearchProduct;
using BootcampFinalProject.Application.Models;
using BootcampFinalProject.Domain.Entities;
using BootcampFinalProject.Domain.Entities.Authentications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampFinalProject.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Authentications

            //CreateMap<User, SignUpUserCommand>().ReverseMap();
            //CreateMap<User, UserViewModel>().ReverseMap();

            #endregion

            #region Category

            CreateMap<Category, CreateCategoryCommandRequest>().ReverseMap();

            CreateMap<Category, GetAllCategoriesQueryResponse>().ReverseMap();
            CreateMap<Category, GetAllCategoriesQueryResponse>();

            CreateMap<Category, SearchCategoryQueryResponse>();
            CreateMap<Category, SearchCategoryQueryResponse>().ReverseMap();

            CreateMap<Category, GetByIdCategoryQueryResponse>();

            #endregion 

            CreateMap<Offer, CreateOfferCommandRequest>().ReverseMap();

            CreateMap<Offer, GetByProductIdOfferQueryResponse>().ReverseMap();
            CreateMap<Offer, GetByUserIdOfferQueryResponse>().ReverseMap();

            CreateMap<Product, SearchProductQueryResponse>();
            CreateMap<Product, SearchProductQueryResponse>().ReverseMap();

            CreateMap<Product, GetByIdProductQueryResponse>().ReverseMap();
            CreateMap<GetByIdProductQueryResponse, Product>().ReverseMap();

           

        }
    }
}
