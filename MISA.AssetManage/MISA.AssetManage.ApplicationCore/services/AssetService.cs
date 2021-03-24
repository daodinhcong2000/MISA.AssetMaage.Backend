
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Data;

using MISA.AssetManage.ApplicationCore.models;
using MISA.AssetManage.ApplicationCore.Interfaces;


namespace MISA.AssetManage.ApplicationCore.services
{
    public class AssetService : baseService<Asset>,IAssetService
    {
        #region constructer
        public AssetService(IBaseRepository<Asset> repository) : base(repository)
        {
          
        }

        #endregion
        public IEnumerable<Asset> GetAssetByCode(string customerCode)
        {

            return null;
        }
    }
}