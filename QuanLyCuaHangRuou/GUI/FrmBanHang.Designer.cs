namespace QuanLyCuaHangRuou.GUI
{
    partial class FrmBanHang
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBanHang));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.tableHeader = new System.Windows.Forms.TableLayoutPanel();
            this.lblMaHD = new System.Windows.Forms.Label();
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.lblNgayHD = new System.Windows.Forms.Label();
            this.dtpNgay = new System.Windows.Forms.DateTimePicker();
            this.lblKH = new System.Windows.Forms.Label();
            this.cboKhachHang = new System.Windows.Forms.ComboBox();
            this.lblNVLabel = new System.Windows.Forms.Label();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.grpChon = new System.Windows.Forms.GroupBox();
            this.tableChon = new System.Windows.Forms.TableLayoutPanel();
            this.lblDoUong = new System.Windows.Forms.Label();
            this.cboDoUong = new System.Windows.Forms.ComboBox();
            this.lblDonGia = new System.Windows.Forms.Label();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.lblSL = new System.Windows.Forms.Label();
            this.nudSoLuong = new System.Windows.Forms.NumericUpDown();
            this.btnThemVaoGio = new System.Windows.Forms.Button();
            this.dgvGioHang = new System.Windows.Forms.DataGridView();
            this.colMa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.lblTongTienValue = new System.Windows.Forms.Label();
            this.flowButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnXoaDong = new System.Windows.Forms.Button();
            this.btnXoaHet = new System.Windows.Forms.Button();
            this.btnThanhToan = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.grpThongTin.SuspendLayout();
            this.tableHeader.SuspendLayout();
            this.grpChon.SuspendLayout();
            this.tableChon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGioHang)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.flowButtons.SuspendLayout();
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
            this.splitContainer.Panel1.Controls.Add(this.grpChon);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.dgvGioHang);
            this.splitContainer.Panel2.Controls.Add(this.panelBottom);
            this.splitContainer.Size = new System.Drawing.Size(964, 541);
            this.splitContainer.SplitterDistance = 180;
            this.splitContainer.TabIndex = 0;
            // 
            // grpThongTin
            // 
            this.grpThongTin.Controls.Add(this.tableHeader);
            this.grpThongTin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpThongTin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpThongTin.Location = new System.Drawing.Point(0, 0);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(964, 90);
            this.grpThongTin.TabIndex = 0;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Thông tin hóa đơn";
            // 
            // tableHeader
            // 
            this.tableHeader.ColumnCount = 4;
            this.tableHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableHeader.Controls.Add(this.lblMaHD, 0, 0);
            this.tableHeader.Controls.Add(this.txtMaHD, 1, 0);
            this.tableHeader.Controls.Add(this.lblNgayHD, 2, 0);
            this.tableHeader.Controls.Add(this.dtpNgay, 3, 0);
            this.tableHeader.Controls.Add(this.lblKH, 0, 1);
            this.tableHeader.Controls.Add(this.cboKhachHang, 1, 1);
            this.tableHeader.Controls.Add(this.lblNVLabel, 2, 1);
            this.tableHeader.Controls.Add(this.lblNhanVien, 3, 1);
            this.tableHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableHeader.Location = new System.Drawing.Point(3, 23);
            this.tableHeader.Name = "tableHeader";
            this.tableHeader.RowCount = 2;
            this.tableHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableHeader.Size = new System.Drawing.Size(958, 64);
            this.tableHeader.TabIndex = 0;
            // 
            // lblMaHD
            // 
            this.lblMaHD.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMaHD.Location = new System.Drawing.Point(3, 0);
            this.lblMaHD.Name = "lblMaHD";
            this.lblMaHD.Size = new System.Drawing.Size(94, 23);
            this.lblMaHD.TabIndex = 0;
            this.lblMaHD.Text = "Mã HĐ:";
            this.lblMaHD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMaHD
            // 
            this.txtMaHD.BackColor = System.Drawing.Color.LightYellow;
            this.txtMaHD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaHD.Location = new System.Drawing.Point(103, 3);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.ReadOnly = true;
            this.txtMaHD.Size = new System.Drawing.Size(373, 27);
            this.txtMaHD.TabIndex = 1;
            // 
            // lblNgayHD
            // 
            this.lblNgayHD.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNgayHD.Location = new System.Drawing.Point(482, 0);
            this.lblNgayHD.Name = "lblNgayHD";
            this.lblNgayHD.Size = new System.Drawing.Size(94, 23);
            this.lblNgayHD.TabIndex = 2;
            this.lblNgayHD.Text = "Ngày HĐ:";
            this.lblNgayHD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpNgay
            // 
            this.dtpNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgay.Location = new System.Drawing.Point(582, 3);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(373, 27);
            this.dtpNgay.TabIndex = 3;
            // 
            // lblKH
            // 
            this.lblKH.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKH.Location = new System.Drawing.Point(3, 35);
            this.lblKH.Name = "lblKH";
            this.lblKH.Size = new System.Drawing.Size(94, 23);
            this.lblKH.TabIndex = 4;
            this.lblKH.Text = "Khách hàng:";
            this.lblKH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboKhachHang
            // 
            this.cboKhachHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboKhachHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhachHang.Location = new System.Drawing.Point(103, 38);
            this.cboKhachHang.Name = "cboKhachHang";
            this.cboKhachHang.Size = new System.Drawing.Size(373, 28);
            this.cboKhachHang.TabIndex = 5;
            // 
            // lblNVLabel
            // 
            this.lblNVLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNVLabel.Location = new System.Drawing.Point(482, 35);
            this.lblNVLabel.Name = "lblNVLabel";
            this.lblNVLabel.Size = new System.Drawing.Size(94, 23);
            this.lblNVLabel.TabIndex = 6;
            this.lblNVLabel.Text = "Nhân viên:";
            this.lblNVLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNhanVien.Location = new System.Drawing.Point(582, 35);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(200, 23);
            this.lblNhanVien.TabIndex = 7;
            this.lblNhanVien.Text = "NV";
            this.lblNhanVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpChon
            // 
            this.grpChon.Controls.Add(this.tableChon);
            this.grpChon.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpChon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpChon.Location = new System.Drawing.Point(0, 90);
            this.grpChon.Name = "grpChon";
            this.grpChon.Size = new System.Drawing.Size(964, 90);
            this.grpChon.TabIndex = 1;
            this.grpChon.TabStop = false;
            this.grpChon.Text = "Chọn đồ uống";
            // 
            // tableChon
            // 
            this.tableChon.ColumnCount = 6;
            this.tableChon.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableChon.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableChon.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableChon.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableChon.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableChon.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableChon.Controls.Add(this.lblDoUong, 0, 0);
            this.tableChon.Controls.Add(this.cboDoUong, 1, 0);
            this.tableChon.Controls.Add(this.lblDonGia, 2, 0);
            this.tableChon.Controls.Add(this.txtDonGia, 3, 0);
            this.tableChon.Controls.Add(this.lblSL, 4, 0);
            this.tableChon.Controls.Add(this.nudSoLuong, 5, 0);
            this.tableChon.Controls.Add(this.btnThemVaoGio, 5, 1);
            this.tableChon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableChon.Location = new System.Drawing.Point(3, 23);
            this.tableChon.Name = "tableChon";
            this.tableChon.RowCount = 2;
            this.tableChon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableChon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableChon.Size = new System.Drawing.Size(958, 64);
            this.tableChon.TabIndex = 0;
            // 
            // lblDoUong
            // 
            this.lblDoUong.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDoUong.Location = new System.Drawing.Point(3, 0);
            this.lblDoUong.Name = "lblDoUong";
            this.lblDoUong.Size = new System.Drawing.Size(74, 23);
            this.lblDoUong.TabIndex = 0;
            this.lblDoUong.Text = "Đồ uống:";
            this.lblDoUong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboDoUong
            // 
            this.cboDoUong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboDoUong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDoUong.Location = new System.Drawing.Point(83, 3);
            this.cboDoUong.Name = "cboDoUong";
            this.cboDoUong.Size = new System.Drawing.Size(281, 28);
            this.cboDoUong.TabIndex = 1;
            this.cboDoUong.SelectedIndexChanged += new System.EventHandler(this.cboDoUong_SelectedIndexChanged);
            // 
            // lblDonGia
            // 
            this.lblDonGia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDonGia.Location = new System.Drawing.Point(370, 0);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Size = new System.Drawing.Size(74, 23);
            this.lblDonGia.TabIndex = 2;
            this.lblDonGia.Text = "Đơn giá:";
            this.lblDonGia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDonGia
            // 
            this.txtDonGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDonGia.Location = new System.Drawing.Point(450, 3);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.ReadOnly = true;
            this.txtDonGia.Size = new System.Drawing.Size(173, 27);
            this.txtDonGia.TabIndex = 3;
            this.txtDonGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSL
            // 
            this.lblSL.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSL.Location = new System.Drawing.Point(629, 0);
            this.lblSL.Name = "lblSL";
            this.lblSL.Size = new System.Drawing.Size(74, 23);
            this.lblSL.TabIndex = 4;
            this.lblSL.Text = "Số lượng:";
            this.lblSL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudSoLuong
            // 
            this.nudSoLuong.Location = new System.Drawing.Point(709, 3);
            this.nudSoLuong.Maximum = new decimal(new int[] {
            9999,
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
            this.nudSoLuong.TabIndex = 5;
            this.nudSoLuong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnThemVaoGio
            // 
            this.btnThemVaoGio.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnThemVaoGio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnThemVaoGio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemVaoGio.ForeColor = System.Drawing.Color.White;
            this.btnThemVaoGio.Location = new System.Drawing.Point(825, 39);
            this.btnThemVaoGio.Name = "btnThemVaoGio";
            this.btnThemVaoGio.Size = new System.Drawing.Size(130, 27);
            this.btnThemVaoGio.TabIndex = 6;
            this.btnThemVaoGio.Text = "Thêm vào giỏ";
            this.btnThemVaoGio.UseVisualStyleBackColor = false;
            this.btnThemVaoGio.Click += new System.EventHandler(this.btnThemVaoGio_Click);
            // 
            // dgvGioHang
            // 
            this.dgvGioHang.AllowUserToAddRows = false;
            this.dgvGioHang.AllowUserToDeleteRows = false;
            this.dgvGioHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGioHang.BackgroundColor = System.Drawing.Color.White;
            this.dgvGioHang.ColumnHeadersHeight = 29;
            this.dgvGioHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMa,
            this.colTen,
            this.colDonGia,
            this.colSL,
            this.colThanhTien});
            this.dgvGioHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGioHang.Location = new System.Drawing.Point(0, 0);
            this.dgvGioHang.MultiSelect = false;
            this.dgvGioHang.Name = "dgvGioHang";
            this.dgvGioHang.ReadOnly = true;
            this.dgvGioHang.RowHeadersWidth = 51;
            this.dgvGioHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGioHang.Size = new System.Drawing.Size(964, 307);
            this.dgvGioHang.TabIndex = 0;
            // 
            // colMa
            // 
            this.colMa.FillWeight = 80F;
            this.colMa.HeaderText = "Mã";
            this.colMa.MinimumWidth = 6;
            this.colMa.Name = "colMa";
            this.colMa.ReadOnly = true;
            // 
            // colTen
            // 
            this.colTen.FillWeight = 150F;
            this.colTen.HeaderText = "Tên đồ uống";
            this.colTen.MinimumWidth = 6;
            this.colTen.Name = "colTen";
            this.colTen.ReadOnly = true;
            // 
            // colDonGia
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            this.colDonGia.DefaultCellStyle = dataGridViewCellStyle1;
            this.colDonGia.HeaderText = "Đơn giá";
            this.colDonGia.MinimumWidth = 6;
            this.colDonGia.Name = "colDonGia";
            this.colDonGia.ReadOnly = true;
            // 
            // colSL
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colSL.DefaultCellStyle = dataGridViewCellStyle2;
            this.colSL.FillWeight = 50F;
            this.colSL.HeaderText = "SL";
            this.colSL.MinimumWidth = 6;
            this.colSL.Name = "colSL";
            this.colSL.ReadOnly = true;
            // 
            // colThanhTien
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            this.colThanhTien.DefaultCellStyle = dataGridViewCellStyle3;
            this.colThanhTien.HeaderText = "Thành tiền";
            this.colThanhTien.MinimumWidth = 6;
            this.colThanhTien.Name = "colThanhTien";
            this.colThanhTien.ReadOnly = true;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.lblTongTien);
            this.panelBottom.Controls.Add(this.lblTongTienValue);
            this.panelBottom.Controls.Add(this.flowButtons);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 307);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(964, 50);
            this.panelBottom.TabIndex = 1;
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.Location = new System.Drawing.Point(10, 12);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(125, 28);
            this.lblTongTien.TabIndex = 0;
            this.lblTongTien.Text = "TỔNG TIỀN:";
            // 
            // lblTongTienValue
            // 
            this.lblTongTienValue.AutoSize = true;
            this.lblTongTienValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTongTienValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.lblTongTienValue.Location = new System.Drawing.Point(100, 10);
            this.lblTongTienValue.Name = "lblTongTienValue";
            this.lblTongTienValue.Size = new System.Drawing.Size(28, 32);
            this.lblTongTienValue.TabIndex = 1;
            this.lblTongTienValue.Text = "0";
            // 
            // flowButtons
            // 
            this.flowButtons.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.flowButtons.AutoSize = true;
            this.flowButtons.Controls.Add(this.btnXoaDong);
            this.flowButtons.Controls.Add(this.btnXoaHet);
            this.flowButtons.Controls.Add(this.btnThanhToan);
            this.flowButtons.Location = new System.Drawing.Point(536, 10);
            this.flowButtons.Name = "flowButtons";
            this.flowButtons.Size = new System.Drawing.Size(344, 36);
            this.flowButtons.TabIndex = 2;
            // 
            // btnXoaDong
            // 
            this.btnXoaDong.Location = new System.Drawing.Point(3, 3);
            this.btnXoaDong.Name = "btnXoaDong";
            this.btnXoaDong.Size = new System.Drawing.Size(100, 30);
            this.btnXoaDong.TabIndex = 0;
            this.btnXoaDong.Text = "Xóa dòng";
            this.btnXoaDong.Click += new System.EventHandler(this.btnXoaDong_Click);
            // 
            // btnXoaHet
            // 
            this.btnXoaHet.Location = new System.Drawing.Point(109, 3);
            this.btnXoaHet.Name = "btnXoaHet";
            this.btnXoaHet.Size = new System.Drawing.Size(90, 30);
            this.btnXoaHet.TabIndex = 1;
            this.btnXoaHet.Text = "Xóa hết";
            this.btnXoaHet.Click += new System.EventHandler(this.btnXoaHet_Click);
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThanhToan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Location = new System.Drawing.Point(205, 3);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(130, 30);
            this.btnThanhToan.TabIndex = 2;
            this.btnThanhToan.Text = "THANH TOÁN";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // FrmBanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.splitContainer);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmBanHang";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Bán hàng";
            this.Load += new System.EventHandler(this.FrmBanHang_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.grpThongTin.ResumeLayout(false);
            this.tableHeader.ResumeLayout(false);
            this.tableHeader.PerformLayout();
            this.grpChon.ResumeLayout(false);
            this.tableChon.ResumeLayout(false);
            this.tableChon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGioHang)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.flowButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.GroupBox grpThongTin, grpChon;
        private System.Windows.Forms.TableLayoutPanel tableHeader, tableChon;
        private System.Windows.Forms.Label lblMaHD, lblNgayHD, lblKH, lblNVLabel, lblNhanVien, lblDoUong, lblDonGia, lblSL, lblTongTien, lblTongTienValue;
        private System.Windows.Forms.TextBox txtMaHD, txtDonGia;
        private System.Windows.Forms.DateTimePicker dtpNgay;
        private System.Windows.Forms.ComboBox cboKhachHang, cboDoUong;
        private System.Windows.Forms.NumericUpDown nudSoLuong;
        private System.Windows.Forms.Button btnThemVaoGio, btnXoaDong, btnXoaHet, btnThanhToan;
        private System.Windows.Forms.DataGridView dgvGioHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMa, colTen, colDonGia, colSL, colThanhTien;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.FlowLayoutPanel flowButtons;
    }
}
