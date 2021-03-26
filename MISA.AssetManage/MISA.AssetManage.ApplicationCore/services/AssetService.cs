
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Data;

using MISA.AssetManage.ApplicationCore.models;
using MISA.AssetManage.ApplicationCore.Interfaces;


namespace MISA.AssetManage.ApplicationCore.services
{
    public class AssetService : baseService<asset>,IAssetService
    {
        #region constructer
        public AssetService(IBaseRepository<asset> repository) : base(repository)
        {
          
        }

        #endregion
        public IEnumerable<asset> GetAssetByCode(string customerCode)
        {

            return null;
        }
    }
}