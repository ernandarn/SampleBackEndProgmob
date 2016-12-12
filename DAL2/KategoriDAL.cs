using BO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DAL2
{
    public class KategoriDAL
    {
        private string GetConnStr()
        {
            return ConfigurationManager.ConnectionStrings["StokDbConn"].ConnectionString;
        }

        public IEnumerable<Kategori> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from Kategori 
                                  order by NamaKategori asc";

                var results = conn.Query<Kategori>(strSql);
                return results;
            }
        }

        public Kategori GetById(int IdKategori)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from Kategori 
                                  where IdKategori=@IdKategori";

                var par = new
                {
                    IdKategori = IdKategori
                };
                return conn.Query<Kategori>(strSql, par).SingleOrDefault();
            }
        }

        public void Create(Kategori kategori)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"insert into Kategori(NamaKategori) 
                                  values(@NamaKategori)";
              
                var par = new
                {
                    NamaKategori = kategori.NamaKategori
                };
                try
                {
                    conn.Execute(strSql, par);
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Number + "-" + sqlEx.Message);
                }
            }
        }

        public void Update(Kategori kategori)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {

                string strSql = @"update Kategori set NamaKategori=@NamaKategori 
                                  where IdKategori=@IdKategori";
                var par = new
                {
                    NamaKategori = kategori.NamaKategori,
                    IdKategori = kategori.IdKategori
                };

                try
                {
                    conn.Execute(strSql, par);
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Number + " - " + sqlEx.Message);
                }
            }
        }

        public void Delete(int IdKategori)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {

                string strSql = @"delete from Kategori 
                                  where IdKategori=@IdKategori";
                var par = new
                {
                    IdKategori = IdKategori
                };

                try
                {
                    conn.Execute(strSql, par);
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Number + " - " + sqlEx.Message);
                }
            }
        }

        public IEnumerable<Kategori> SearchByName(string namaKategori)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from Kategori where 
                                  NamaKategori like @NamaKategori 
                                  order by NamaKategori asc";
                var par = new { NamaKategori = "%" + namaKategori + "%" };

                var results = conn.Query<Kategori>(strSql, par);
                return results;
            }
        }



    }

}



    

