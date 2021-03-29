using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.AssetManage.ApplicationCore.Entity;
using MISA.AssetManage.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.AssetManage.API.api
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class baseController<MISAEntities> : ControllerBase
    {
        protected IBaseService<MISAEntities> service;

        public baseController(IBaseService<MISAEntities> baseService)
        {
            service = baseService;
        }
        [HttpGet]
        public IActionResult Get()
        {

            var obj = service.GetAll().ToList();
            if (obj.Count > 0)
            {
                return StatusCode(200, obj);
            }
            else
            {
                return StatusCode(204, obj);
            }

        }

        [HttpGet("{entityId}")]

        public IActionResult GetById( Guid entityId)
        {

            var obj = service.GetAllById(entityId);
            if (obj != null)
            {
                return StatusCode(200, obj);
            }
            else
            {
                return StatusCode(204, obj);
            }

        }

        [HttpGet("search")]

        public IActionResult Filter(string contentFilter)
        {

            var obj = service.Fillter(contentFilter);
            if (obj != null)
            {
                return StatusCode(200, obj);
            }
            else
            {
                return StatusCode(204, obj);
            }

        }

        [HttpPost]

        public IActionResult Insert(MISAEntities objInput)
        {


            //if (objInput.CustomerCode == "")
            //{
            //    return StatusCode(400, new
            //    {
            //        devMsg = "CustomerCode required",
            //        userMsg = "Yêu cầu nhập mã Code",
            //        errorCode = "001",
            //        moreInfor = "",
            //        tracedID = ""
            //    });
            //}
            //else
            //{

            var res = service.Insert(objInput);
            if (res.MISACode == MISACode.IsValid)
            {
                return StatusCode(201, res.data);
            }
            else
            {
                return StatusCode(200, res);
            }

        }



        [HttpPut]

        public IActionResult UpdateByID(MISAEntities EntityInput)
        {
            var res = service.UpdateByID(EntityInput);
            if (res.MISACode == MISACode.IsValid)
            {
                return StatusCode(200, res.data);
            }
            else
                return StatusCode(204, res.data);
        }


        /// <summary>
        /// Xoá dữ liệu
        /// </summary>
        /// <param name="ids">mảng id của thực thể</param>
        /// <returns>Response tương ứng cho client(200, 400, ...)</returns>
        /// CreatedBy: DDCong
        [HttpDelete]
        public IActionResult Delete([FromQuery(Name = "ids")] string[] ids)
        {
            var res = service.Delete(ids);
            if (res.MISACode == MISACode.IsValid)
            {
                return StatusCode(200, res.data);
            }
            else
                return StatusCode(204, res.data);
        }
    }
}
