namespace GUI_QLBanHang
{
    partial class Frm_NhanVien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btTimKiem = new System.Windows.Forms.Button();
            this.tbNhap = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.rdOff = new System.Windows.Forms.RadioButton();
            this.rdON = new System.Windows.Forms.RadioButton();
            this.rdQT = new System.Windows.Forms.RadioButton();
            this.rdNV = new System.Windows.Forms.RadioButton();
            this.DiaChi = new System.Windows.Forms.TextBox();
            this.Mail = new System.Windows.Forms.TextBox();
            this.TenNV = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btClose = new System.Windows.Forms.Button();
            this.btList = new System.Windows.Forms.Button();
            this.btLuu = new System.Windows.Forms.Button();
            this.btSua = new System.Windows.Forms.Button();
            this.btXoa = new System.Windows.Forms.Button();
            this.btThem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btTimKiem
            // 
            this.btTimKiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btTimKiem.Location = new System.Drawing.Point(445, 369);
            this.btTimKiem.Name = "btTimKiem";
            this.btTimKiem.Size = new System.Drawing.Size(80, 36);
            this.btTimKiem.TabIndex = 38;
            this.btTimKiem.Text = "Tìm Kiếm";
            this.btTimKiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btTimKiem.UseVisualStyleBackColor = true;
            // 
            // tbNhap
            // 
            this.tbNhap.Location = new System.Drawing.Point(258, 385);
            this.tbNhap.Name = "tbNhap";
            this.tbNhap.Size = new System.Drawing.Size(181, 20);
            this.tbNhap.TabIndex = 37;
            this.tbNhap.Text = "Nhập tên Nhân Viên";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(89, 194);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(624, 150);
            this.dataGridView1.TabIndex = 36;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // rdOff
            // 
            this.rdOff.AutoSize = true;
            this.rdOff.Location = new System.Drawing.Point(628, 148);
            this.rdOff.Name = "rdOff";
            this.rdOff.Size = new System.Drawing.Size(85, 17);
            this.rdOff.TabIndex = 35;
            this.rdOff.TabStop = true;
            this.rdOff.Text = "Đã nghỉ việc";
            this.rdOff.UseVisualStyleBackColor = true;
            // 
            // rdON
            // 
            this.rdON.AutoSize = true;
            this.rdON.Location = new System.Drawing.Point(503, 148);
            this.rdON.Name = "rdON";
            this.rdON.Size = new System.Drawing.Size(93, 17);
            this.rdON.TabIndex = 34;
            this.rdON.TabStop = true;
            this.rdON.Text = "Đang làm việc";
            this.rdON.UseVisualStyleBackColor = true;
            // 
            // rdQT
            // 
            this.rdQT.AutoSize = true;
            this.rdQT.Location = new System.Drawing.Point(276, 148);
            this.rdQT.Name = "rdQT";
            this.rdQT.Size = new System.Drawing.Size(66, 17);
            this.rdQT.TabIndex = 33;
            this.rdQT.TabStop = true;
            this.rdQT.Text = "Quản Trị";
            this.rdQT.UseVisualStyleBackColor = true;
            // 
            // rdNV
            // 
            this.rdNV.AutoSize = true;
            this.rdNV.Location = new System.Drawing.Point(172, 148);
            this.rdNV.Name = "rdNV";
            this.rdNV.Size = new System.Drawing.Size(75, 17);
            this.rdNV.TabIndex = 32;
            this.rdNV.TabStop = true;
            this.rdNV.Text = "Nhân Viên";
            this.rdNV.UseVisualStyleBackColor = true;
            // 
            // DiaChi
            // 
            this.DiaChi.Location = new System.Drawing.Point(503, 62);
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.Size = new System.Drawing.Size(160, 20);
            this.DiaChi.TabIndex = 31;
            // 
            // Mail
            // 
            this.Mail.Location = new System.Drawing.Point(172, 102);
            this.Mail.Name = "Mail";
            this.Mail.Size = new System.Drawing.Size(166, 20);
            this.Mail.TabIndex = 30;
            // 
            // TenNV
            // 
            this.TenNV.Location = new System.Drawing.Point(172, 62);
            this.TenNV.Name = "TenNV";
            this.TenNV.Size = new System.Drawing.Size(166, 20);
            this.TenNV.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(442, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Địa Chỉ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(424, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Tình Trạng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(86, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Vai Trò";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(86, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Tên Nhân Viên";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(270, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 32);
            this.label1.TabIndex = 23;
            this.label1.Text = "QUẢN LÝ NHÂN VIÊN";
            // 
            // btClose
            // 
            this.btClose.Image = global::GUI_QLBanHang.Properties.Resources.Custom_Icon_Design_Pretty_Office_9_Delete_file;
            this.btClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btClose.Location = new System.Drawing.Point(666, 432);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 36);
            this.btClose.TabIndex = 69;
            this.btClose.Text = "Đóng";
            this.btClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btClose.UseVisualStyleBackColor = true;
            // 
            // btList
            // 
            this.btList.Image = global::GUI_QLBanHang.Properties.Resources.Icons8_Windows_8_Food_List_Ingredients;
            this.btList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btList.Location = new System.Drawing.Point(523, 432);
            this.btList.Name = "btList";
            this.btList.Size = new System.Drawing.Size(97, 36);
            this.btList.TabIndex = 68;
            this.btList.Text = "Danh Sách";
            this.btList.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btList.UseVisualStyleBackColor = true;
            // 
            // btLuu
            // 
            this.btLuu.Image = global::GUI_QLBanHang.Properties.Resources.Flat_Icons_com_Square_Save;
            this.btLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btLuu.Location = new System.Drawing.Point(408, 432);
            this.btLuu.Name = "btLuu";
            this.btLuu.Size = new System.Drawing.Size(75, 36);
            this.btLuu.TabIndex = 67;
            this.btLuu.Text = "Lưu";
            this.btLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btLuu.UseVisualStyleBackColor = true;
            // 
            // btSua
            // 
            this.btSua.Image = global::GUI_QLBanHang.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_document_edit;
            this.btSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSua.Location = new System.Drawing.Point(298, 432);
            this.btSua.Name = "btSua";
            this.btSua.Size = new System.Drawing.Size(75, 36);
            this.btSua.TabIndex = 66;
            this.btSua.Text = "Sửa";
            this.btSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btSua.UseVisualStyleBackColor = true;
            // 
            // btXoa
            // 
            this.btXoa.Image = global::GUI_QLBanHang.Properties.Resources.Hopstarter_Sleek_Xp_Basic_Close_2;
            this.btXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btXoa.Location = new System.Drawing.Point(181, 432);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(75, 36);
            this.btXoa.TabIndex = 65;
            this.btXoa.Text = "Xóa";
            this.btXoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btXoa.UseVisualStyleBackColor = true;
            // 
            // btThem
            // 
            this.btThem.Image = global::GUI_QLBanHang.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_list_add_user;
            this.btThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btThem.Location = new System.Drawing.Point(66, 432);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(82, 36);
            this.btThem.TabIndex = 64;
            this.btThem.Text = "Thêm";
            this.btThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btThem.UseVisualStyleBackColor = true;
            // 
            // Frm_NhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 501);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btList);
            this.Controls.Add(this.btLuu);
            this.Controls.Add(this.btSua);
            this.Controls.Add(this.btXoa);
            this.Controls.Add(this.btThem);
            this.Controls.Add(this.btTimKiem);
            this.Controls.Add(this.tbNhap);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.rdOff);
            this.Controls.Add(this.rdON);
            this.Controls.Add(this.rdQT);
            this.Controls.Add(this.rdNV);
            this.Controls.Add(this.DiaChi);
            this.Controls.Add(this.Mail);
            this.Controls.Add(this.TenNV);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Frm_NhanVien";
            this.Text = "Frm_NhanVien";
            this.Load += new System.EventHandler(this.Frm_NhanVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btTimKiem;
        private System.Windows.Forms.TextBox tbNhap;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RadioButton rdOff;
        private System.Windows.Forms.RadioButton rdON;
        private System.Windows.Forms.RadioButton rdQT;
        private System.Windows.Forms.RadioButton rdNV;
        private System.Windows.Forms.TextBox DiaChi;
        private System.Windows.Forms.TextBox Mail;
        private System.Windows.Forms.TextBox TenNV;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btList;
        private System.Windows.Forms.Button btLuu;
        private System.Windows.Forms.Button btSua;
        private System.Windows.Forms.Button btXoa;
        private System.Windows.Forms.Button btThem;
    }
}