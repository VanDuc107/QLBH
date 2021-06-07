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
    public class BUS_Hang
    {
        DAL_Hang dalHang = new DAL_Hang();

        public DataTable getHang()
        {
            return dalHang.getHang();
        }
        public bool insertHang(DTO_Hang hang)
        {
            return dalHang.insertHang(hang);
        }
        public bool DeleteHang(string mahang)
        {
            return dalHang.DeleteHang(mahang);
        }
        public bool UpdateHang(DTO_Hang hang)
        {
            return dalHang.UpdateHang(hang);
        }
        public DataTable SearchHang(string tenhang)
        {
            return dalHang.SearchHang(tenhang);
        }
    }
}
