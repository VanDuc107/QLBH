using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLBanHang
{
    public class DTO_Khach
    {
        private string sodienthoai;
        private string tenkhach;
        private string diachi;
        private string phai;
        private string emailKhach;
        private string Manv;

        public string SoDienThoai
        {
            get
            {
                return sodienthoai;
            }
            set
            {
                sodienthoai = value;
            }
        }
        public string TenKhach
        {
            get
            {
                return tenkhach;
            }
            set
            {
                tenkhach = value;
            }
        }
        public string DiaChi
        {
            get
            {
                return diachi;
            }
            set
            {
                diachi = value;
            }
        }
        public string Phai
        {
            get
            {
                return phai;
            }
            set
            {
                phai = value;
            }
        }
        public string EmailKhach
        {
            get
            {
                return emailKhach;
            }
            set
            {
                emailKhach = value;
            }
        }

        public DTO_Khach(string tenkhach, string dienThoai, string phai, string diachi, string email = null)
        {
            this.sodienthoai = dienThoai;
            this.tenkhach = tenkhach;
            this.diachi = diachi;
            this.phai = phai;
            this.emailKhach = email;
        }
    }
}
