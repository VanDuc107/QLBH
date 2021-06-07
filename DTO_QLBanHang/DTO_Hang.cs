using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLBanHang
{
        public class DTO_Hang
        {
            private int mahang;
            private string tenhang;
            private int soluong;
            private float dongianhap;
            private float dongiaban;
            private string hinhanh;
            private string ghichu;
            private string email;
            private string Manv;

            public int MaHang
            {
                get
                {
                    return mahang;
                }
                set
                {
                    mahang = value;
                }
            }
            public string TenHang
            {
                get
                {
                    return tenhang;
                }
                set
                {
                    tenhang = value;
                }
            }
            public int SoLuong
            {
                get
                {
                    return soluong;
                }
                set
                {
                    soluong = value;
                }
            }
            public float DonGiaNhap
            {
                get
                {
                    return dongianhap;
                }
                set
                {
                    dongianhap = value;
                }
            }
            public float DonGiaBan
            {
                get
                {
                    return dongiaban;
                }
                set
                {
                    dongiaban = value;
                }
            }
            public string HinhAnh
            {
                get
                {
                    return hinhanh;
                }
                set
                {
                    hinhanh = value;
                }
            }
            public string GhiChu
            {
                get
                {
                    return ghichu;
                }
                set
                {
                    ghichu = value;
                }
            }
            public string Email
            {
                get
                {
                    return email;
                }
                set
                {
                    email = value;
                }
            }

            public DTO_Hang(string tenhang, int soluong, float dongianhap, float dongiaban, string hinhanh, string ghichu, string emai = null)
            {

                this.tenhang = tenhang;
                this.soluong = soluong;
                this.dongianhap = dongianhap;
                this.dongiaban = dongiaban;
                this.hinhanh = hinhanh;
                this.ghichu = ghichu;
                this.email = emai;
            }
            public DTO_Hang(int mahang, string tenhang, int soluong, float dongianhap, float dongiaban, string hinhanh, string ghichu, string emai = null)
            {
                this.mahang = mahang;
                this.tenhang = tenhang;
                this.soluong = soluong;
                this.dongianhap = dongianhap;
                this.dongiaban = dongiaban;
                this.hinhanh = hinhanh;
                this.ghichu = ghichu;
                this.email = emai;
            }
        }
}
