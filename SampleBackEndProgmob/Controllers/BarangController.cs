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
    public class BarangController : ApiController
    {
        // GET: api/Barang
        public IEnumerable<Barang> Get()
        {
            BarangDAL barangDAL = new BarangDAL();
            return barangDAL.GetAll();
        }

        // GET: api/Barang/5
        public Barang Get(int id)
        {
            BarangDAL barangDAL = new BarangDAL();
            return barangDAL.GetById(id);
        }

        // POST: api/Barang
        public IHttpActionResult Post(Barang barang)
        {
            BarangDAL barangDAL = new BarangDAL();
            try
            {
                barangDAL.Create(barang);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Barang/5
        public IHttpActionResult Put(Barang barang)
        {
            BarangDAL barangDAL = new BarangDAL();
            try
            {
                barangDAL.Update(barang);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Barang/5
        public IHttpActionResult Delete(int id)
        {
            BarangDAL barangDAL = new BarangDAL();
            try
            {
                barangDAL.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IEnumerable<Barang> Get(string nama)
        {
            BarangDAL brg = new BarangDAL();
            return brg.SearchByName(nama);
        }

    }
}
