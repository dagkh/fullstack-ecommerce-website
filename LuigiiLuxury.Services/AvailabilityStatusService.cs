using System;
using System.Collections.Generic;
using System.Linq;

using AutoMapper;

using LuigiiLuxury.Domain.Entities;
using LuigiiLuxury.Domain.ViewModels;
using LuigiiLuxury.Domain.Interfaces;
using LuigiiLuxury.Domain.Interfaces.Services;

namespace LuigiiLuxury.Services
{
    public class AvailabilityStatusService : IAvailabilityStatusService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public AvailabilityStatusService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = MapperExtension.CreateMapper();
        }

        public AvailabilityStatusViewModel Get<T>(T code)
        {
            var entity = _unitOfWork.AvailabilityStatus.Get(code);

            if (entity == null)
                return null;
            else
            {
                var viewModel = _mapper.Map<AvailabilityStatus, AvailabilityStatusViewModel>(entity);
                return viewModel;
            }
        }

        private bool IsExistingInDatabase<T>(T code)
        {
            var entity = Get(code);

            if (entity == null)
                return false;
            return true;
        }

        public IEnumerable<AvailabilityStatusViewModel> GetAll()
        {
            var entities = _unitOfWork.AvailabilityStatus.GetAll();

            if (entities != null)
            {
                var availabilityStatuses = _mapper.Map<IEnumerable<AvailabilityStatus>, IEnumerable<AvailabilityStatusViewModel>>(entities);

                return availabilityStatuses;
            }
            else
                return null;
        }

        public string GetName(int code)
        {
            if (IsExistingInDatabase(code))
            {
                var viewModel = Get(code);

                return viewModel.Name;
            }
            else
                return null;
        }

        public void Delete<T>(T code)
        {
            if (IsExistingInDatabase(code))
            {
                var entity = _unitOfWork.AvailabilityStatus.Get(code);

                _unitOfWork.AvailabilityStatus.Delete(entity);
                _unitOfWork.Complete();
            }
        }

        public void Add(AvailabilityStatusFormViewModel availabilityStatusForm)
        {
            if (availabilityStatusForm.Name != null && availabilityStatusForm.Code != null)
            {
                var newEntity = _mapper.Map<AvailabilityStatusFormViewModel, AvailabilityStatus>(availabilityStatusForm);

                _unitOfWork.AvailabilityStatus.Add(newEntity);
                _unitOfWork.Complete();
            }
        }

        public void Update(string code, AvailabilityStatusFormViewModel availabilityStatusForm)
        {
            if (IsExistingInDatabase(code))
            {
                if (availabilityStatusForm.Name != null && availabilityStatusForm.Code != null)
                {
                    var entity = _mapper.Map<AvailabilityStatusFormViewModel, AvailabilityStatus>(availabilityStatusForm);

                    _unitOfWork.AvailabilityStatus.Update(code, entity);
                    _unitOfWork.Complete();
                }
            }
        }
    }
}
