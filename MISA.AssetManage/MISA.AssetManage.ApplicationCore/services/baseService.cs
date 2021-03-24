
using MISA.AssetManage.ApplicationCore.Entity;
using MISA.AssetManage.ApplicationCore.Interfaces;
using MISA.AssetManage.ApplicationCore.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.AssetManage.ApplicationCore.services
{
    public class baseService<MISAEntity> : IBaseService<MISAEntity> where MISAEntity:BaseEntity
    {
        #region declare 
        protected IBaseRepository<MISAEntity> _repository;
        ServiceResult _serviceResult;
        #endregion

        #region constructer

        public baseService(IBaseRepository<MISAEntity> repository)
        {
            _repository = repository;
            _serviceResult = new ServiceResult();
        }
        #endregion

        public IEnumerable<MISAEntity> GetAll()
        {
            var res = _repository.GetAll();
            var msg = new
            {
                devMsg = "không có dữ liệu trả về",
                userMsg = "Không có thông tin khách hàng",
                Code = 990
            };
           if (res == null)
            {
                return res;
            }
           else
            return res;
        }

        public IEnumerable<MISAEntity> GetAllById(Guid entityID)
        {
           
            return _repository.GetAllById(entityID);
        }


        public ServiceResult Insert(MISAEntity entity)
        {

            entity.EntityState = EntityState.AddNew;
            ///Validate dữ liệu
            if (Validate(entity) == false)
            {
                return _serviceResult;
            }
            else
            {
                _serviceResult.data = $"Thêm thành công { _repository.Insert(entity)} bản ghi";
                _serviceResult.messenger = "Thành công";
                _serviceResult.MISACode = MISACode.IsValid;

                return _serviceResult;
            }
            
        }

        public ServiceResult UpdateByID (MISAEntity entity)
        {
            entity.EntityState = EntityState.Update;
            if (Validate(entity) == false)
            {
                return _serviceResult;
            }
            else
            {
                _serviceResult.data = $"Sửa thành công { _repository.UpdateByID(entity)} bản ghi";
                _serviceResult.messenger = "Thành công";
                _serviceResult.MISACode = MISACode.IsValid;

                return _serviceResult;
            }
        }


        private bool Validate(MISAEntity entity)
        {
            bool _isValidate = true;
            var properties = entity.GetType().GetProperties();
            var erroList = new List<string>();

            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(entity);
                var displayName = string.Empty;
                var displayAtribute = property.GetCustomAttributes(typeof(DisplayName),true);
                if(displayAtribute.Length > 0)
                {
                     displayName = (displayAtribute[0] as DisplayName)._name;
                }
                ///Kiểm tra xem có cần validate hay không
                if (property.IsDefined(typeof(Required), false))
                {
                    ///Check dữ liệu bị trống
                    if (propertyValue == "" || propertyValue == null)
                    {
                        _isValidate = false;
                        erroList.Add($"{displayName} không được phép để trống");
                        _serviceResult.messenger = "Chưa nhập đủ dữ liệu";
                        _serviceResult.MISACode = MISACode.NotValid;
                        
                    }
                }

                if (property.IsDefined(typeof(CheckDuplicate), false))
                {
                    var propertyName = property.Name;
                    var entityDuplicate = _repository.GetEntityByProperty(entity,property);
                    if(entityDuplicate != null)
                    {
                        _isValidate = false;
                        erroList.Add($"Dữ liệu {displayName} bị trùng ");
                        _serviceResult.messenger = "Dữ liệu bị trùng";
                        _serviceResult.MISACode = MISACode.NotValid;
                       
                    }  
                }
            }

            _serviceResult.data = erroList;

            return _isValidate;
        }
    }
}
