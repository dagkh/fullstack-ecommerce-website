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
    public class RolesService : IRolesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public RolesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = MapperExtension.CreateMapper();
        }

        public RoleViewModel Get<T>(T id)
        {
            var entity = _unitOfWork.Roles.Get(id);

            if (entity != null)
            {
                var viewModel = _mapper.Map<Role, RoleViewModel>(entity);

                return viewModel;
            }
            else
                return null;
        }

        bool IsExistingInDatabase<T>(T code)
        {
            var viewModel = Get(code);

            if (viewModel == null)
                return false;
            return true;
        }

        public IEnumerable<RoleViewModel> GetAll()
        {
            var entities = _unitOfWork.Roles.GetAll();

            if (entities != null)
            {
                var viewModels = _mapper.Map<IEnumerable<Role>, IEnumerable<RoleViewModel>>(entities);

                return viewModels;
            }
            else
                return null;
        }

        public void Remove(RoleViewModel viewModel)
        {
            if (IsExistingInDatabase(viewModel.Code))
            {
                var entity = _unitOfWork.Roles.Get(viewModel.Code);

                _unitOfWork.Roles.Delete(entity);
                _unitOfWork.Complete();
            }
        }

        public void Add(RoleFormViewModel form)
        {
            if (form.Code != null && form.Name != null)
            {
                var entity = _mapper.Map<RoleFormViewModel, Role>(form);

                _unitOfWork.Roles.Add(entity);
                _unitOfWork.Complete();
            }
        }

        public void Update(string code, RoleFormViewModel form)
        {
            if (IsExistingInDatabase(code))
            {
                if (form.Code != null && form.Name != null)
                {
                    var entity = _mapper.Map<RoleFormViewModel, Role>(form);

                    _unitOfWork.Roles.Update(entity);
                    _unitOfWork.Complete();
                }
            }
        }

        public void Delete<T>(T code)
        {
            if (IsExistingInDatabase(code))
            {
                var entity = _unitOfWork.Roles.Get(code);

                _unitOfWork.Roles.Delete(entity);
                _unitOfWork.Complete();
            }
        }
    }
}
