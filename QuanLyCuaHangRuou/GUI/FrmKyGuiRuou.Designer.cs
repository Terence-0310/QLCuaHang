namespace QuanLyCuaHangRuou.GUI
{
    partial class FrmKyGuiRuou
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmKyGuiRuou));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.tableInputs = new System.Windows.Forms.TableLayoutPanel();
            this.lblMaKyGui = new System.Windows.Forms.Label();
            this.txtMaKyGui = new System.Windows.Forms.TextBox();
            this.lblTenRuou = new System.Windows.Forms.Label();
            this.txtTenRuou = new System.Windows.Forms.TextBox();
            this.lblNgayKyGui = new System.Windows.Forms.Label();
            this.dtpNgayKyGui = new System.Windows.Forms.DateTimePicker();
            this.lblKhachHang = new System.Windows.Forms.Label();
            this.cboKhachHang = new System.Windows.Forms.ComboBox();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.nudSoLuong = new System.Windows.Forms.NumericUpDown();
            this.lblHanKyGui = new System.Windows.Forms.Label();
            this.dtpHanKyGui = new System.Windows.Forms.DateTimePicker();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.lblViTriLuuTru = new System.Windows.Forms.Label();
            this.cboViTriLuuTru = new System.Windows.Forms.ComboBox();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.lblTim = new System.Windows.Forms.Label();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.dgvKyGui = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.grpThongTin.SuspendLayout();
            this.tableInputs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.panelSearch.SuspendLayout();
            this.panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKyGui)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(10, 10);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.grpThongTin);
            this.splitContainer.Panel1.Controls.Add(this.panelBottom);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.dgvKyGui);
            this.splitContainer.Size = new System.Drawing.Size(964, 541);
            this.splitContainer.SplitterDistance = 185;
            this.splitContainer.TabIndex = 0;
            // 
            // grpThongTin
            // 
            this.grpThongTin.Controls.Add(this.tableInputs);
            this.grpThongTin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpThongTin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpThongTin.Location = new System.Drawing.Point(0, 0);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(964, 135);
            this.grpThongTin.TabIndex = 0;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Thông tin ký gửi";
            // 
            // tableInputs
            // 
            this.tableInputs.ColumnCount = 6;
            this.tableInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableInputs.Controls.Add(this.lblMaKyGui, 0, 0);
            this.tableInputs.Controls.Add(this.txtMaKyGui, 1, 0);
            this.tableInputs.Controls.Add(this.lblTenRuou, 2, 0);
            this.tableInputs.Controls.Add(this.txtTenRuou, 3, 0);
            this.tableInputs.Controls.Add(this.lblNgayKyGui, 4, 0);
            this.tableInputs.Controls.Add(this.dtpNgayKyGui, 5, 0);
            this.tableInputs.Controls.Add(this.lblKhachHang, 0, 1);
            this.tableInputs.Controls.Add(this.cboKhachHang, 1, 1);
            this.tableInputs.Controls.Add(this.lblSoLuong, 2, 1);
            this.tableInputs.Controls.Add(this.nudSoLuong, 3, 1);
            this.tableInputs.Controls.Add(this.lblHanKyGui, 4, 1);
            this.tableInputs.Controls.Add(this.dtpHanKyGui, 5, 1);
            this.tableInputs.Controls.Add(this.lblTrangThai, 0, 2);
            this.tableInputs.Controls.Add(this.cboTrangThai, 1, 2);
            this.tableInputs.Controls.Add(this.lblViTriLuuTru, 2, 2);
            this.tableInputs.Controls.Add(this.cboViTriLuuTru, 3, 2);
            this.tableInputs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableInputs.Location = new System.Drawing.Point(3, 23);
            this.tableInputs.Name = "tableInputs";
            this.tableInputs.RowCount = 3;
            this.tableInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableInputs.Size = new System.Drawing.Size(958, 109);
            this.tableInputs.TabIndex = 0;
            // 
            // lblMaKyGui
            // 
            this.lblMaKyGui.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMaKyGui.Location = new System.Drawing.Point(3, 0);
            this.lblMaKyGui.Name = "lblMaKyGui";
            this.lblMaKyGui.Size = new System.Drawing.Size(94, 23);
            this.lblMaKyGui.TabIndex = 0;
            this.lblMaKyGui.Text = "Mã ký gửi:";
            this.lblMaKyGui.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMaKyGui
            // 
            this.txtMaKyGui.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaKyGui.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMaKyGui.Location = new System.Drawing.Point(103, 3);
            this.txtMaKyGui.Name = "txtMaKyGui";
            this.txtMaKyGui.ReadOnly = true;
            this.txtMaKyGui.Size = new System.Drawing.Size(211, 27);
            this.txtMaKyGui.TabIndex = 1;
            // 
            // lblTenRuou
            // 
            this.lblTenRuou.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTenRuou.Location = new System.Drawing.Point(320, 0);
            this.lblTenRuou.Name = "lblTenRuou";
            this.lblTenRuou.Size = new System.Drawing.Size(94, 23);
            this.lblTenRuou.TabIndex = 2;
            this.lblTenRuou.Text = "Tên rượu:";
            this.lblTenRuou.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTenRuou
            // 
            this.txtTenRuou.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTenRuou.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTenRuou.Location = new System.Drawing.Point(420, 3);
            this.txtTenRuou.Name = "txtTenRuou";
            this.txtTenRuou.Size = new System.Drawing.Size(211, 27);
            this.txtTenRuou.TabIndex = 3;
            // 
            // lblNgayKyGui
            // 
            this.lblNgayKyGui.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNgayKyGui.Location = new System.Drawing.Point(637, 0);
            this.lblNgayKyGui.Name = "lblNgayKyGui";
            this.lblNgayKyGui.Size = new System.Drawing.Size(94, 23);
            this.lblNgayKyGui.TabIndex = 4;
            this.lblNgayKyGui.Text = "Ngày ký gửi:";
            this.lblNgayKyGui.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpNgayKyGui
            // 
            this.dtpNgayKyGui.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpNgayKyGui.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpNgayKyGui.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayKyGui.Location = new System.Drawing.Point(737, 3);
            this.dtpNgayKyGui.Name = "dtpNgayKyGui";
            this.dtpNgayKyGui.Size = new System.Drawing.Size(218, 27);
            this.dtpNgayKyGui.TabIndex = 5;
            // 
            // lblKhachHang
            // 
            this.lblKhachHang.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKhachHang.Location = new System.Drawing.Point(3, 35);
            this.lblKhachHang.Name = "lblKhachHang";
            this.lblKhachHang.Size = new System.Drawing.Size(94, 23);
            this.lblKhachHang.TabIndex = 6;
            this.lblKhachHang.Text = "Khách hàng:";
            this.lblKhachHang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboKhachHang
            // 
            this.cboKhachHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboKhachHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhachHang.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboKhachHang.Location = new System.Drawing.Point(103, 38);
            this.cboKhachHang.Name = "cboKhachHang";
            this.cboKhachHang.Size = new System.Drawing.Size(211, 28);
            this.cboKhachHang.TabIndex = 7;
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSoLuong.Location = new System.Drawing.Point(320, 35);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(94, 23);
            this.lblSoLuong.TabIndex = 8;
            this.lblSoLuong.Text = "Dung tích (ml):";
            this.lblSoLuong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudSoLuong
            // 
            this.nudSoLuong.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudSoLuong.Location = new System.Drawing.Point(420, 38);
            this.nudSoLuong.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudSoLuong.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSoLuong.Name = "nudSoLuong";
            this.nudSoLuong.Size = new System.Drawing.Size(120, 27);
            this.nudSoLuong.TabIndex = 9;
            this.nudSoLuong.Value = new decimal(new int[] {
            750,
            0,
            0,
            0});
            // 
            // lblHanKyGui
            // 
            this.lblHanKyGui.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHanKyGui.Location = new System.Drawing.Point(637, 35);
            this.lblHanKyGui.Name = "lblHanKyGui";
            this.lblHanKyGui.Size = new System.Drawing.Size(94, 23);
            this.lblHanKyGui.TabIndex = 10;
            this.lblHanKyGui.Text = "Hạn ký gửi:";
            this.lblHanKyGui.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpHanKyGui
            // 
            this.dtpHanKyGui.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpHanKyGui.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpHanKyGui.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHanKyGui.Location = new System.Drawing.Point(737, 38);
            this.dtpHanKyGui.Name = "dtpHanKyGui";
            this.dtpHanKyGui.Size = new System.Drawing.Size(218, 27);
            this.dtpHanKyGui.TabIndex = 11;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTrangThai.Location = new System.Drawing.Point(3, 70);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(94, 23);
            this.lblTrangThai.TabIndex = 12;
            this.lblTrangThai.Text = "Trạng thái:";
            this.lblTrangThai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboTrangThai.Location = new System.Drawing.Point(103, 73);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(211, 28);
            this.cboTrangThai.TabIndex = 13;
            // 
            // lblViTriLuuTru
            // 
            this.lblViTriLuuTru.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblViTriLuuTru.Location = new System.Drawing.Point(320, 70);
            this.lblViTriLuuTru.Name = "lblViTriLuuTru";
            this.lblViTriLuuTru.Size = new System.Drawing.Size(94, 23);
            this.lblViTriLuuTru.TabIndex = 14;
            this.lblViTriLuuTru.Text = "Vị trí lưu trữ:";
            this.lblViTriLuuTru.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboViTriLuuTru
            // 
            this.tableInputs.SetColumnSpan(this.cboViTriLuuTru, 3);
            this.cboViTriLuuTru.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboViTriLuuTru.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboViTriLuuTru.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboViTriLuuTru.Location = new System.Drawing.Point(420, 73);
            this.cboViTriLuuTru.Name = "cboViTriLuuTru";
            this.cboViTriLuuTru.Size = new System.Drawing.Size(535, 28);
            this.cboViTriLuuTru.TabIndex = 15;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.panelSearch);
            this.panelBottom.Controls.Add(this.panelButtons);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 135);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(964, 50);
            this.panelBottom.TabIndex = 1;
            // 
            // panelSearch
            // 
            this.panelSearch.Controls.Add(this.lblTim);
            this.panelSearch.Controls.Add(this.txtTim);
            this.panelSearch.Controls.Add(this.btnTim);
            this.panelSearch.Controls.Add(this.btnLamMoi);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSearch.Location = new System.Drawing.Point(0, 0);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(514, 50);
            this.panelSearch.TabIndex = 0;
            // 
            // lblTim
            // 
            this.lblTim.AutoSize = true;
            this.lblTim.Location = new System.Drawing.Point(8, 17);
            this.lblTim.Name = "lblTim";
            this.lblTim.Size = new System.Drawing.Size(73, 20);
            this.lblTim.TabIndex = 0;
            this.lblTim.Text = "Tìm kiếm:";
            // 
            // txtTim
            // 
            this.txtTim.Location = new System.Drawing.Point(86, 14);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(214, 27);
            this.txtTim.TabIndex = 1;
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(306, 12);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(75, 27);
            this.btnTim.TabIndex = 2;
            this.btnTim.Text = "Tìm";
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(387, 12);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(85, 27);
            this.btnLamMoi.TabIndex = 3;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnThem);
            this.panelButtons.Controls.Add(this.btnSua);
            this.panelButtons.Controls.Add(this.btnXoa);
            this.panelButtons.Controls.Add(this.btnLuu);
            this.panelButtons.Controls.Add(this.btnHuy);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelButtons.Location = new System.Drawing.Point(514, 0);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(450, 50);
            this.panelButtons.TabIndex = 1;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(8, 12);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(80, 27);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(94, 12);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(80, 27);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(180, 12);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(80, 27);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Location = new System.Drawing.Point(276, 12);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(80, 27);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.Gray;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(362, 12);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(80, 27);
            this.btnHuy.TabIndex = 4;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // dgvKyGui
            // 
            this.dgvKyGui.AllowUserToAddRows = false;
            this.dgvKyGui.AllowUserToDeleteRows = false;
            this.dgvKyGui.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKyGui.BackgroundColor = System.Drawing.Color.White;
            this.dgvKyGui.ColumnHeadersHeight = 29;
            this.dgvKyGui.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKyGui.Location = new System.Drawing.Point(0, 0);
            this.dgvKyGui.MultiSelect = false;
            this.dgvKyGui.Name = "dgvKyGui";
            this.dgvKyGui.ReadOnly = true;
            this.dgvKyGui.RowHeadersWidth = 51;
            this.dgvKyGui.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKyGui.Size = new System.Drawing.Size(964, 352);
            this.dgvKyGui.TabIndex = 0;
            this.dgvKyGui.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKyGui_CellClick);
            // 
            // FrmKyGuiRuou
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.splitContainer);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmKyGuiRuou";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Ký gửi rượu";
            this.Load += new System.EventHandler(this.FrmKyGuiRuou_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.grpThongTin.ResumeLayout(false);
            this.tableInputs.ResumeLayout(false);
            this.tableInputs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKyGui)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.TableLayoutPanel tableInputs;
        private System.Windows.Forms.Label lblMaKyGui;
        private System.Windows.Forms.TextBox txtMaKyGui;
        private System.Windows.Forms.Label lblTenRuou;
        private System.Windows.Forms.TextBox txtTenRuou;
        private System.Windows.Forms.Label lblKhachHang;
        private System.Windows.Forms.ComboBox cboKhachHang;
        private System.Windows.Forms.Label lblNgayKyGui;
        private System.Windows.Forms.DateTimePicker dtpNgayKyGui;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.NumericUpDown nudSoLuong;
        private System.Windows.Forms.Label lblHanKyGui;
        private System.Windows.Forms.DateTimePicker dtpHanKyGui;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Label lblViTriLuuTru;
        private System.Windows.Forms.ComboBox cboViTriLuuTru;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Label lblTim;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.DataGridView dgvKyGui;
    }
}
