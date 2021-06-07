using BUS_QLBanHang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QLBanHang
{
    public partial class FmMain_QLBH : Form
    {
        BUS_NHANVIEN busNhanVien = new BUS_QLBanHang.BUS_NHANVIEN();
        public FmMain_QLBH()
        {
            InitializeComponent();
            
        }
        public static int session = 0;
        public static int profile = 0;

        public static string mail;
        public static int vaitro;

        private bool CheckExistForm(string name)
        {
            bool check = false;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == name)
                {
                    check = true;
                    break;
                }
            }
            return check;
        }
        private void ActiveChildForm(string name)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == name)
                {
                    frm.Activate();
                    break;
                }
            }
        }


        private void hệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void VaiTroNV()
        {
            nhânViênToolStripMenuItem.Visible = false;
            tHỐNGKÊToolStripMenuItem.Visible = false;
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_DangNhap DN = new Frm_DangNhap();
            DN.Activate();
            DN.Show();
        }

        private void hồSơNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_DoiMK doi = new Frm_DoiMK(mail);
            doi.Activate();
            doi.Show();
        }
        private void Resetvalue()
        {
            if(session == 1)
            {
                đăngNhậpToolStripMenuItem.Enabled = false;
                hồSơNhânViênToolStripMenuItem.Visible = true;
                nhânViênToolStripMenuItem.Visible = true;
                sảnPhẩmToolStripMenuItem.Visible = true;
                thoátToolStripMenuItem.Enabled = true;
                //kháchHàngToolStripMenuItem.Visible = true;
                thốngKêSảnPhẩmToolStripMenuItem.Visible = true;
                danhMụcToolStripMenuItem.Visible = true;
                tHỐNGKÊToolStripMenuItem.Visible = true;
                if (vaitro == 0)
                {
                    VaiTroNV();
                }    
            }   
            else
            {
                đăngNhậpToolStripMenuItem.Enabled = true;
                nhânViênToolStripMenuItem.Visible = false;
                sảnPhẩmToolStripMenuItem.Visible = false;
                //kháchHàngToolStripMenuItem.Visible = false;
                thốngKêSảnPhẩmToolStripMenuItem.Visible = false;
                danhMụcToolStripMenuItem.Visible = false;
                tHỐNGKÊToolStripMenuItem.Visible = false;
                thoátToolStripMenuItem.Enabled = false;
            }
        }

        private void FmMain_QLBH_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void FmMain_QLBH_Load(object sender, EventArgs e)
        {
            Resetvalue();
            if (profile == 1)
            {
                hồSơNhânViênToolStripMenuItem = null;
                profile = 0;
            }
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Visible = false;
            ShowInTaskbar = false;

            Frm_Hang hang = new Frm_Hang();
            hang.Activate();
            hang.Show();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Visible = false;
            ShowInTaskbar = false;

            Frm_NhanVien nv = new Frm_NhanVien();
            nv.Activate();
            nv.Show();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Visible = false;
            ShowInTaskbar = false;

            Frm_KhachHang kh = new Frm_KhachHang();
            kh.Activate();
            kh.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_DangNhap DN = new Frm_DangNhap();
            DN.Activate();
            DN.Show();
        }

        private void MENU_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
