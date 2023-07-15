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
    public interface IUsersService : IService<UserViewModel>
    {
        UserViewModel Login(LoginViewModel loginForm);
        void Register(RegisterViewModel registerForm);


        void Update(int id, UserFormViewModel userForm);
        void ChangePassword(ChangePasswordFormViewModel changePasswordForm);
        void SetRole(SetRoleFormViewModel setRoleForm);


        bool IsExistingInDatabase<T>(T identity);
        bool IsAdmin(UserViewModel user);
        bool IsEmailRegistered(string email);
        bool IsValidPassword(string email, string password);


        IEnumerable<UserViewModel> GetByRole(string roleCode);
        string GetFullName(int userId);
        UserViewModel GetByEmailAndPassword(string email, string password);
        UserViewModel GetByEmail(string email);
    }
}
