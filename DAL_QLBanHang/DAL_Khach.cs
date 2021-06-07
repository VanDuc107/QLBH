using DTO_QLBanHang;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QLBanHang
{
    public class DAL_Khach : DBConect
    {
        public DataTable getKhach()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[DanhSachKhach]";
                cmd.Connection = conn;
                DataTable dtKhach = new DataTable();
                dtKhach.Load(cmd.ExecuteReader());
                return dtKhach;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool insertKhach(DTO_Khach khach)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[InsertDataIntoTblKhach]";
                cmd.Parameters.AddWithValue("DienThoai", khach.SoDienThoai);
                cmd.Parameters.AddWithValue("TenKhach", khach.TenKhach);
                cmd.Parameters.AddWithValue("DiaChi", khach.DiaChi);
                cmd.Parameters.AddWithValue("phai", khach.Phai);
                cmd.Parameters.AddWithValue("Email", khach.EmailKhach);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }
        public bool DeleteKhach(string sodienthoai)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[DeleteDataFromtblKhach]";
                cmd.Parameters.AddWithValue("sodienthoai", sodienthoai);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }
        public bool UpdateKhach(DTO_Khach khach)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[UpdateDataIntoTblKhach]";
                cmd.Parameters.AddWithValue("sodienthaoi", khach.SoDienThoai);
                cmd.Parameters.AddWithValue("tenkhach", khach.TenKhach);
                cmd.Parameters.AddWithValue("diachi", khach.DiaChi);
                cmd.Parameters.AddWithValue("phai", khach.Phai);


                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }
        public DataTable SearchKhach(string sodienthoai)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[SearchKhach]";
                cmd.Parameters.AddWithValue("sodienthoai", sodienthoai);
                cmd.Connection = conn;
                DataTable dtkhach = new DataTable();
                dtkhach.Load(cmd.ExecuteReader());
                return dtkhach;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
