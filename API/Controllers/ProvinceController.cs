﻿/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๑๔/๐๕/๒๕๖๓>
Modify date : <๑๕/๐๕/๒๕๖๓>
Description : <>
=============================================
*/

using System.Data;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Models;

namespace API.Controllers
{
    [RoutePrefix("Province")]
    public class ProvinceController : ApiController
    {
        [Route("GetList")]
        [HttpGet]
        public HttpResponseMessage GetList(
            string keyword = "",
            string country = "",
            string cancelledStatus = "",
            string sortOrderBy = "",
            string sortExpression = ""          
        )
        {
            DataTable dt = Province.GetList(keyword, country, cancelledStatus, sortOrderBy, sortExpression).Tables[0];

            return Request.CreateResponse(HttpStatusCode.OK, Util.APIResponse.GetData(dt));
        }

        [Route("Get")]
        [HttpGet]
        public HttpResponseMessage Get(string country = "", string province = "")
        {
            DataTable dt = Province.GetList("", country, "", "", "").Tables[0];
            DataRow[] dr = dt.Select("(plcCountryId = '" + country + "') and (id = '" + province + "')");

            dt = (dr.Length > 0 ? dr.CopyToDataTable() : dt.Clone());

            return Request.CreateResponse(HttpStatusCode.OK, Util.APIResponse.GetData(dt));
        }
    }
}
