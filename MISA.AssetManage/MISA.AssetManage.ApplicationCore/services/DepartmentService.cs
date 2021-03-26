using MISA.AssetManage.ApplicationCore.Interfaces;
using MISA.AssetManage.ApplicationCore.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AssetManage.ApplicationCore.services
{
    public class DepartmentService: baseService<Department>
    {
        public DepartmentService(IBaseRepository<Department> repository) : base(repository)
        {

        }
    }
}
