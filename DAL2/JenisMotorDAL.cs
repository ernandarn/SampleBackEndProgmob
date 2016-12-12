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
   public class JenisMotorDAL
    {
        private string GetConnStr()
        {
            return ConfigurationManager.ConnectionStrings["StokDbConn"].ConnectionString;
        }

        public IEnumerable<JenisMotor> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from JenisMotor 
                                  order by NamaJenisMotor asc";

                var results = conn.Query<JenisMotor>(strSql);
                return results;
            }
        }

        public JenisMotor GetById(int IdJenisMotor)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from JenisMotor 
                                  where IdJenisMotor=@IdJenisMotor";

                var par = new
                {
                    IdJenisMotor = IdJenisMotor
                };
                return conn.Query<JenisMotor>(strSql, par).SingleOrDefault();
            }
        }

        public void Create(JenisMotor jenismotor)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"insert into JenisMotor(NamaMerk, NamaJenisMotor) 
                                  values(@NamaMerk, @NamaJenisMotor)";

                var par = new
                {
                    NamaMerk = jenismotor.NamaMerk,
                    NamaJenisMotor= jenismotor.NamaJenisMotor
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

        public void Update(JenisMotor jenismotor)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"update JenisMotor set NamaMerk=@NamaMerk, NamaJenisMotor=@NamaJenisMotor
                                  where IdJenisMotor=@IdJenisMotor";

                var par = new
                {
                    NamaMerk = jenismotor.NamaMerk,
                    NamaJenisMotor = jenismotor.NamaJenisMotor,
                    IdJenisMotor = jenismotor.IdJenisMotor
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

        public void Delete(int IdJenisMotor)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"delete from JenisMotor 
                                  where IdJenisMotor=@IdJenisMotor";

                var par = new
                {
                    IdJenisMotor = IdJenisMotor
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

    }
}

