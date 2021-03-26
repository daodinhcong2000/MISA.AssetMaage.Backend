using MISA.AssetManage.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.AssetManage.ApplicationCore.Interfaces
{
    public interface IBaseService<MISAEntity>
    {
        /// <summary>
        /// Lấy tất cả dữ liệu
        /// </summary>
        /// <typeparam name="MISAEntity">Type</typeparam>
        /// <returns></returns>
        IEnumerable<MISAEntity> GetAll();
        /// <summary>
        /// Lấy dữ liệu theo ID
        /// </summary>
        /// <typeparam name="MISAEntity">type</typeparam>
        /// <param name="entityID">ID</param>
        /// <returns></returns>
        IEnumerable<MISAEntity> GetAllById(Guid entityID);
        /// <summary>
        /// Thêm dữ liệu
        /// </summary>
        /// <typeparam name="MISAEntity">type</typeparam>
        /// <param name="entity">object</param>
        /// <returns></returns>
        ServiceResult Insert(MISAEntity entity);
        /// <summary>
        /// Sửa dữ liệu theo ID
        /// </summary>
        /// <param name="entity">Cần sửa những gì thì gửi lên</param>
        /// <returns></returns>
        ServiceResult UpdateByID(MISAEntity entity);

        /// <summary>
        /// Xoá 1 bản ghi
        /// </summary>
        /// <param name="ids">mảng id bản ghi</param>
        /// <returns>ServiceResult</returns>
        public  ServiceResult Delete(string[] ids);

        IEnumerable<MISAEntity> Fillter(string? name, Guid? DepartmentId, string? code, Guid? AssetTypeId);

    }
}
