namespace QuanLiNhanSu
{
    partial class NHANVIEN
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
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.dgvNhanVien = new System.Windows.Forms.DataGridView();
            this.k = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.a = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.b = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.e = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.f = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.h = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phố = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.bntThem = new System.Windows.Forms.Button();
            this.txtMaNhanVien = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.txtGioiTinh = new System.Windows.Forms.TextBox();
            this.cmbBangCap = new System.Windows.Forms.ComboBox();
            this.cmbPhongBan = new System.Windows.Forms.ComboBox();
            this.dtpNgayVaoLam = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbTinh = new System.Windows.Forms.ComboBox();
            this.cmbThanhPho = new System.Windows.Forms.ComboBox();
            this.cmbPhuong = new System.Windows.Forms.ComboBox();
            this.cmbPho = new System.Windows.Forms.ComboBox();
            this.cmbSoNha = new System.Windows.Forms.ComboBox();
            this.btnTimKiem1 = new System.Windows.Forms.Button();
            this.btnTimKiem4 = new System.Windows.Forms.Button();
            this.btnTimKiem3 = new System.Windows.Forms.Button();
            this.btnTimKiem2 = new System.Windows.Forms.Button();
            this.btnQuayLai1 = new System.Windows.Forms.Button();
            this.btnQuayLai4 = new System.Windows.Forms.Button();
            this.btnQuayLai3 = new System.Windows.Forms.Button();
            this.btnQuayLai2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).BeginInit();
            this.SuspendLayout();
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(182, 110);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(140, 20);
            this.txtHoTen.TabIndex = 42;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(446, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 31);
            this.label4.TabIndex = 41;
            this.label4.Text = "Nhân Viên";
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(582, 243);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 40;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(501, 243);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 39;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // dgvNhanVien
            // 
            this.dgvNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhanVien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.k,
            this.a,
            this.b,
            this.c,
            this.d,
            this.e,
            this.f,
            this.g,
            this.h,
            this.Column1,
            this.Column2,
            this.Phố,
            this.Column3});
            this.dgvNhanVien.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvNhanVien.Location = new System.Drawing.Point(0, 269);
            this.dgvNhanVien.Name = "dgvNhanVien";
            this.dgvNhanVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNhanVien.Size = new System.Drawing.Size(1027, 218);
            this.dgvNhanVien.TabIndex = 38;
            this.dgvNhanVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNhanVien_CellClick);
            this.dgvNhanVien.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvNhanVien_RowPrePaint);
            // 
            // k
            // 
            this.k.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.k.HeaderText = "STT";
            this.k.Name = "k";
            this.k.Width = 53;
            // 
            // a
            // 
            this.a.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.a.DataPropertyName = "IDNhanVien";
            this.a.HeaderText = "Mã ";
            this.a.Name = "a";
            this.a.Width = 47;
            // 
            // b
            // 
            this.b.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.b.DataPropertyName = "HoTen";
            this.b.HeaderText = "Họ tên";
            this.b.Name = "b";
            // 
            // c
            // 
            this.c.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.c.DataPropertyName = "TenPhongBan";
            this.c.HeaderText = "Phòng ban";
            this.c.Name = "c";
            // 
            // d
            // 
            this.d.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.d.DataPropertyName = "TenBangCap";
            this.d.HeaderText = "Bằng cấp";
            this.d.Name = "d";
            // 
            // e
            // 
            this.e.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.e.DataPropertyName = "NgaySinh";
            this.e.HeaderText = "Ngày sinh";
            this.e.Name = "e";
            // 
            // f
            // 
            this.f.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.f.DataPropertyName = "GioiTinh";
            this.f.HeaderText = "Giới tính";
            this.f.Name = "f";
            // 
            // g
            // 
            this.g.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.g.DataPropertyName = "NgayVaoLam";
            this.g.HeaderText = "Ngày vào làm";
            this.g.Name = "g";
            // 
            // h
            // 
            this.h.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.h.DataPropertyName = "TenTinh";
            this.h.HeaderText = "Tỉnh";
            this.h.Name = "h";
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "TenThanhPho";
            this.Column1.HeaderText = "Thành phố";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.DataPropertyName = "TenPhuong";
            this.Column2.HeaderText = "Phường";
            this.Column2.Name = "Column2";
            // 
            // Phố
            // 
            this.Phố.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Phố.DataPropertyName = "TenPho";
            this.Phố.HeaderText = "Phố";
            this.Phố.Name = "Phố";
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column3.DataPropertyName = "TenSoNha";
            this.Column3.HeaderText = "Số nhà";
            this.Column3.Name = "Column3";
            this.Column3.Width = 61;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(663, 243);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 37;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(420, 243);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 36;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(339, 243);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 35;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // bntThem
            // 
            this.bntThem.Location = new System.Drawing.Point(258, 243);
            this.bntThem.Name = "bntThem";
            this.bntThem.Size = new System.Drawing.Size(75, 23);
            this.bntThem.TabIndex = 34;
            this.bntThem.Text = "Thêm";
            this.bntThem.UseVisualStyleBackColor = true;
            this.bntThem.Click += new System.EventHandler(this.bntThem_Click);
            // 
            // txtMaNhanVien
            // 
            this.txtMaNhanVien.Location = new System.Drawing.Point(182, 80);
            this.txtMaNhanVien.Name = "txtMaNhanVien";
            this.txtMaNhanVien.Size = new System.Drawing.Size(140, 20);
            this.txtMaNhanVien.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(101, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Họ tên:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(101, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Mã nhân viên:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(101, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "Ngày sinh:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(377, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 44;
            this.label5.Text = "Phòng ban:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(377, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 45;
            this.label6.Text = "Bằng cấp:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(377, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 46;
            this.label7.Text = "Ngày vào làm:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(101, 181);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 47;
            this.label8.Text = "Giới tính:";
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgaySinh.Location = new System.Drawing.Point(182, 145);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(140, 20);
            this.dtpNgaySinh.TabIndex = 49;
            // 
            // txtGioiTinh
            // 
            this.txtGioiTinh.Location = new System.Drawing.Point(182, 174);
            this.txtGioiTinh.Name = "txtGioiTinh";
            this.txtGioiTinh.Size = new System.Drawing.Size(140, 20);
            this.txtGioiTinh.TabIndex = 50;
            // 
            // cmbBangCap
            // 
            this.cmbBangCap.FormattingEnabled = true;
            this.cmbBangCap.Location = new System.Drawing.Point(455, 80);
            this.cmbBangCap.Name = "cmbBangCap";
            this.cmbBangCap.Size = new System.Drawing.Size(121, 21);
            this.cmbBangCap.TabIndex = 51;
            // 
            // cmbPhongBan
            // 
            this.cmbPhongBan.FormattingEnabled = true;
            this.cmbPhongBan.Location = new System.Drawing.Point(455, 113);
            this.cmbPhongBan.Name = "cmbPhongBan";
            this.cmbPhongBan.Size = new System.Drawing.Size(121, 21);
            this.cmbPhongBan.TabIndex = 52;
            // 
            // dtpNgayVaoLam
            // 
            this.dtpNgayVaoLam.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayVaoLam.Location = new System.Drawing.Point(455, 145);
            this.dtpNgayVaoLam.Name = "dtpNgayVaoLam";
            this.dtpNgayVaoLam.Size = new System.Drawing.Size(121, 20);
            this.dtpNgayVaoLam.TabIndex = 53;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(652, 77);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 55;
            this.label10.Text = "Tỉnh:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(652, 145);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 13);
            this.label11.TabIndex = 56;
            this.label11.Text = "Phường, xã:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(652, 109);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 13);
            this.label12.TabIndex = 57;
            this.label12.Text = "Quận,huyện:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(652, 206);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 13);
            this.label13.TabIndex = 58;
            this.label13.Text = "Số nhà:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(655, 171);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 13);
            this.label14.TabIndex = 59;
            this.label14.Text = "Phố, làng:";
            // 
            // cmbTinh
            // 
            this.cmbTinh.FormattingEnabled = true;
            this.cmbTinh.Location = new System.Drawing.Point(729, 77);
            this.cmbTinh.Name = "cmbTinh";
            this.cmbTinh.Size = new System.Drawing.Size(121, 21);
            this.cmbTinh.TabIndex = 60;
            // 
            // cmbThanhPho
            // 
            this.cmbThanhPho.FormattingEnabled = true;
            this.cmbThanhPho.Location = new System.Drawing.Point(729, 109);
            this.cmbThanhPho.Name = "cmbThanhPho";
            this.cmbThanhPho.Size = new System.Drawing.Size(121, 21);
            this.cmbThanhPho.TabIndex = 61;
            // 
            // cmbPhuong
            // 
            this.cmbPhuong.FormattingEnabled = true;
            this.cmbPhuong.Location = new System.Drawing.Point(729, 142);
            this.cmbPhuong.Name = "cmbPhuong";
            this.cmbPhuong.Size = new System.Drawing.Size(121, 21);
            this.cmbPhuong.TabIndex = 62;
            // 
            // cmbPho
            // 
            this.cmbPho.FormattingEnabled = true;
            this.cmbPho.Location = new System.Drawing.Point(729, 171);
            this.cmbPho.Name = "cmbPho";
            this.cmbPho.Size = new System.Drawing.Size(121, 21);
            this.cmbPho.TabIndex = 63;
            // 
            // cmbSoNha
            // 
            this.cmbSoNha.FormattingEnabled = true;
            this.cmbSoNha.Location = new System.Drawing.Point(729, 198);
            this.cmbSoNha.Name = "cmbSoNha";
            this.cmbSoNha.Size = new System.Drawing.Size(121, 21);
            this.cmbSoNha.TabIndex = 64;
            // 
            // btnTimKiem1
            // 
            this.btnTimKiem1.Location = new System.Drawing.Point(866, 107);
            this.btnTimKiem1.Name = "btnTimKiem1";
            this.btnTimKiem1.Size = new System.Drawing.Size(68, 23);
            this.btnTimKiem1.TabIndex = 65;
            this.btnTimKiem1.Text = "Tìm kiếm";
            this.btnTimKiem1.UseVisualStyleBackColor = true;
            this.btnTimKiem1.Click += new System.EventHandler(this.btnTimKiem1_Click);
            // 
            // btnTimKiem4
            // 
            this.btnTimKiem4.Location = new System.Drawing.Point(866, 201);
            this.btnTimKiem4.Name = "btnTimKiem4";
            this.btnTimKiem4.Size = new System.Drawing.Size(68, 23);
            this.btnTimKiem4.TabIndex = 69;
            this.btnTimKiem4.Text = "Tìm kiếm";
            this.btnTimKiem4.UseVisualStyleBackColor = true;
            this.btnTimKiem4.Click += new System.EventHandler(this.btnTimKiem4_Click);
            // 
            // btnTimKiem3
            // 
            this.btnTimKiem3.Location = new System.Drawing.Point(866, 169);
            this.btnTimKiem3.Name = "btnTimKiem3";
            this.btnTimKiem3.Size = new System.Drawing.Size(68, 23);
            this.btnTimKiem3.TabIndex = 70;
            this.btnTimKiem3.Text = "Tìm kiếm";
            this.btnTimKiem3.UseVisualStyleBackColor = true;
            this.btnTimKiem3.Click += new System.EventHandler(this.btnTimKiem3_Click);
            // 
            // btnTimKiem2
            // 
            this.btnTimKiem2.Location = new System.Drawing.Point(866, 140);
            this.btnTimKiem2.Name = "btnTimKiem2";
            this.btnTimKiem2.Size = new System.Drawing.Size(68, 23);
            this.btnTimKiem2.TabIndex = 71;
            this.btnTimKiem2.Text = "Tìm kiếm";
            this.btnTimKiem2.UseVisualStyleBackColor = true;
            this.btnTimKiem2.Click += new System.EventHandler(this.btnTimKiem2_Click);
            // 
            // btnQuayLai1
            // 
            this.btnQuayLai1.Location = new System.Drawing.Point(940, 107);
            this.btnQuayLai1.Name = "btnQuayLai1";
            this.btnQuayLai1.Size = new System.Drawing.Size(75, 23);
            this.btnQuayLai1.TabIndex = 72;
            this.btnQuayLai1.Text = "Quay lại";
            this.btnQuayLai1.UseVisualStyleBackColor = true;
            this.btnQuayLai1.Click += new System.EventHandler(this.btnQuayLai1_Click);
            // 
            // btnQuayLai4
            // 
            this.btnQuayLai4.Location = new System.Drawing.Point(940, 201);
            this.btnQuayLai4.Name = "btnQuayLai4";
            this.btnQuayLai4.Size = new System.Drawing.Size(75, 23);
            this.btnQuayLai4.TabIndex = 73;
            this.btnQuayLai4.Text = "Quay lại";
            this.btnQuayLai4.UseVisualStyleBackColor = true;
            this.btnQuayLai4.Click += new System.EventHandler(this.btnQuayLai4_Click);
            // 
            // btnQuayLai3
            // 
            this.btnQuayLai3.Location = new System.Drawing.Point(940, 166);
            this.btnQuayLai3.Name = "btnQuayLai3";
            this.btnQuayLai3.Size = new System.Drawing.Size(75, 23);
            this.btnQuayLai3.TabIndex = 74;
            this.btnQuayLai3.Text = "Quay lại";
            this.btnQuayLai3.UseVisualStyleBackColor = true;
            this.btnQuayLai3.Click += new System.EventHandler(this.btnQuayLai3_Click);
            // 
            // btnQuayLai2
            // 
            this.btnQuayLai2.Location = new System.Drawing.Point(940, 136);
            this.btnQuayLai2.Name = "btnQuayLai2";
            this.btnQuayLai2.Size = new System.Drawing.Size(75, 23);
            this.btnQuayLai2.TabIndex = 75;
            this.btnQuayLai2.Text = "Quay lại";
            this.btnQuayLai2.UseVisualStyleBackColor = true;
            this.btnQuayLai2.Click += new System.EventHandler(this.btnQuayLai2_Click);
            // 
            // NHANVIEN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 487);
            this.Controls.Add(this.btnQuayLai2);
            this.Controls.Add(this.btnQuayLai3);
            this.Controls.Add(this.btnQuayLai4);
            this.Controls.Add(this.btnQuayLai1);
            this.Controls.Add(this.btnTimKiem2);
            this.Controls.Add(this.btnTimKiem3);
            this.Controls.Add(this.btnTimKiem4);
            this.Controls.Add(this.btnTimKiem1);
            this.Controls.Add(this.cmbSoNha);
            this.Controls.Add(this.cmbPho);
            this.Controls.Add(this.cmbPhuong);
            this.Controls.Add(this.cmbThanhPho);
            this.Controls.Add(this.cmbTinh);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dtpNgayVaoLam);
            this.Controls.Add(this.cmbPhongBan);
            this.Controls.Add(this.cmbBangCap);
            this.Controls.Add(this.txtGioiTinh);
            this.Controls.Add(this.dtpNgaySinh);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.dgvNhanVien);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.bntThem);
            this.Controls.Add(this.txtMaNhanVien);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "NHANVIEN";
            this.Text = "Nhân Viên";
            this.Load += new System.EventHandler(this.NHANVIEN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.DataGridView dgvNhanVien;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button bntThem;
        private System.Windows.Forms.TextBox txtMaNhanVien;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.TextBox txtGioiTinh;
        private System.Windows.Forms.ComboBox cmbBangCap;
        private System.Windows.Forms.ComboBox cmbPhongBan;
        private System.Windows.Forms.DateTimePicker dtpNgayVaoLam;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbTinh;
        private System.Windows.Forms.ComboBox cmbThanhPho;
        private System.Windows.Forms.ComboBox cmbPhuong;
        private System.Windows.Forms.ComboBox cmbPho;
        private System.Windows.Forms.ComboBox cmbSoNha;
        private System.Windows.Forms.Button btnTimKiem1;
        private System.Windows.Forms.Button btnTimKiem4;
        private System.Windows.Forms.Button btnTimKiem3;
        private System.Windows.Forms.Button btnTimKiem2;
        private System.Windows.Forms.Button btnQuayLai1;
        private System.Windows.Forms.Button btnQuayLai4;
        private System.Windows.Forms.Button btnQuayLai3;
        private System.Windows.Forms.Button btnQuayLai2;
        private System.Windows.Forms.DataGridViewTextBoxColumn k;
        private System.Windows.Forms.DataGridViewTextBoxColumn a;
        private System.Windows.Forms.DataGridViewTextBoxColumn b;
        private System.Windows.Forms.DataGridViewTextBoxColumn c;
        private System.Windows.Forms.DataGridViewTextBoxColumn d;
        private System.Windows.Forms.DataGridViewTextBoxColumn e;
        private System.Windows.Forms.DataGridViewTextBoxColumn f;
        private System.Windows.Forms.DataGridViewTextBoxColumn g;
        private System.Windows.Forms.DataGridViewTextBoxColumn h;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phố;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}