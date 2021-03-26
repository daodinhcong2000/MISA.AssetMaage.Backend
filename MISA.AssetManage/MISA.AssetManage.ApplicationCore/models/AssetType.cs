using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AssetManage.ApplicationCore.models
{
    public class AssetType : BaseEntity
    {
        /// <summary>
        /// ID của loại tài sản
        /// </summary>
        public Guid AssetTypeId { get; set; }
        /// <summary>
        /// Mã code loại tài sản
        /// </summary>
        public string AssetTypeCode { get; set; }
        /// <summary>
        /// Tên loại tài sản
        /// </summary>
        public string AssetTypeName { get; set; }
        /// <summary>
        /// Mô tả loại tài sản
        /// </summary>
        public string Description { get; set; }

    }
}
