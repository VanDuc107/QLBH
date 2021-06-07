using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DTO_QLBanHang;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;

namespace DAL_QLBanHang
{
    public class DAL_NHANVIEN : DBConect
    {

        
        public bool NhanVienDangNhap(DTO_NHANVIEN nv)
        {
            try
            {
                // Ket noi 
                conn.Open(); 
                SqlCommand cmd = new SqlCommand(); 
                cmd.Connection = conn; 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DangNhap"; 
                cmd.Parameters.AddWithValue("Email", nv.EmailNV); 
                cmd.Parameters.AddWithValue("matKhau", nv.MatKhau);
                // Query và kiểm tra 
                if (Convert.ToInt16(cmd.ExecuteScalar()) == 1)
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
        public bool NhanVienQuenMatKhau(string email)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "QuenMatKhau";
                cmd.Parameters.AddWithValue("email", email);

                if (Convert.ToInt16(cmd.ExecuteScalar()) > 0)
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
        
        public bool TaoMatKhau(string email, string MatKhauMoi)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TaoMatKhauMoi";
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("matkhau", MatKhauMoi);
                if (cmd.ExecuteNonQuery()>0)
                {
                    return true;
                }
            }
            catch
            { }
            finally
            {
                conn.Close();
            }
            return false;
        }

        public bool UpdateMatKhau(string email, string matkhaucu, string matkhaumoi)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "chgpwd";
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("@opwd", matkhaucu);
                cmd.Parameters.AddWithValue("@npwd", matkhaumoi);

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
        public DataTable VaiTroNhanVien(string email)
        {
            // using store procedure
            try
            {
                // Ket noi
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[LayVaiTroNV]";
                cmd.Parameters.AddWithValue("email", email);
                cmd.Connection = conn;
                DataTable dtNhanVien = new DataTable();
                dtNhanVien.Load(cmd.ExecuteReader());
                return dtNhanVien;
            }
            finally
            {
                // Dong ket noi
                conn.Close();
            }
        }
        public DataTable getNhanVien()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[DanhSachNV]";
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
        public bool insertNhanVien(DTO_NHANVIEN nv)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[InsertDataIntoTblNhanVien]";
                cmd.Parameters.AddWithValue("email", nv.EmailNV);
                cmd.Parameters.AddWithValue("tennv", nv.HoTen);
                cmd.Parameters.AddWithValue("diachi", nv.DiaChi);
                cmd.Parameters.AddWithValue("vaitro", nv.VaiTro);
                cmd.Parameters.AddWithValue("tinhtrang", nv.TinhTrang);

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

        public bool DeleteNhanVien(string email)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[DeleteDataFromtblNhanVien]";
                cmd.Parameters.AddWithValue("email", email);

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

        public bool UpdateNhanVien(DTO_NHANVIEN nv)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[UpdateDataIntoTblNhanVien]";
                cmd.Parameters.AddWithValue("email", nv.EmailNV);
                cmd.Parameters.AddWithValue("tennv", nv.HoTen);
                cmd.Parameters.AddWithValue("diachi", nv.DiaChi);
                cmd.Parameters.AddWithValue("vaitro", nv.VaiTro);
                cmd.Parameters.AddWithValue("tinhtrang", nv.TinhTrang);

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

        public DataTable SearchNhanVien(string tennhanvien)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[SearchNhanVien]";
                cmd.Parameters.AddWithValue("tennv", tennhanvien);
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
