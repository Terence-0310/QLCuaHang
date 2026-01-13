namespace QuanLyCuaHangRuou.GUI
{
    partial class FrmDoUong
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDoUong));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.tableInputs = new System.Windows.Forms.TableLayoutPanel();
            this.lblMa = new System.Windows.Forms.Label();
            this.txtMaDoUong = new System.Windows.Forms.TextBox();
            this.lblTen = new System.Windows.Forms.Label();
            this.txtTenDoUong = new System.Windows.Forms.TextBox();
            this.lblDonGia = new System.Windows.Forms.Label();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.txtSoLuongTon = new System.Windows.Forms.TextBox();
            this.lblDungTich = new System.Windows.Forms.Label();
            this.txtDungTich = new System.Windows.Forms.TextBox();
            this.lblHanSuDung = new System.Windows.Forms.Label();
            this.dtpHanSuDung = new System.Windows.Forms.DateTimePicker();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.chkHanSuDung = new System.Windows.Forms.CheckBox();
            this.grpHinh = new System.Windows.Forms.GroupBox();
            this.picDoUong = new System.Windows.Forms.PictureBox();
            this.panelImageButtons = new System.Windows.Forms.Panel();
            this.btnChonHinh = new System.Windows.Forms.Button();
            this.btnXoaHinh = new System.Windows.Forms.Button();
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
            this.dgvDoUong = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.grpThongTin.SuspendLayout();
            this.tableInputs.SuspendLayout();
            this.grpHinh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDoUong)).BeginInit();
            this.panelImageButtons.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelSearch.SuspendLayout();
            this.panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoUong)).BeginInit();
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
            this.splitContainer.Panel1.Controls.Add(this.grpHinh);
            this.splitContainer.Panel1.Controls.Add(this.panelBottom);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.dgvDoUong);
            this.splitContainer.Size = new System.Drawing.Size(964, 541);
            this.splitContainer.SplitterDistance = 250;
            this.splitContainer.TabIndex = 0;
            // 
            // grpThongTin
            // 
            this.grpThongTin.Controls.Add(this.tableInputs);
            this.grpThongTin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpThongTin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpThongTin.Location = new System.Drawing.Point(0, 0);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(764, 200);
            this.grpThongTin.TabIndex = 0;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Thông tin đồ uống";
            // 
            // tableInputs
            // 
            this.tableInputs.ColumnCount = 4;
            this.tableInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableInputs.Controls.Add(this.lblMa, 0, 0);
            this.tableInputs.Controls.Add(this.txtMaDoUong, 1, 0);
            this.tableInputs.Controls.Add(this.lblTen, 0, 1);
            this.tableInputs.Controls.Add(this.txtTenDoUong, 1, 1);
            this.tableInputs.Controls.Add(this.lblDonGia, 2, 0);
            this.tableInputs.Controls.Add(this.txtDonGia, 3, 0);
            this.tableInputs.Controls.Add(this.lblSoLuong, 2, 1);
            this.tableInputs.Controls.Add(this.txtSoLuongTon, 3, 1);
            this.tableInputs.Controls.Add(this.lblDungTich, 0, 2);
            this.tableInputs.Controls.Add(this.txtDungTich, 1, 2);
            this.tableInputs.Controls.Add(this.lblHanSuDung, 2, 2);
            this.tableInputs.Controls.Add(this.dtpHanSuDung, 3, 2);
            this.tableInputs.Controls.Add(this.lblGhiChu, 0, 3);
            this.tableInputs.Controls.Add(this.txtGhiChu, 1, 3);
            this.tableInputs.Controls.Add(this.chkHanSuDung, 3, 3);
            this.tableInputs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableInputs.Location = new System.Drawing.Point(3, 19);
            this.tableInputs.Name = "tableInputs";
            this.tableInputs.RowCount = 4;
            this.tableInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableInputs.Size = new System.Drawing.Size(758, 178);
            this.tableInputs.TabIndex = 0;
            // 
            // lblMa
            // 
            this.lblMa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMa.Location = new System.Drawing.Point(3, 0);
            this.lblMa.Name = "lblMa";
            this.lblMa.Size = new System.Drawing.Size(94, 23);
            this.lblMa.TabIndex = 0;
            this.lblMa.Text = "Mã đồ uống:";
            this.lblMa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMaDoUong
            // 
            this.txtMaDoUong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaDoUong.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMaDoUong.Location = new System.Drawing.Point(103, 3);
            this.txtMaDoUong.Name = "txtMaDoUong";
            this.txtMaDoUong.Size = new System.Drawing.Size(273, 23);
            this.txtMaDoUong.TabIndex = 1;
            // 
            // lblTen
            // 
            this.lblTen.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTen.Location = new System.Drawing.Point(3, 35);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(94, 23);
            this.lblTen.TabIndex = 2;
            this.lblTen.Text = "Tên đồ uống:";
            this.lblTen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTenDoUong
            // 
            this.txtTenDoUong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTenDoUong.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTenDoUong.Location = new System.Drawing.Point(103, 38);
            this.txtTenDoUong.Name = "txtTenDoUong";
            this.txtTenDoUong.Size = new System.Drawing.Size(273, 23);
            this.txtTenDoUong.TabIndex = 3;
            // 
            // lblDonGia
            // 
            this.lblDonGia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDonGia.Location = new System.Drawing.Point(382, 0);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Size = new System.Drawing.Size(94, 23);
            this.lblDonGia.TabIndex = 4;
            this.lblDonGia.Text = "Đơn giá:";
            this.lblDonGia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDonGia
            // 
            this.txtDonGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDonGia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDonGia.Location = new System.Drawing.Point(482, 3);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(273, 23);
            this.txtDonGia.TabIndex = 5;
            this.txtDonGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDonGia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDonGia_KeyPress);
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSoLuong.Location = new System.Drawing.Point(382, 35);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(94, 23);
            this.lblSoLuong.TabIndex = 6;
            this.lblSoLuong.Text = "Số lượng tồn:";
            this.lblSoLuong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSoLuongTon
            // 
            this.txtSoLuongTon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSoLuongTon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSoLuongTon.Location = new System.Drawing.Point(482, 38);
            this.txtSoLuongTon.Name = "txtSoLuongTon";
            this.txtSoLuongTon.Size = new System.Drawing.Size(273, 23);
            this.txtSoLuongTon.TabIndex = 7;
            this.txtSoLuongTon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSoLuongTon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoLuongTon_KeyPress);
            // 
            // lblDungTich
            // 
            this.lblDungTich.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDungTich.Location = new System.Drawing.Point(3, 70);
            this.lblDungTich.Name = "lblDungTich";
            this.lblDungTich.Size = new System.Drawing.Size(94, 23);
            this.lblDungTich.TabIndex = 10;
            this.lblDungTich.Text = "Dung tích (ml):";
            this.lblDungTich.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDungTich
            // 
            this.txtDungTich.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDungTich.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDungTich.Location = new System.Drawing.Point(103, 73);
            this.txtDungTich.Name = "txtDungTich";
            this.txtDungTich.Size = new System.Drawing.Size(273, 23);
            this.txtDungTich.TabIndex = 11;
            this.txtDungTich.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDungTich.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDungTich_KeyPress);
            // 
            // lblHanSuDung
            // 
            this.lblHanSuDung.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHanSuDung.Location = new System.Drawing.Point(382, 70);
            this.lblHanSuDung.Name = "lblHanSuDung";
            this.lblHanSuDung.Size = new System.Drawing.Size(94, 23);
            this.lblHanSuDung.TabIndex = 12;
            this.lblHanSuDung.Text = "Hạn sử dụng:";
            this.lblHanSuDung.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpHanSuDung
            // 
            this.dtpHanSuDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpHanSuDung.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpHanSuDung.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHanSuDung.Location = new System.Drawing.Point(482, 73);
            this.dtpHanSuDung.Name = "dtpHanSuDung";
            this.dtpHanSuDung.Size = new System.Drawing.Size(273, 23);
            this.dtpHanSuDung.TabIndex = 13;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblGhiChu.Location = new System.Drawing.Point(3, 105);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(94, 23);
            this.lblGhiChu.TabIndex = 8;
            this.lblGhiChu.Text = "Ghi chú:";
            this.lblGhiChu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGhiChu
            // 
            this.tableInputs.SetColumnSpan(this.txtGhiChu, 2);
            this.txtGhiChu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGhiChu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtGhiChu.Location = new System.Drawing.Point(103, 108);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(373, 67);
            this.txtGhiChu.TabIndex = 9;
            // 
            // chkHanSuDung
            // 
            this.chkHanSuDung.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkHanSuDung.Location = new System.Drawing.Point(482, 108);
            this.chkHanSuDung.Name = "chkHanSuDung";
            this.chkHanSuDung.Size = new System.Drawing.Size(150, 23);
            this.chkHanSuDung.TabIndex = 14;
            this.chkHanSuDung.Text = "Có hạn sử dụng";
            this.chkHanSuDung.CheckedChanged += new System.EventHandler(this.chkHanSuDung_CheckedChanged);
            // 
            // grpHinh
            // 
            this.grpHinh.Controls.Add(this.picDoUong);
            this.grpHinh.Controls.Add(this.panelImageButtons);
            this.grpHinh.Dock = System.Windows.Forms.DockStyle.Right;
            this.grpHinh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpHinh.Location = new System.Drawing.Point(764, 0);
            this.grpHinh.Name = "grpHinh";
            this.grpHinh.Size = new System.Drawing.Size(200, 200);
            this.grpHinh.TabIndex = 1;
            this.grpHinh.TabStop = false;
            this.grpHinh.Text = "Hình ảnh";
            this.grpHinh.Enter += new System.EventHandler(this.grpHinh_Enter);
            // 
            // picDoUong
            // 
            this.picDoUong.BackColor = System.Drawing.Color.WhiteSmoke;
            this.picDoUong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picDoUong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picDoUong.Location = new System.Drawing.Point(3, 19);
            this.picDoUong.Name = "picDoUong";
            this.picDoUong.Size = new System.Drawing.Size(194, 148);
            this.picDoUong.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picDoUong.TabIndex = 0;
            this.picDoUong.TabStop = false;
            // 
            // panelImageButtons
            // 
            this.panelImageButtons.Controls.Add(this.btnChonHinh);
            this.panelImageButtons.Controls.Add(this.btnXoaHinh);
            this.panelImageButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelImageButtons.Location = new System.Drawing.Point(3, 167);
            this.panelImageButtons.Name = "panelImageButtons";
            this.panelImageButtons.Size = new System.Drawing.Size(194, 30);
            this.panelImageButtons.TabIndex = 1;
            // 
            // btnChonHinh
            // 
            this.btnChonHinh.Location = new System.Drawing.Point(3, 3);
            this.btnChonHinh.Name = "btnChonHinh";
            this.btnChonHinh.Size = new System.Drawing.Size(90, 25);
            this.btnChonHinh.TabIndex = 0;
            this.btnChonHinh.Text = "Chọn ảnh";
            this.btnChonHinh.Click += new System.EventHandler(this.btnChonHinh_Click);
            // 
            // btnXoaHinh
            // 
            this.btnXoaHinh.Location = new System.Drawing.Point(99, 3);
            this.btnXoaHinh.Name = "btnXoaHinh";
            this.btnXoaHinh.Size = new System.Drawing.Size(90, 25);
            this.btnXoaHinh.TabIndex = 1;
            this.btnXoaHinh.Text = "Xóa ảnh";
            this.btnXoaHinh.Click += new System.EventHandler(this.btnXoaHinh_Click);
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.panelSearch);
            this.panelBottom.Controls.Add(this.panelButtons);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 200);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(964, 50);
            this.panelBottom.TabIndex = 2;
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
            this.lblTim.Size = new System.Drawing.Size(60, 15);
            this.lblTim.TabIndex = 0;
            this.lblTim.Text = "Tìm kiếm:";
            // 
            // txtTim
            // 
            this.txtTim.Location = new System.Drawing.Point(86, 14);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(250, 23);
            this.txtTim.TabIndex = 1;
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(342, 12);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(75, 27);
            this.btnTim.TabIndex = 2;
            this.btnTim.Text = "Tìm";
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(423, 12);
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
            // dgvDoUong
            // 
            this.dgvDoUong.AllowUserToAddRows = false;
            this.dgvDoUong.AllowUserToDeleteRows = false;
            this.dgvDoUong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDoUong.BackgroundColor = System.Drawing.Color.White;
            this.dgvDoUong.ColumnHeadersHeight = 29;
            this.dgvDoUong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDoUong.Location = new System.Drawing.Point(0, 0);
            this.dgvDoUong.MultiSelect = false;
            this.dgvDoUong.Name = "dgvDoUong";
            this.dgvDoUong.ReadOnly = true;
            this.dgvDoUong.RowHeadersWidth = 51;
            this.dgvDoUong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDoUong.Size = new System.Drawing.Size(964, 287);
            this.dgvDoUong.TabIndex = 0;
            this.dgvDoUong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDoUong_CellClick);
            // 
            // FrmDoUong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.splitContainer);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmDoUong";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Quản lý đồ uống";
            this.Load += new System.EventHandler(this.FrmDoUong_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.grpThongTin.ResumeLayout(false);
            this.tableInputs.ResumeLayout(false);
            this.tableInputs.PerformLayout();
            this.grpHinh.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picDoUong)).EndInit();
            this.panelImageButtons.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoUong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.TableLayoutPanel tableInputs;
        private System.Windows.Forms.Label lblMa, lblTen, lblDonGia, lblSoLuong, lblDungTich, lblHanSuDung, lblGhiChu, lblTim;
        private System.Windows.Forms.TextBox txtMaDoUong, txtTenDoUong, txtDonGia, txtSoLuongTon, txtDungTich, txtGhiChu, txtTim;
        private System.Windows.Forms.DateTimePicker dtpHanSuDung;
        private System.Windows.Forms.CheckBox chkHanSuDung;
        private System.Windows.Forms.GroupBox grpHinh;
        private System.Windows.Forms.PictureBox picDoUong;
        private System.Windows.Forms.Panel panelImageButtons, panelBottom, panelSearch, panelButtons;
        private System.Windows.Forms.Button btnChonHinh, btnXoaHinh, btnTim, btnLamMoi, btnThem, btnSua, btnXoa, btnLuu, btnHuy;
        private System.Windows.Forms.DataGridView dgvDoUong;
    }
}
