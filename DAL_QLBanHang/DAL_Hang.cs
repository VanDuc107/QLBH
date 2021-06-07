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
    public class DAL_Hang : DBConect
    {
        public DataTable getHang()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachHang";
                cmd.Connection = conn;
                DataTable dtHang = new DataTable();
                dtHang.Load(cmd.ExecuteReader());
                return dtHang;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool insertHang(DTO_Hang hang)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[InsertDataIntoTblHang]";
                cmd.Parameters.AddWithValue("TenHang", hang.TenHang);
                cmd.Parameters.AddWithValue("SoLuong", hang.SoLuong);
                cmd.Parameters.AddWithValue("DonGiaNhap", hang.DonGiaNhap);
                cmd.Parameters.AddWithValue("DonGiaBan", hang.DonGiaBan);
                cmd.Parameters.AddWithValue("HinhAnh", hang.HinhAnh);
                cmd.Parameters.AddWithValue("GhiChu", hang.GhiChu);
                cmd.Parameters.AddWithValue("Email", hang.Email);

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
        public bool DeleteHang(string mahang)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteDataFromtblHang";
                cmd.Parameters.AddWithValue("mahang", mahang);

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
        public bool UpdateHang(DTO_Hang hang)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[UpdateDataIntoTblHang]";
                cmd.Parameters.AddWithValue("MaHang", hang.MaHang);
                cmd.Parameters.AddWithValue("TenHang", hang.TenHang);
                cmd.Parameters.AddWithValue("SoLuong", hang.SoLuong);
                cmd.Parameters.AddWithValue("DonGiaNhap", hang.DonGiaNhap);
                cmd.Parameters.AddWithValue("DonGiaBan", hang.DonGiaBan);
                cmd.Parameters.AddWithValue("HinhAnh", hang.HinhAnh);
                cmd.Parameters.AddWithValue("GhiChu", hang.GhiChu);

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
        public DataTable SearchHang(string tenhang)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[SearchHang]";
                cmd.Parameters.AddWithValue("tenhang", tenhang);
                cmd.Connection = conn;
                DataTable dtnhanvien = new DataTable();
                dtnhanvien.Load(cmd.ExecuteReader());
                return dtnhanvien;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
