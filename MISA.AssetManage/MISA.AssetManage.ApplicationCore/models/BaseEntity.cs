using MISA.AssetManage.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AssetManage.ApplicationCore.models
{
    [AttributeUsage(AttributeTargets.Property)]
    public class Required : Attribute
    {

    }

    [AttributeUsage(AttributeTargets.Property)]
    public class PrimaryKey : Attribute
    {

    }

    [AttributeUsage(AttributeTargets.Property)]
    public class CheckDuplicate : Attribute
    {

    }

    [AttributeUsage(AttributeTargets.Property)]
    public class DisplayName : Attribute
    {
        public string _name { get; set; }
        public DisplayName(string name)
        {
            this._name = name;
        }
    }

    public class BaseEntity
    {

        public EntityState EntityState { get; set; }
        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Được tạo bởi
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// ngày sửa
        /// </summary>
        public DateTime ModifiedDate { get; set; }
        /// <summary>
        /// Đưuọc sửa bởi
        /// </summary>
        public string ModifiedBy { get; set; }
    }
}
