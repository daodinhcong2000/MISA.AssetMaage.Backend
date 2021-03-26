using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AssetManage.ApplicationCore.models
{
    public class asset : BaseEntity
    {
        #region declare
        #endregion

        #region  Constructer

        #endregion

        #region Properties
        /// <summary>
        /// Mã ID - khóa chính tài sản
        /// </summary>
        [PrimaryKey]
        [DisplayName("ID tài sản")]
        public Guid AssetId { get; set; }
        /// <summary>
        /// Mã code tài sản
        /// </summary>
        [Required]
        [DisplayName("mã code tài sản")]
        [CheckDuplicate]
        public string AssetCode { get; set; }
        /// <summary>
        /// Tên tài sản
        /// </summary>
        public string AssetName { get; set; }
        /// <summary>
        /// ID loại tài sản
        /// </summary>
        public Guid AssetTypeId { get; set; }
        /// <summary>
        /// ID của phòng ban tài sản   
        /// </summary>
        public Guid DepartmentId { get; set; }
        /// <summary>
        /// ngày ghi tăng
        /// </summary>
        public DateTime IncreaseDate { get; set; }
        /// <summary>
        /// Thời gian sử dụng
        /// </summary>
        public int TimeUse { get; set; }
        /// <summary>
        /// tỉ lệ hao mòn
        /// </summary>
        public float WearRate { get; set; }
        /// <summary>
        /// Nguyên giá
        /// </summary>
        public decimal OriginalPrice { get; set; }
        /// <summary>
        /// Giá trị hao mòn
        /// </summary>
        public decimal WearValue { get; set; }
        /// <summary>
        /// Sử dụng
        /// </summary>
        public int IsUsed { get; set; }
        



        #endregion

    }
}
