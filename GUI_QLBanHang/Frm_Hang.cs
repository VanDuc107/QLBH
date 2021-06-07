using BUS_QLBanHang;
using DTO_QLBanHang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QLBanHang
{
    public partial class Frm_Hang : Form
    {
        BUS_Hang busHang = new BUS_Hang();
        string stremail = FmMain_QLBH.mail;
        //string checkUrImage;
        //string filename;
        //string fileSavePath;
        //string fileAddress;
        public Frm_Hang()
        {
            InitializeComponent();
        }
        private void LoadGridview_Hang()
        {
            dataGridView1.DataSource = busHang.getHang();
            dataGridView1.Columns[0].HeaderText = "Mã sản phẩm";
            dataGridView1.Columns[1].HeaderText = "Tên sản phẩm";
            dataGridView1.Columns[2].HeaderText = "Số lượng";
            dataGridView1.Columns[3].HeaderText = "Đơn giá nhập";
            dataGridView1.Columns[4].HeaderText = "Đơn giá bán";
            //dataGridView1.Columns[5].HeaderText = "Hình ảnh";
            dataGridView1.Columns[6].HeaderText = "Ghi chú";

        }

        public void ResetValues()
        {
            tbNhapHang.Text = "Nhập tên sản phẩm";
            tbMaHang.Text = null;
            tbTenHang.Text = null;
            tbSL.Text = null;
            tbDonGiaBan.Text = null;
            tbDonGiaNhap.Text = null;
            tbGhiChu.Text = null;
            tbMaHang.Enabled = false;
            tbTenHang.Enabled = false;
            tbSL.Enabled = false;
            tbDonGiaNhap.Enabled = false;
            tbDonGiaBan.Enabled = false;
            tbHinh.Enabled = false;
            tbGhiChu.Enabled = false;
        }

        private void FrmSanPham_Load(object sender, EventArgs e)
        {
            ResetValues();
            LoadGridview_Hang();
        }

        private void btthem_Click(object sender, EventArgs e)
        {
            tbMaHang.Text = null;
            tbTenHang.Text = null;
            tbSL.Text = null;
            tbDonGiaNhap.Text = null;
            tbDonGiaBan.Text = null;
            tbGhiChu.Text = null;
            tbMaHang.Enabled = false;
            tbTenHang.Enabled = true;
            tbSL.Enabled = true;
            tbDonGiaBan.Enabled = true;
            tbDonGiaNhap.Enabled = true;
            tbHinh.Enabled = true;
            tbGhiChu.Enabled = true;
            btLuu.Enabled = true;
        }

        private void btdong_Click(object sender, EventArgs e)
        {
            Visible = false;
            ShowInTaskbar = false;

            FmMain_QLBH main = new FmMain_QLBH();

            main.Activate();
            main.Show();
        }

        private void FrmSanPham_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private string PathImage = string.Empty;
        private string LastImage = string.Empty;
        private void btmo_Click(object sender, EventArgs e)
        {
            //Check folder ton tai
            string PathImages = Path.Combine(Directory.GetCurrentDirectory(), "Images");
            if (!File.Exists(PathImages)) //Neu ton tai
            {
                //Tao folder Images
                string path = Path.Combine(Directory.GetCurrentDirectory(), "Images");
                Directory.CreateDirectory(path);
            }
            LastImage = tbHinh.Text;
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)|*.*";
            dlgOpen.FilterIndex = 2;
            dlgOpen.Title = "Chọn hình ảnh minh họa cho sản phẩm";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image = Image.FromFile(dlgOpen.FileName);
                    tbHinh.Text = dlgOpen.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            dlgOpen.Dispose();
            //OpenFileDialog dlgOpen = new OpenFileDialog();
            //dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)|*.*";
            //dlgOpen.FilterIndex = 2;
            //dlgOpen.Title = "Chọn hình ảnh minh họa cho sản phẩm";
            //if (dlgOpen.ShowDialog() == DialogResult.OK)
            //{
            //    fileAddress = dlgOpen.FileName;
            //    pthinh.Image = Image.FromFile(fileAddress);
            //    filename = Path.GetFileName(dlgOpen.FileName);
            //    string saveDirectory = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
            //    fileSavePath = saveDirectory + "\\Images\\" + filename;
            //    tbhinh.Text = "\\Images\\" + filename;
            //    pthinh.SizeMode = PictureBoxSizeMode.StretchImage;
            //}

        }

        private void btluu_Click(object sender, EventArgs e)
        {
            #region Validation data
            int intSoLuong;
            bool isInt = int.TryParse(tbSL.Text.Trim().ToString(), out intSoLuong);
            float floatDonGiaNhap;
            bool isFloatNhap = float.TryParse(tbDonGiaNhap.Text.Trim().ToString(), out floatDonGiaNhap);
            float floatDonGiaBan;
            bool isFloatBan = float.TryParse(tbDonGiaBan.Text.Trim().ToString(), out floatDonGiaBan);
            if (tbTenHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (!isInt || int.Parse(tbSL.Text) < 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (!isFloatNhap || float.Parse(tbSL.Text) < 0)
            {
                MessageBox.Show("Bạn phải nhập giá nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (!isFloatBan || float.Parse(tbSL.Text) < 0)
            {
                MessageBox.Show("Bạn phải nhập giá bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (pictureBox1.Image == null) // Kiểm tra phải nhập hình
            {
                MessageBox.Show("Bạn phải upload hình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            #endregion
            else
            {
                string nameImage = string.Empty;
                try
                {
                    //Get name image
                    nameImage = tbHinh.Text.Substring(tbHinh.Text.LastIndexOf('\\') + 2);
                    pictureBox1.Image.Save(Path.Combine(Directory.GetCurrentDirectory(), "Images", nameImage));
                    DTO_Hang h = new DTO_Hang(
                        tbTenHang.Text,
                        int.Parse(tbSL.Text),
                        float.Parse(tbDonGiaNhap.Text),
                        float.Parse(tbDonGiaBan.Text),
                        Path.Combine("Images", nameImage),
                        tbGhiChu.Text, stremail);
                    if (busHang.insertHang(h))
                    {
                        MessageBox.Show("Thêm sản phẩm thành công");
                        //File.Copy(fileAddress, fileSavePath, true);
                        ResetValues();
                        LoadGridview_Hang();
                    }
                    else
                    {
                        MessageBox.Show("Thêm sản phẩm không thành công");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //int intSoLuong;
            //bool isInt = int.TryParse(tbsoluong.Text.Trim().ToString(), out intSoLuong);
            //float floatDonGiaNhap;
            //bool isFloatNhap = float.TryParse(tbdgnhap.Text.Trim().ToString(), out floatDonGiaNhap);
            //float floatDonBan;
            //bool isFloatBan = float.TryParse(tbdgnhap.Text.Trim().ToString(), out floatDonBan);
            //if(tbtensp.Text.Trim().Length == 0)
            //{
            //    MessageBox.Show("Bạn phải nhập tên sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    tbtensp.Focus();
            //    return;
            //}
            //else if(!isInt || int.Parse(tbsoluong.Text) < 0)
            //{
            //    MessageBox.Show("Bạn phải nhập số lượng > 0, số nguyên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    tbsoluong.Focus();
            //    return;
            //}
            //else if (!isFloatNhap || int.Parse(tbdgnhap.Text) < 0)
            //{
            //    MessageBox.Show("Bạn phải nhập đơn giá > 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    tbdgnhap.Focus();
            //    return;
            //}
            //else if (!isFloatBan || int.Parse(tbdgban.Text) < 0)
            //{
            //    MessageBox.Show("Bạn phải nhập đơn giá > 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    tbdgban.Focus();
            //    return;
            //}
            //else if(tbhinh.Text.Trim().Length == 0)
            //{
            //    MessageBox.Show("Bạn phải Upload hình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    btmo.Focus();
            //    return;
            //}
            //else
            //{
            //    DTO_Hang hang = new DTO_Hang(tbtensp.Text, int.Parse(tbsoluong.Text), float.Parse(tbdgnhap.Text), float.Parse(tbdgban.Text), "\\Images\\" + filename, tbghichu.Text, stremail);
            //    if (busHang.insertHang(hang))
            //    {
            //        MessageBox.Show("Thêm thành công");
            //        File.Copy(fileAddress, fileSavePath, true);
            //        ResetValues();
            //        LoadGridview_Hang();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Thêm không thành công");
            //    }
            //}
        }

        private void DgvHang_Click(object sender, EventArgs e)
        {
            try
            {
                string saveDirectory = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));

                tbMaHang.Text = dataGridView1.CurrentRow.Cells["MASP"].Value.ToString();
                tbTenHang.Text = dataGridView1.CurrentRow.Cells["TENSP"].Value.ToString();
                tbSL.Text = dataGridView1.CurrentRow.Cells["SOLUONG"].Value.ToString();
                tbDonGiaNhap.Text = dataGridView1.CurrentRow.Cells["DONGIANHAP"].Value.ToString();
                tbDonGiaBan.Text = dataGridView1.CurrentRow.Cells["DONGIABAN"].Value.ToString();
                tbHinh.Text = dataGridView1.CurrentRow.Cells["HINH"].Value.ToString();
                tbGhiChu.Text = dataGridView1.CurrentRow.Cells["GHICHU"].Value.ToString();
                pictureBox1.Image = Image.FromFile(Path.Combine(Directory.GetCurrentDirectory(), tbHinh.Text));
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                btLuu.Enabled = false;
                btXoa.Enabled = true;
                btSua.Enabled = true;

            }
            catch (Exception)
            {

            }
            tbTenHang.Enabled = true;
            tbSL.Enabled = true;
            tbDonGiaNhap.Enabled = true;
            tbDonGiaBan.Enabled = true;
            tbHinh.Enabled = true;
            tbGhiChu.Enabled = true;
            btMo.Enabled = true;
            btXoa.Enabled = true;
            btSua.Enabled = true;
            btList.Enabled = true;
            //string saveDirectory = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
            //if(dataGridViewsanpham.Rows.Count > 1)
            //{

            //    tbtensp.Enabled = true;
            //    tbsoluong.Enabled = true;
            //    tbdgnhap.Enabled = true;
            //    tbdgban.Enabled = true;
            //    tbghichu.Enabled = true;
            //    tbtensp.Focus();

            //    tbmasp.Text = dataGridViewsanpham.CurrentRow.Cells["MASP"].Value.ToString();
            //    tbtensp.Text = dataGridViewsanpham.CurrentRow.Cells["TENSP"].Value.ToString();
            //    tbsoluong.Text = dataGridViewsanpham.CurrentRow.Cells["SOLUONG"].Value.ToString();
            //    tbdgnhap.Text = dataGridViewsanpham.CurrentRow.Cells["DONGIANHAP"].Value.ToString();
            //    tbdgban.Text = dataGridViewsanpham.CurrentRow.Cells["DONGIABAN"].Value.ToString();
            //    tbhinh.Text = dataGridViewsanpham.CurrentRow.Cells["HINH"].Value.ToString();
            //    checkUrImage = tbhinh.Text;
            //    pthinh.Image = Image.FromFile(saveDirectory + dataGridViewsanpham.CurrentRow.Cells["HINH"].Value.ToString());
            //    tbghichu.Text = dataGridViewsanpham.CurrentRow.Cells["GHICHU"].Value.ToString();
            //}
            //else
            //{
            //    MessageBox.Show("Bảng không tồn tại dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            string mahang = tbMaHang.Text;

            if (MessageBox.Show("Bạn có chắc muốn xóa dữ liệu", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (busHang.DeleteHang(mahang))
                {
                    MessageBox.Show("Xóa dữ liệu thành công");
                    ResetValues();
                    LoadGridview_Hang();
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

            #region Validation data
            int intSoLuong;
            bool isInt = int.TryParse(tbSL.Text.Trim().ToString(), out intSoLuong);
            float floatDonGiaNhap;
            bool isFloatNhap = float.TryParse(tbDonGiaNhap.Text.Trim().ToString(), out floatDonGiaNhap);
            float floatDonGiaBan;
            bool isFloatBan = float.TryParse(tbDonGiaBan.Text.Trim().ToString(), out floatDonGiaBan);
            if (tbTenHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (!isInt || int.Parse(tbSL.Text) < 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (!isFloatNhap || float.Parse(tbDonGiaNhap.Text) < 0)
            {
                MessageBox.Show("Bạn phải nhập giá nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (!isFloatBan || float.Parse(tbDonGiaBan.Text) < 0)
            {
                MessageBox.Show("Bạn phải nhập giá bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (pictureBox1.Image == null) // Kiểm tra phải nhập hình
            {
                MessageBox.Show("Bạn phải upload hình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btMo.Focus();
                return;
            }
            #endregion
            else
            {
                string nameImage = string.Empty;
                try
                {
                    //Get name image

                    nameImage = tbHinh.Text.Substring(tbHinh.Text.LastIndexOf('\\') + 2);

                    pictureBox1.Image.Save(Path.Combine(Directory.GetCurrentDirectory(), "Images", nameImage));
                    DTO_Hang h = new DTO_Hang(int.Parse(tbMaHang.Text), tbTenHang.Text, int.Parse(tbSL.Text), float.Parse(tbDonGiaNhap.Text), float.Parse(tbDonGiaBan.Text), Path.Combine("Images", nameImage), tbGhiChu.Text);
                    if (MessageBox.Show("Bạn có chắc muốn chỉnh sửa", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (busHang.UpdateHang(h))
                        {
                            MessageBox.Show("Sửa thành công");

                            LoadGridview_Hang();

                            pictureBox1.Image = null;
                        }
                        else
                        {
                            MessageBox.Show("Sửa không thành công");
                        }
                    }
                    else
                    {

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //int intSoLuong;
            //bool isInt = int.TryParse(tbsoluong.Text.Trim().ToString(), out intSoLuong);
            //float floatDonGiaNhap;
            //bool isFloatNhap = float.TryParse(tbdgnhap.Text.Trim().ToString(), out floatDonGiaNhap);
            //float floatDonBan;
            //bool isFloatBan = float.TryParse(tbdgnhap.Text.Trim().ToString(), out floatDonBan);
            //if (tbtensp.Text.Trim().Length == 0)
            //{
            //    MessageBox.Show("Bạn phải nhập tên sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    tbtensp.Focus();
            //    return;
            //}
            //else if (!isInt || int.Parse(tbsoluong.Text) < 0)
            //{
            //    MessageBox.Show("Bạn phải nhập số lượng > 0, số nguyên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    tbsoluong.Focus();
            //    return;
            //}
            //else if (!isFloatNhap || int.Parse(tbdgnhap.Text) < 0)
            //{
            //    MessageBox.Show("Bạn phải nhập đơn giá > 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    tbdgnhap.Focus();
            //    return;
            //}
            //else if (!isFloatBan || int.Parse(tbdgban.Text) < 0)
            //{
            //    MessageBox.Show("Bạn phải nhập đơn giá > 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    tbdgban.Focus();
            //    return;
            //}
            //else if (tbhinh.Text.Trim().Length == 0)
            //{
            //    MessageBox.Show("Bạn phải Upload hình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    btmo.Focus();
            //    return;
            //}
            //else
            //{
            //    DTO_Hang hang = new DTO_Hang(int.Parse(tbmasp.Text), tbtensp.Text, int.Parse(tbsoluong.Text), float.Parse(tbdgnhap.Text), float.Parse(tbdgban.Text), "\\Images\\" + filename, tbghichu.Text, stremail);

            //    if (MessageBox.Show("Bạn có chắc muốn chỉnh sửa", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        if (busHang.UpdateHang(hang))
            //        {
            //            if (tbhinh.Text != checkUrImage)
            //                File.Copy(fileAddress, fileSavePath, true);
            //            MessageBox.Show("Sửa thành công");
            //            ResetValues();
            //            LoadGridview_Hang();
            //        }
            //        else
            //        {
            //            MessageBox.Show("Sửa không thành công");
            //        }
            //    }
            //    else
            //    {
            //        ResetValues();
            //    }
            //}
        }

        private void tbtimkiem_TextChanged(object sender, EventArgs e)
        {
            tbNhapHang.Text = null;
           tbNhapHang.BackColor = Color.White;
        }

        private void bttimkiem_Click(object sender, EventArgs e)
        {
            string mahang = tbNhapHang.Text;
            DataTable ds = busHang.SearchHang(mahang);
            if (ds.Rows.Count > 0)
            {
                dataGridView1.DataSource = ds;
                dataGridView1.Columns[0].HeaderText = "Mã Hàng";
                dataGridView1.Columns[1].HeaderText = "Tên Hàng";
                dataGridView1.Columns[2].HeaderText = "Số Lượng";
                dataGridView1.Columns[3].HeaderText = "Đơn giá nhập";
                dataGridView1.Columns[3].HeaderText = "Đơn giá bán";
                dataGridView1.Columns[3].HeaderText = "Hình ảnh";
                dataGridView1.Columns[3].HeaderText = "Ghi chú";

            }
            else
            {
                MessageBox.Show("Không tìm thấy sản phẩm nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            tbNhapHang.Text = "Nhập tên sản phẩm";
            tbNhapHang.BackColor = Color.LightGray;
            ResetValues();
        }


        private void btdanhsach_Click(object sender, EventArgs e)
        {
            ResetValues();
            LoadGridview_Hang();
        }
    }
}

