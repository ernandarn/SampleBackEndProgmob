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
        public JenisMotor Get(int id)
        {
            JenisMotorDAL jenisMotorDAL = new JenisMotorDAL();
            return jenisMotorDAL.GetById(id);
        }

        // POST: api/JenisMotor
        public IHttpActionResult Post(JenisMotor jnsmotor)
        {
            JenisMotorDAL jenisMotorDAL = new JenisMotorDAL();
            try
            {
                jenisMotorDAL.Create(jnsmotor);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/JenisMotor/5
        public IHttpActionResult Put(JenisMotor jnsmotor)
        {
            JenisMotorDAL jenisMotorDAL = new JenisMotorDAL();
            try
            {
                jenisMotorDAL.Update(jnsmotor);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/JenisMotor/5
        public IHttpActionResult Delete(int id)
        {
            JenisMotorDAL jenisMotorDAL = new JenisMotorDAL();
            try
            {
                jenisMotorDAL.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
