using DTO_QLBanHang;
using DAL_QLBanHang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;
using System.Data;

namespace BUS_QLBanHang
{
    public class BUS_NHANVIEN
    {
        DAL_NHANVIEN dalNhanVien = new DAL_NHANVIEN();
        public bool NhanVienDangNhap(DTO_NHANVIEN nv)
        {
            return dalNhanVien.NhanVienDangNhap(nv);
        }
        public bool NhanVienQuenMatKhau(string email)
        {
            return dalNhanVien.NhanVienQuenMatKhau(email);
        }
        public string encryption(string password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider(); 
            byte[] encrypt; 
            UTF8Encoding encode = new UTF8Encoding();
            //encrypt the given password string into Encrypted data 
            encrypt = md5.ComputeHash(encode.GetBytes(password)); 
            StringBuilder encryptdata = new StringBuilder(); 
            //Create a new string by using the encrypted data 
                for (int i = 0; i < encrypt.Length; i++)
            {
                encryptdata.Append(encrypt[i].ToString());
            }
            return encryptdata.ToString();

        }
        public bool TaoMatKhau(string email, string MatKhauMoi)
        {
            return dalNhanVien.TaoMatKhau(email, MatKhauMoi);
        }
        public int RanDomNumBer(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        public string RanDomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
        public void SendMail(string email, string matkhau)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 25);
                NetworkCredential cred = new NetworkCredential("ducnvps12486@fpt.edu.vn",  "Vanduc@1007");
                MailMessage Msg = new MailMessage();
                Msg.From = new MailAddress("ducnvps12486@fpt.edu.vn");
                Msg.To.Add(email);
                Msg.Subject = "Ban da  su dung tinh nang quen mat khau ";
                Msg.Body = "Chao a/c Mat khau moi truy cap phan mem la " + matkhau;
                client.Credentials = cred;
                client.EnableSsl = true;
                client.Send(Msg);
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
            }
        }
        public bool UpdateMatKhau(string email, string matkhaucu, string matkhaumoi)
        {
            return dalNhanVien.UpdateMatKhau(email, matkhaucu, matkhaumoi);
        }
        public DataTable VaiTroNhanVien(string Email)
        {
            return dalNhanVien.VaiTroNhanVien(Email);
        }
        public DataTable getNhanVien()
        {
            return dalNhanVien.getNhanVien();
        }
        public bool insertNhanVien(DTO_NHANVIEN nv)
        {
            return dalNhanVien.insertNhanVien(nv);
        }

        public bool DeleteNhanVien(string tendangnhap)
        {
            return dalNhanVien.DeleteNhanVien(tendangnhap);
        }

        public bool UpdateNhanVien(DTO_NHANVIEN Nv)
        {
            return dalNhanVien.UpdateNhanVien(Nv);
        }

        public DataTable SearchNhanVien(string tennhanvien)
        {
            return dalNhanVien.SearchNhanVien(tennhanvien);
        }
    }
}
