using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using System.Threading.Tasks;

using LuigiiLuxury.Domain.ViewModels;
using LuigiiLuxury.Domain;
using LuigiiLuxury.Domain.Entities;
using LuigiiLuxury.Domain.Interfaces;
using LuigiiLuxury.Domain.Interfaces.Services;

namespace LuigiiLuxury.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // user
            CreateMap<LoginViewModel, User>();
            CreateMap<User, LoginViewModel>();

            CreateMap<User, RegisterViewModel>();
            CreateMap<RegisterViewModel, User>();

            CreateMap<EditUserDetailsViewModel, User>();
            CreateMap<User, EditUserDetailsViewModel>();

            CreateMap<DeleteUserViewModel, User>();
            CreateMap<User, DeleteUserViewModel>();


            // product
            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductViewModel, Product>();

            CreateMap<ProductFormViewModel, Product>();
            CreateMap<Product, ProductFormViewModel>();


            // brand
            CreateMap<Brand, BrandViewModel>();
            CreateMap<BrandViewModel, Brand>();

            CreateMap<Brand, BrandFormViewModel>();
            CreateMap<BrandFormViewModel, Brand>();


            // role
            CreateMap<Role, RoleViewModel>();
            CreateMap<RoleViewModel, Role>();

            CreateMap<RoleFormViewModel, Role>();
            CreateMap<Role, RoleFormViewModel>();


            // order
            CreateMap<OrderViewModel, Order>();
            CreateMap<Order, OrderViewModel>();

            CreateMap<CheckoutViewModel, Order>();
            CreateMap<Order, CheckoutViewModel>();

            CreateMap<Order, SetStatusViewModel>();
            CreateMap<SetStatusViewModel, Order>();


            // order details
            CreateMap<OrderDetailsViewModel, OrderDetails>();
            CreateMap<OrderDetails, OrderDetailsViewModel>();

            CreateMap<OrderDetailsFormViewModel, OrderDetails>();
            CreateMap<OrderDetails, OrderDetailsFormViewModel>();


            // country
            CreateMap<CountryViewModel, Country>();
            CreateMap<Country, CountryViewModel>();

            CreateMap<CountryFormViewModel, Country>();
            CreateMap<Country, CountryFormViewModel>();


            // availibility status
            CreateMap<AvailabilityStatus, AvailabilityStatusViewModel>();
            CreateMap<AvailabilityStatusViewModel, AvailabilityStatus>();

            CreateMap<AvailabilityStatus, AvailabilityStatusFormViewModel>();
            CreateMap<AvailabilityStatusFormViewModel, AvailabilityStatus>();
        }
    }
}
