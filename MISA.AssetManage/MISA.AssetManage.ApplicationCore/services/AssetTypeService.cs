using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AssetManage.ApplicationCore.services
{
    public class AssetTypeService : baseService<AssetType>
    {
        public AssetTypeService(IBaseRepository<asset> repository) : base(repository)
        {

        }

    }
}
