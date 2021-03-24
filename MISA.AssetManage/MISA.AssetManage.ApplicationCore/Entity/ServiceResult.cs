using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AssetManage.ApplicationCore.Entity
{
    public class ServiceResult
    {
        public object data { get; set; }
        public string messenger { get; set; }
        public MISACode MISACode { get; set; }
    }
}
