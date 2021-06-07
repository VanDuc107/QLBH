using BUS_QLBanHang;
using DTO_QLBanHang;
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
    public partial class Frm_KhachHang : Form
    {
        BUS_Khach busKhach = new BUS_Khach();
        string stremail = FmMain_QLBH.mail;
        public Frm_KhachHang()
        {
            InitializeComponent();
        }
        private void LoadGirdview_Khach()
        {
            dataGridView1.DataSource = busKhach.getKhach();
            dataGridView1.Columns[0].HeaderText = "Điên Thoại";
            dataGridView1.Columns[1].HeaderText = "Họ Tên";
            dataGridView1.Columns[2].HeaderText = "Địa Chỉ";
            dataGridView1.Columns[3].HeaderText = "Giới Tính";
            dataGridView1.Columns[4].Visible = false;
        }
        public void ResetValues()
        {
            tbNhapSDT.Text = "Nhập số điện thoại khách hàng";
            tbSDT.Text = null;
           tbTenKH.Text = null;
            tbDiaChiKH.Text = null;
            tbSDT.Enabled = false;
            tbTenKH.Enabled = false;
             tbDiaChiKH.Enabled = false;
            rdNam.Enabled = false;
            rdNu.Enabled = false;
            //btthem.Enabled = true;
            //btluu.Enabled = false;
            //btdong.Enabled = true;
            //btsua.Enabled = false;
            //btxoa.Enabled = false;
        }

        private void FrmKhach_Load(object sender, EventArgs e)
        {
            ResetValues();
            LoadGirdview_Khach();
        }

        private void btthem_Click(object sender, EventArgs e)
        {
            tbSDT.Text = null;
            tbTenKH.Text = null;
            tbDiaChiKH.Text = null;
            tbSDT.Enabled = true;
            tbTenKH.Enabled = true;
            tbDiaChiKH.Enabled = true;
            rdNam.Enabled = true;
            rdNu.Enabled = true;

            //btluu.Enabled = true;
            //btdong.Enabled = true;
            //btsua.Enabled = true;
            //btxoa.Enabled = true;
            rdNam.Checked = false;
            rdNu.Checked = false;

        }

        private void btluu_Click(object sender, EventArgs e)
        {
            float intDienThoai;
            bool isInt = float.TryParse(tbSDT.Text.Trim().ToString(), out intDienThoai);
            string phai = "Nam";
            if (rdNu.Checked == true)
                phai = "Nữ";
            if (!isInt || float.Parse(tbSDT.Text) < 0)
            {
                MessageBox.Show("Bạn phải nhập số điện thoại > 0, số nguyên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbSDT.Focus();
                return;
            }
            else
            {
                DTO_Khach kh = new DTO_Khach(tbSDT.Text, tbTenKH.Text, tbDiaChiKH.Text, phai, stremail);
                if (busKhach.insertKhach(kh))
                {
                    MessageBox.Show("Thêm thành công");
                    ResetValues();
                    LoadGirdview_Khach();
                }
                else
                {
                    MessageBox.Show("Thêm không thành công");
                }
            }
        }

        private void btdong_Click(object sender, EventArgs e)
        {
            Visible = false;
            ShowInTaskbar = false;

            FmMain_QLBH main = new FmMain_QLBH();

            main.Activate();
            main.Show();
        }

        private void FrmKhach_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void DgvKhach_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                btLuu.Enabled = false;
                tbTenKH.Enabled = true;
               tbDiaChiKH.Enabled = true;
                rdNam.Enabled = true;
                rdNu.Enabled = true;

                btSua.Enabled = true;
                btXoa.Enabled = true;

                tbSDT.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                tbTenKH.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                tbDiaChiKH.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

                string phai = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                if (phai == "Nam")
                    rdNam.Checked = true;
                else
                    rdNu.Checked = true;
            }
            else
            {
                MessageBox.Show("Bảng không tồn tại dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            float intDienThoai;
            bool isInt = float.TryParse(tbSDT.Text.Trim().ToString(), out intDienThoai);
            string phai = "Nam";
            if (rdNu.Checked == true)
                phai = "Nữ";
            if (!isInt || float.Parse(tbSDT.Text) < 0)
            {
                MessageBox.Show("Bạn phải nhập số điện thoại > 0, số nguyên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbSDT.Focus();
                return;
            }
            else
            {
                DTO_Khach kh = new DTO_Khach(tbSDT.Text, tbTenKH.Text,tbDiaChiKH.Text, phai);
                if (MessageBox.Show("Bạn có chắc muốn chỉnh sửa", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (busKhach.UpdateKhach(kh))
                    {
                        MessageBox.Show("Sửa thành công");
                        ResetValues();
                        LoadGirdview_Khach();
                    }
                    else
                    {
                        MessageBox.Show("Sửa không thành công");
                    }
                }
                else
                {
                    ResetValues();
                }
            }
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            string sodienthoai = tbSDT.Text;

            if (MessageBox.Show("Bạn có chắc muốn xóa dữ liệu", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (busKhach.DeleteKhach(sodienthoai))
                {
                    MessageBox.Show("Xóa dữ liệu thành công");
                    ResetValues();
                    LoadGirdview_Khach();
                }
                else
                {
                    MessageBox.Show("Xóa không thành công");
                }
            }
            else
            {
                ResetValues();
            }
        }

        private void tbtimkiem_TextChanged(object sender, EventArgs e)
        {
            tbNhapSDT.Text = null;
            tbNhapSDT.BackColor = Color.White;
        }

        private void bttimkiem_Click(object sender, EventArgs e)
        {
            string sodienthoai = tbNhapSDT.Text;
            DataTable ds = busKhach.SearchKhach(sodienthoai);
            if (ds.Rows.Count > 0)
            {
                dataGridView1.DataSource = ds;
                dataGridView1.Columns[0].HeaderText = "Điện Thoại";
                dataGridView1.Columns[1].HeaderText = "Họ Tên";
                dataGridView1.Columns[2].HeaderText = "Địa chỉ";
                dataGridView1.Columns[3].HeaderText = "Giới Tính";

            }
            else
            {
                MessageBox.Show("Không tìm thấy khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            tbNhapSDT.Text = "Nhập số điện thoại khách hàng";
            tbNhapSDT.BackColor = Color.LightGray;
            ResetValues();
        }

        private void btboqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            LoadGirdview_Khach();
        }

        private void btdanhsach_Click(object sender, EventArgs e)
        {
            ResetValues();
            LoadGirdview_Khach();
        }
    }
}
