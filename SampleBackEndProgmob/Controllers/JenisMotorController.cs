using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BO;
using DAL2;

namespace SampleBackEndProgmob.Controllers
{
    public class JenisMotorController : ApiController
    {
        // GET: api/JenisMotor
        public IEnumerable<JenisMotor> Get()
        {
            JenisMotorDAL jenisMotorDAL = new JenisMotorDAL();
            return jenisMotorDAL.GetAll();
        }

        // GET: api/JenisMotor/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/JenisMotor
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/JenisMotor/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/JenisMotor/5
        public void Delete(int id)
        {
        }
    }
}
