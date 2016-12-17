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
    public class BarangDAL
    {
        private string GetConnStr()
        {
            return ConfigurationManager.ConnectionStrings["StokDbConn"].ConnectionString;
        }

        public IEnumerable<Barang> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from Barang 
                                  order by Nama asc";

                var results = conn.Query<Barang>(strSql);
                return results;
            }
        }

        public IEnumerable<Barang> GetById(int KodeBarang)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from Barang 
                                  where KodeBarang=@KodeBarang";

                var par = new
                {
                    KodeBarang = KodeBarang
                };
                return conn.Query<Barang>(strSql, par);
            }
        }

        public void Create(Barang barang)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"insert into Barang(KodeBarang, IdKategori, IdJenisMotor, Nama, Stok, HargaBeli, HargaJual, TanggalBeli) 
                                  values(@KodeBarang, @IdKategori, @IdJenisMotor, @Nama, @Stok, @HargaBeli, @HargaJual, @TanggalBeli)";

                var par = new
                {
                    KodeBarang = barang.KodeBarang,
                    IdKategori = barang.IdKategori,
                    IdJenisMotor = barang.IdJenisMotor,
                    Nama = barang.Nama,
                    Stok = barang.Stok,
                    HargaBeli = barang.HargaBeli,
                    HargaJual = barang.HargaJual,
                    TanggalBeli = barang.TanggalBeli
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

        public void Update(Barang barang)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"update Barang set KodeBarang = @KodeBarang, IdKategori = @IdKategori, 
                                   IdJenisMotor = @IdJenisMotor, Nama = @Nama, Stok = @Stok, 
                                   HargaBeli = @HargaBeli, HargaJual = @HargaJual, 
                                   TanggalBeli = @TanggalBeli
                                  where KodeBarang = @KodeBarang";
                var par = new
                {
                    IdKategori = barang.IdKategori,
                    IdJenisMotor = barang.IdJenisMotor,
                    Nama = barang.Nama,
                    Stok = barang.Stok,
                    HargaBeli = barang.HargaBeli,
                    HargaJual = barang.HargaJual,
                    TanggalBeli = barang.TanggalBeli,
                    KodeBarang = barang.KodeBarang
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

        public void Delete(int KodeBarang)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"delete from Barang 
                                  where KodeBarang=@KodeBarang";

                var par = new
                {
                    KodeBarang = KodeBarang
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

        public IEnumerable<Barang> SearchByName(string nama)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from Barang where 
                                  Nama like @Nama 
                                  order by Nama asc";
                var par = new { Nama = "%" + nama + "%" };

                var results = conn.Query<Barang>(strSql, par);
                return results;
            }
        }


        public IEnumerable<BarangVM> SearchByKategori(string namaKategori)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strsql = @"select KodeBarang, Nama, Stok, HargaBeli, HargaJual, TanggalBeli, NamaKategori from Barang, Kategori
                                where Barang.IdKategori = Kategori.IdKategori and NamaKategori like @NamaKategori";
                var par = new
                {
                    NamaKategori = "%" + namaKategori + "%"
                };

                return conn.Query<BarangVM>(strsql, par);
            }
        }

    }
}
