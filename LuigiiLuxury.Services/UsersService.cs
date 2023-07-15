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
    public class UsersService : IUsersService
    {
        public readonly IUnitOfWork _unitOfWork;
        public IMapper _mapper;

        public UsersService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = MapperExtension.CreateMapper();
        }

        #region login & register methods
        public UserViewModel Login(LoginViewModel loginForm)
        {
            var user = this.GetAll().SingleOrDefault(u => u.Email == loginForm.Email);

            if (user != null)
            {
                if (user.Password == MD5HashGenerator.GenerateMD5Hash(loginForm.Password))
                    return user;
            }

            return null;
        }

        public void Register(RegisterViewModel registerForm)
        {
            var user = this.GetAll().SingleOrDefault(u => u.Email == registerForm.Email);

            if (user == null)
            {
                if (registerForm.FirstName != null
                    && registerForm.LastName != null
                    && registerForm.Email != null
                    && registerForm.Password != null
                    )
                {
                    var entity = new User
                    {
                        FirstName = registerForm.FirstName,
                        LastName = registerForm.LastName,
                        Email = registerForm.Email,
                        Password = MD5HashGenerator.GenerateMD5Hash(registerForm.Password),
                        CreatedAt = DateTime.Now,
                        RoleCode = "customer"
                    };

                    _unitOfWork.Users.Add(entity);
                    _unitOfWork.Complete();
                }
            }
        }
        #endregion


        #region Update & delete methods
        public void SetRole(SetRoleFormViewModel setRoleForm)
        {
            var user = this.Get(setRoleForm.UserId);

            if (user != null)
            {
                var entity = _unitOfWork.Users.Get(user.Id);
                entity.RoleCode = setRoleForm.Role.Code;

                _unitOfWork.Complete();
            }
        }

        public void Delete<T>(T ientity)
        {
            var user = this.Get(ientity);

            if (user != null)
            {
                var entity = _unitOfWork.Users.Get(user.Id);
                entity.IsDeleted = true;

                _unitOfWork.Complete();
            }
        }

        public void Update(int id, UserFormViewModel userForm)
        {
            var user = this.Get(id);

            if (user != null)
            {
                var entity = _unitOfWork.Users.Get(user.Id);

                entity.FirstName = userForm.FirstName;
                entity.LastName = userForm.LastName;
                entity.PhoneNumber = userForm.PhoneNumber;
                entity.Address = userForm.Address;
                entity.City = userForm.City;
                entity.UpdatedAt = DateTime.Now;

                _unitOfWork.Complete();
            }
        }

        public void ChangePassword(ChangePasswordFormViewModel changePasswordForm)
        {
            var user = this.Get(changePasswordForm.Id);

            if (user != null)
            {
                if (MD5HashGenerator.GenerateMD5Hash(changePasswordForm.CurrentPassword) == user.Password)
                {
                    var entity = _unitOfWork.Users.Get(user.Id);

                    entity.Password = MD5HashGenerator.GenerateMD5Hash(changePasswordForm.Password);
                    entity.UpdatedAt = DateTime.Now;

                    _unitOfWork.Complete();
                }
            }
        }
        #endregion


        #region Get methods
        public UserViewModel Get<T>(T identity)
        {
            var entity = _unitOfWork.Users.Get(identity);

            if (entity.IsDeleted == false)
            {
                if (entity != null)
                {
                    var user = _mapper.Map<User, UserViewModel>(entity);

                    return user;
                }
            }

            return null;
        }

        public IEnumerable<UserViewModel> GetAll()
        {
            var entities = _unitOfWork.Users.GetAll().Where(e => e.IsDeleted == false);

            if (entities != null)
            {
                var users = _mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(entities);

                return users;
            }

            return null;
        }

        public IEnumerable<UserViewModel> GetByRole(string roleCode)
        {
            var users = this.GetAll().Where(u => u.RoleCode == roleCode);

            return users;
        }

        public string GetFullName(int userId)
        {

            if (IsExistingInDatabase(userId))
            {
                var user = this.Get(userId);
                var fullName = user.FirstName + " " + user.LastName;

                return fullName;
            }

            return String.Empty;
        }

        public UserViewModel GetByEmailAndPassword(string email, string password)
        {
            string passwordHash = MD5HashGenerator.GenerateMD5Hash(password);
            var user = this.GetAll().SingleOrDefault(m => m.Email == email && m.Password == passwordHash);

            if (user != null)
                return user;

            return null;
        }

        public UserViewModel GetByEmail(string email)
        {
            var user = this.GetAll().SingleOrDefault(m => m.Email == email);

            if (user != null)
                return user;

            return null;
        }

        #endregion


        #region Check methods
        public bool IsExistingInDatabase(string email)
        {
            var user = this.GetAll().SingleOrDefault(u => u.Email == email);

            if (user == null)
                return false;
            return true;
        }

        public bool IsAdmin(UserViewModel user)
        {
            if (user.RoleCode == "admin")
                return true;

            return false;
        }

        public bool IsEmailRegistered(string email)
        {
            var user = this.GetByEmail(email);

            if (user == null)
                return false;
            return true;
        }

        public bool IsValidPassword(string email, string password)
        {
            var entity = this.GetByEmail(email);

            if (entity.Password == MD5HashGenerator.GenerateMD5Hash(password))
                return true;
            return false;
        }

        public bool IsExistingInDatabase<T>(T identity)
        {
            var objectFound = this.Get(identity);

            if (objectFound != null)
                return true;
            return false;
        }
        #endregion
    }
}

