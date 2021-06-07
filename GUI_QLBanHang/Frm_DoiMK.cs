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

namespace GUI_QLBanHang
{
    public partial class Frm_DoiMK : Form
    {
        public Frm_DoiMK(string email)
        {
            InitializeComponent();
            tbEmail.Text = email;
        }
        BUS_NHANVIEN busNhanVien = new BUS_NHANVIEN();
        private void btDoiMk_Click(object sender, EventArgs e)
        {
            
            if (tbMkCu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập mật khẩu cũ");
                return;
            }
            else if (tbMkMoi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mật khẩu mới");
                return;
            }
            else if (tbNhapLai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập lại mật khẩu mới");
                return;
            }
            else if (tbNhapLai.Text.Trim() != tbMkMoi.Text.Trim())
            {
                MessageBox.Show("Bạn phải nhập lại mật khẩu và mật khẩu giống nhau");
                return;
            }
            else
            {
                if (MessageBox.Show("Bạn có chắc muốn cập nhật mật khẩu") == DialogResult.OK)
                {
                    
                    string matkhaucu = busNhanVien.encryption(tbMkCu.Text);
                    MessageBox.Show(matkhaucu);
                    string matkhaumoi = busNhanVien.encryption(tbMkMoi.Text);
                    if (busNhanVien.UpdateMatKhau(tbEmail.Text, matkhaucu, matkhaumoi))
                    {
                        FmMain_QLBH.profile = 1;
                        FmMain_QLBH.session = 0;
                        MessageBox.Show("Cập nhật mật khẩu thành công, bạn cần phải đăng nhập lại");
                        this.Close();


                        Visible = false;
                        ShowInTaskbar = false;

                        FmMain_QLBH main = new FmMain_QLBH();
                        main.Activate();
                        main.Show();


                    }
                    else
                    {
                        MessageBox.Show("cập nhật thất bại");
                        tbMkCu.Text = null;
                        tbMkMoi.Text = null;
                        tbNhapLai.Text = null;
                    }
                }
                else
                {
                    tbMkCu.Text = null;
                    tbMkMoi.Text = null;
                    tbNhapLai.Text = null;
                }
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Frm_DoiMK_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
    }

