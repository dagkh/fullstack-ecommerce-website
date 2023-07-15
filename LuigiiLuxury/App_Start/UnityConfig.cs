using System;
using System.Web.Mvc;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;

using Unity;
using Unity.Mvc5;
using Unity.WebApi;

using LuigiiLuxury.Domain.Interfaces;
using LuigiiLuxury.Domain.Interfaces.Services;
using LuigiiLuxury.Domain.Interfaces.Repositories;
using LuigiiLuxury.Infrastructure.Repositories;
using LuigiiLuxury.Infrastructure;
using LuigiiLuxury.Services;

namespace LuigiiLuxury
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // Services
            container.RegisterType<IBrandsService, BrandsService>();
            container.RegisterType<IAvailabilityStatusService, AvailabilityStatusService>();
            container.RegisterType<ICountriesService, CountriesService>();
            container.RegisterType<IOrderDetailsService, OrderDetailsService>();
            container.RegisterType<IOrdersService, OrdersService>();
            container.RegisterType<IProductsService, ProductsService>();
            container.RegisterType<IRolesService, RolesService>();
            container.RegisterType<IUsersService, UsersService>();
            container.RegisterType<IOrderStatusService, OrderStatusService>();
            container.RegisterType<ICartService, CartService>();

            // Unit Of Work
            container.RegisterType<IUnitOfWork, UnitOfWork>();

            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}