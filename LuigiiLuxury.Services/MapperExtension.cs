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
    public static class MapperExtension
    {
        private static void IgnoreUnmappedProperties(TypeMap map, IMappingExpression expr)
        {
            foreach (string proName in map.GetUnmappedPropertyNames())
            {
                if (map.SourceType.GetProperty(proName) != null)
                    expr.ForMember(proName, opt => opt.Ignore());

                if (map.DestinationType.GetProperty(proName) != null)
                    expr.ForMember(proName, opt => opt.Ignore());
            }
        }

        private static void IgnoreUnmapped(this IProfileExpression profile)
        {
            profile.ForAllMaps(IgnoreUnmappedProperties);
        }

        public static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
                cfg.IgnoreUnmapped();
            });

            IMapper mapper = config.CreateMapper();

            return mapper;
        }
    }
}
