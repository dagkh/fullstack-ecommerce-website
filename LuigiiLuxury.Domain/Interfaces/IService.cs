using System.Collections.Generic;

namespace LuigiiLuxury.Services.IServices
{
    public interface IService<TViewModel> where TViewModel : class
    {
        TViewModel Get<T>(T identity);
        IEnumerable<TViewModel> GetAll();
        void Delete<T>(T identity);
    }
}
