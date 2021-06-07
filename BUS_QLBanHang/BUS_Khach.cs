using DAL_QLBanHang;
using DTO_QLBanHang;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLBanHang
{
    public class BUS_Khach
    {
        DAL_Khach dalKhach = new DAL_Khach();

        public DataTable getKhach()
        {
            return dalKhach.getKhach();
        }
        public bool insertKhach(DTO_Khach khach)
        {
            return dalKhach.insertKhach(khach);
        }
        public bool DeleteKhach(string sodienthoai)
        {
            return dalKhach.DeleteKhach(sodienthoai);
        }
        public bool UpdateKhach(DTO_Khach khach)
        {
            return dalKhach.UpdateKhach(khach);
        }
        public DataTable SearchKhach(string sodienthoai)
        {
            return dalKhach.SearchKhach(sodienthoai);
        }
    }
}
