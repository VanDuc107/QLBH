using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QLBanHang;
using DAL_QLBanHang;
using DTO_QLBanHang;

namespace GUI_QLBanHang
{
    public partial class Frm_DangNhap : Form
    {
        public Frm_DangNhap()
        {
            InitializeComponent();
        }
        public string vaitro { get; set; }
        public string matkhau { get; set; }
        private void btDangNhap_Click(object sender, EventArgs e)
        {
            BUS_NHANVIEN busNhanVien = new BUS_NHANVIEN();
            DTO_NHANVIEN nv = new DTO_NHANVIEN();
            nv.EmailNV = tbEmail.Text;
            nv.MatKhau = busNhanVien.encryption(tbMk.Text);
            if (busNhanVien.NhanVienDangNhap(nv))
            {
                FmMain_QLBH.mail = nv.EmailNV;
                DataTable dt = busNhanVien.VaiTroNhanVien(nv.EmailNV);
                vaitro = dt.Rows[0][0].ToString();
                MessageBox.Show("Đăng nhập thành công");
                FmMain_QLBH.session = 1;
                FmMain_QLBH.mail = tbEmail.Text;

                FmMain_QLBH fm = new FmMain_QLBH();
                fm.Activate();
                fm.Show();

                this.Close();
            }
            else
            {
                MessageBox.Show("Đăng Nhập Không Thành Công, Kiểm tra lại email hoặc mật khẩu");
                tbEmail.Text = null;
                tbMk.Text = null;
                tbEmail.Focus();
            }

        }


        private void btQuen_Click_1(object sender, EventArgs e)
        {
            BUS_NHANVIEN busNhanVien = new BUS_NHANVIEN();
            if (tbEmail.Text != "")
            {
                if (busNhanVien.NhanVienQuenMatKhau(tbEmail.Text))//show from input email. if true will send pass random
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append(busNhanVien.RanDomString(4, true));
                    builder.Append(busNhanVien.RanDomNumBer(1000, 9999));
                    builder.Append(busNhanVien.RanDomString(2, false));
                    MessageBox.Show(builder.ToString());
                    string matkhaumoi = busNhanVien.encryption(builder.ToString());
                    MessageBox.Show(matkhaumoi);
                    busNhanVien.TaoMatKhau(tbEmail.Text, matkhaumoi);
                    busNhanVien.SendMail(tbEmail.Text, builder.ToString()); // send new pass to email
                }
                else
                {
                    MessageBox.Show("Email khong ton tai, vui long nhap lai email");
                }
            }
            else
            {
                MessageBox.Show("Ban can nhap email nhan thong tin phuc hoi mat khau");
            }
        }


        private void btThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void Frm_DangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            FmMain_QLBH.session = 0;
        }
    }
    }
