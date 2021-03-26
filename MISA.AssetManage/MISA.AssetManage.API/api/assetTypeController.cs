using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.AssetManage.ApplicationCore.Interfaces;
using MISA.AssetManage.ApplicationCore.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.AssetManage.API.api
{
  
    public class assetTypeController : baseController<AssetType>
    {
        public assetTypeController(IBaseService<AssetType> baseService) : base(baseService)
        {

        }
    }
}
