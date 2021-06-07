using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QLBanHang;
using DTO_QLBanHang;

namespace GUI_QLBanHang
{
    public partial class Frm_NhanVien : Form
    {
        BUS_NHANVIEN busNhanVien = new BUS_NHANVIEN();
        public Frm_NhanVien()
        {
            InitializeComponent();
        }
        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadGridview_NhanVien()
        {
            dataGridView1.DataSource = busNhanVien.getNhanVien();
            dataGridView1.Columns[0].HeaderText = "Email";
            dataGridView1.Columns[1].HeaderText = "Tên Nhân Viên";
            dataGridView1.Columns[2].HeaderText = "Địa chỉ";
            dataGridView1.Columns[3].HeaderText = "Vai trò";
            dataGridView1.Columns[4].HeaderText = "Tình Trạng";
        }

        private void Frm_NhanVien_Load(object sender, EventArgs e)
        {
            ResetValues();
            LoadGridview_NhanVien();
        }
        public void ResetValues()
        {
            tbNhap.Text = "Nhập tên nhân viên";
            Mail.Text = null;
            TenNV.Text = null;
            DiaChi.Text = null;
            Mail.Enabled = false;
            TenNV.Enabled = false;
            DiaChi.Enabled = false;
            rdNV.Enabled = false;
            rdQT.Enabled = false;
            rdON.Enabled = false;
            rdOff.Enabled = false;
            
        }
        private void frmNhanVien_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void btthem_Click(object sender, EventArgs e)
        {
            Mail.Text = null;
            TenNV.Text = null;
            DiaChi.Text = null;
            Mail.Enabled = false;
            TenNV.Enabled = false;
            DiaChi.Enabled = false;
            rdNV.Enabled = false;
            rdQT.Enabled = false;
            rdON.Enabled = false;
            rdOff.Enabled = false;
            //btluu.Enabled = true;
            //btdong.Enabled = true;
            //btsua.Enabled = true;
            //btxoa.Enabled = true;
            rdNV.Checked = false;
            rdQT.Checked = false;
            rdON.Checked = false;
            rdOff.Checked = false;
        }
        private void btluu_Click(object sender, EventArgs e)
        {
            string email;
            int role = 0;
            if (rdQT.Checked)
                role = 1;
            int tinhtrang = 0;
            if (rdON.Checked)
                tinhtrang = 1;
            if (Mail.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Mail.Focus();
                return;
            }
            else if (!IsValid(Mail.Text.Trim()))
            {
                MessageBox.Show("Bạn phải nhập đúng định dạng email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Mail.Focus();
                return;
            }
            if (TenNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TenNV.Focus();
                return;
            }
            else if (DiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DiaChi.Focus();
                return;
            }
            if (rdQT.Checked == false && rdNV.Checked == false)
            {
                MessageBox.Show("Bạn phải chọn vai trò", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TenNV.Focus();
                return;
            }
            if (rdON.Checked == false && rdOff.Checked == false)
            {
                MessageBox.Show("Bạn phải chọn tình trạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TenNV.Focus();
                return;
            }
            else
            {
                DTO_NHANVIEN nv = new DTO_NHANVIEN(Mail.Text, TenNV.Text, DiaChi.Text, role, tinhtrang);
                if (busNhanVien.insertNhanVien(nv))
                {
                    MessageBox.Show("Thêm thành công");
                    ResetValues();
                    LoadGridview_NhanVien();
                    email = Mail.Text;
                }
                else
                {
                    MessageBox.Show("Thêm không thành công");
                }
            }
        }
        public bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
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
        private void btxoa_Click(object sender, EventArgs e)
        {
            string email = Mail.Text;
            if (MessageBox.Show("Bạn có chắc muốn xóa dữ liệu", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (busNhanVien.DeleteNhanVien(email))
                {
                    MessageBox.Show("Xóa dữ liệu thành công");
                    ResetValues();
                    LoadGridview_NhanVien();
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

        private void btsua_Click(object sender, EventArgs e)
        {
            if (TenNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TenNV.Focus();
                return;
            }
            else if (DiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DiaChi.Focus();
                return;
            }
            else
            {
                int role = 0;
                if (rdQT.Checked)
                    role = 1;
                int tinhtrang = 0;
                if (rdON.Checked)
                    tinhtrang = 1;

                DTO_NHANVIEN nv = new DTO_NHANVIEN(Mail.Text, TenNV.Text, DiaChi.Text, role, tinhtrang);

                if (MessageBox.Show("Bạn có chắc muốn chỉnh sửa", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (busNhanVien.UpdateNhanVien(nv))
                    {
                        MessageBox.Show("Sửa thành công");
                        ResetValues();
                        LoadGridview_NhanVien();
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



        private void tbtimkiem_Click(object sender, EventArgs e)
        {
            tbNhap.Text = null;
            tbNhap.BackColor = Color.White;
        }

        private void bttimkiem_Click(object sender, EventArgs e)
        {
            string tennhanvien = tbNhap.Text;
            DataTable ds = busNhanVien.SearchNhanVien(tennhanvien);
            if (ds.Rows.Count > 0)
            {
                dataGridView1.DataSource = ds;
                dataGridView1.Columns[0].HeaderText = "Email";
                dataGridView1.Columns[1].HeaderText = "Tên Nhân Viên";
                dataGridView1.Columns[2].HeaderText = "Địa chỉ";
                dataGridView1.Columns[3].HeaderText = "Vai trò";
                dataGridView1.Columns[4].HeaderText = "Tình Trạng";
            }
            else
            {
                MessageBox.Show("Không tìm thấy nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            tbNhap.Text = "Nhập tên nhân viên";
            tbNhap.BackColor = Color.LightGray;
            ResetValues();
        }

        private void btboqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            LoadGridview_NhanVien();
        }

        private void btdanhsach_Click(object sender, EventArgs e)
        {
            ResetValues();
            LoadGridview_NhanVien();
        }

        private void DgvNhanVien_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                btLuu.Enabled = false;
                TenNV.Enabled = true;
                DiaChi.Enabled = true;
                rdQT.Enabled = true;
                rdNV.Enabled = true;
                rdON.Enabled = true;
                rdOff.Enabled = true;
                btSua.Enabled = true;
                btXoa.Enabled = true;

                Mail.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                TenNV.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                DiaChi.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

                if (int.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString()) == 1)
                    rdQT.Checked = true;
                else
                    rdNV.Checked = true;
                if (int.Parse(dataGridView1.CurrentRow.Cells[4].Value.ToString()) == 1)
                    rdON.Checked = true;
                else
                    rdOff.Checked = true;
            }
            else
            {
                MessageBox.Show("Bảng không tồn tại dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
