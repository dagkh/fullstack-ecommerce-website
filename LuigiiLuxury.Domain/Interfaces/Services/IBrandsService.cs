using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LuigiiLuxury.Domain.ViewModels;
using LuigiiLuxury.Domain.Interfaces;
using LuigiiLuxury.Services.IServices;

namespace LuigiiLuxury.Domain.Interfaces.Services
{
    public interface IBrandsService : IService<BrandViewModel>
    {
        void Add(BrandFormViewModel brandForm);
        void Update(int id, BrandFormViewModel brandForm);
        string GetName(int id);
    }
}
