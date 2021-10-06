using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL;
using DEL;
namespace WebAPIDemo.Controllers
{
    public class ValuesController : ApiController
    {
       static List<string> stringList = new List<string> {"String1","String2","String3","String4" };
        EmpMasterDAL empMasterDAL = new EmpMasterDAL();
        public HttpResponseMessage Get()
        {
            var empList = empMasterDAL.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK,empList);
        }

        public HttpResponseMessage GetById(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, stringList[id]);
        }

        public HttpResponseMessage Post([FromBody] EmpMaster empMaster)
        {
            empMasterDAL.Save(empMaster);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        public HttpResponseMessage Delete(int id)
        {
            stringList.RemoveAt(id);
            return Request.CreateResponse(HttpStatusCode.Gone);
        }
        public HttpResponseMessage Put([FromUri] int id,[FromBody]string newStr)
        {
           stringList[id] = newStr;
            return Request.CreateResponse(HttpStatusCode.Accepted);
        }
    }
}
