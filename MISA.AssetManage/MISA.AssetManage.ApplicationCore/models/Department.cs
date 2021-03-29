using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AssetManage.ApplicationCore.models
{
    public class Department : BaseEntity
    {   
        /// <summary>
        /// ID bộ phần để tài sản
        /// </summary>
        public Guid DepartmentId { get; set; }
        /// <summary>
        /// mã code bộ phận để tài sản
        /// </summary>
        public string DepartmentCode { get; set; }
        /// <summary>
        /// Tên bộ phận
        /// </summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// Mô tả bộ phận
        /// </summary>
        public string Description { get; set; }
    }
}
