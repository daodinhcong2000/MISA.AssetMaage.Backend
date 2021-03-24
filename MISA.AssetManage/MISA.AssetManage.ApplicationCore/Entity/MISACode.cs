using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AssetManage.ApplicationCore.Entity
{
    /// <summary>
    /// Để xác định trạng thái của MISA Code
    /// </summary>
    public enum MISACode
    {
        /// <summary>
        /// Dữ liệu validate hợp lệ
        /// </summary>
        IsValid = 100,
        /// <summary>
        /// Dữ liệu validate chưa hợp lệ
        /// </summary>
        NotValid = 900,
        /// <summary>
        /// Dữ liệu trả về thành công
        /// </summary>
        Sucess  =200,

    }
    /// <summary>
    /// Trạng thái của đối tượng
    /// </summary>
    public enum EntityState
    {
        AddNew = 1,
        Update = 2,
        Delete = 3,
    }
}
