using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLBanHang
{
    public class DTO_NHANVIEN
    {
        
            private string hoTen;
            private string diaChi;
            private int vaiTro;
            private string emailNV;
            private string matKhau;
            private int tinhTrang;
        
        public string HoTen
        {
            get { return hoTen; }
            set { hoTen = value; }
        }
        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }
        public int VaiTro
        {
            get { return vaiTro; }
            set { vaiTro = value; }
        }
        public string EmailNV
        {
            get { return emailNV; }
            set { emailNV = value; }
        }
        public string MatKhau
        {
            get { return matKhau; }
            set { matKhau = value; }
        }
        public int TinhTrang
        {
            get { return tinhTrang; }
            set { tinhTrang = value; }
        }
        public DTO_NHANVIEN(string TenNV, string Email, string DiaChi,string MatKhau, int VaiTro, int TinhTrang)
        {
            this.hoTen = TenNV;
            this.emailNV = Email;
            this.diaChi = DiaChi;
            this.vaiTro = VaiTro;
            this.tinhTrang = TinhTrang;
            this.matKhau = MatKhau;
        }
        public DTO_NHANVIEN(string Email, string TenNV, string DiaChi, int VaiTro, int TinhTrang)
        {
            this.hoTen = TenNV;
            this.emailNV = Email;
            this.diaChi = DiaChi;
            this.vaiTro = VaiTro;
            this.tinhTrang = TinhTrang;
        }
        public DTO_NHANVIEN()
        { }
    }
}
