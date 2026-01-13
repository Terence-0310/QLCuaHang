namespace QuanLyCuaHangRuou.GUI
{
    partial class FrmKhachHang
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmKhachHang));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.tableInputs = new System.Windows.Forms.TableLayoutPanel();
            this.lblMa = new System.Windows.Forms.Label();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.lblTen = new System.Windows.Forms.Label();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.lblSDT = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.grpHinh = new System.Windows.Forms.GroupBox();
            this.picKhachHang = new System.Windows.Forms.PictureBox();
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
            this.dgvKhachHang = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.grpThongTin.SuspendLayout();
            this.tableInputs.SuspendLayout();
            this.grpHinh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picKhachHang)).BeginInit();
            this.panelImageButtons.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelSearch.SuspendLayout();
            this.panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).BeginInit();
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
            this.splitContainer.Panel2.Controls.Add(this.dgvKhachHang);
            this.splitContainer.Size = new System.Drawing.Size(964, 541);
            this.splitContainer.SplitterDistance = 180;
            this.splitContainer.TabIndex = 0;
            // 
            // grpThongTin
            // 
            this.grpThongTin.Controls.Add(this.tableInputs);
            this.grpThongTin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpThongTin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpThongTin.Location = new System.Drawing.Point(0, 0);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(764, 130);
            this.grpThongTin.TabIndex = 0;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Thông tin khách hàng";
            // 
            // tableInputs
            // 
            this.tableInputs.ColumnCount = 4;
            this.tableInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableInputs.Controls.Add(this.lblMa, 0, 0);
            this.tableInputs.Controls.Add(this.txtMaKH, 1, 0);
            this.tableInputs.Controls.Add(this.lblTen, 0, 1);
            this.tableInputs.Controls.Add(this.txtTenKH, 1, 1);
            this.tableInputs.Controls.Add(this.lblSDT, 2, 0);
            this.tableInputs.Controls.Add(this.txtSDT, 3, 0);
            this.tableInputs.Controls.Add(this.lblDiaChi, 2, 1);
            this.tableInputs.Controls.Add(this.txtDiaChi, 3, 1);
            this.tableInputs.Controls.Add(this.lblTrangThai, 0, 2);
            this.tableInputs.Controls.Add(this.cboTrangThai, 1, 2);
            this.tableInputs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableInputs.Location = new System.Drawing.Point(3, 23);
            this.tableInputs.Name = "tableInputs";
            this.tableInputs.RowCount = 3;
            this.tableInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableInputs.Size = new System.Drawing.Size(758, 104);
            this.tableInputs.TabIndex = 0;
            // 
            // lblMa
            // 
            this.lblMa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMa.Location = new System.Drawing.Point(3, 0);
            this.lblMa.Name = "lblMa";
            this.lblMa.Size = new System.Drawing.Size(74, 23);
            this.lblMa.TabIndex = 0;
            this.lblMa.Text = "Mã KH:";
            this.lblMa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMaKH
            // 
            this.txtMaKH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaKH.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMaKH.Location = new System.Drawing.Point(83, 3);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.Size = new System.Drawing.Size(293, 27);
            this.txtMaKH.TabIndex = 1;
            // 
            // lblTen
            // 
            this.lblTen.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTen.Location = new System.Drawing.Point(3, 35);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(74, 23);
            this.lblTen.TabIndex = 2;
            this.lblTen.Text = "Tên KH:";
            this.lblTen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTenKH
            // 
            this.txtTenKH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTenKH.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTenKH.Location = new System.Drawing.Point(83, 38);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(293, 27);
            this.txtTenKH.TabIndex = 3;
            // 
            // lblSDT
            // 
            this.lblSDT.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSDT.Location = new System.Drawing.Point(382, 0);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(74, 23);
            this.lblSDT.TabIndex = 4;
            this.lblSDT.Text = "SĐT:";
            this.lblSDT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSDT
            // 
            this.txtSDT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSDT.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSDT.Location = new System.Drawing.Point(462, 3);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(293, 27);
            this.txtSDT.TabIndex = 5;
            this.txtSDT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSDT_KeyPress);
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDiaChi.Location = new System.Drawing.Point(382, 35);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(74, 23);
            this.lblDiaChi.TabIndex = 6;
            this.lblDiaChi.Text = "Địa chỉ:";
            this.lblDiaChi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDiaChi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDiaChi.Location = new System.Drawing.Point(462, 38);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(293, 27);
            this.txtDiaChi.TabIndex = 7;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTrangThai.Location = new System.Drawing.Point(3, 70);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(74, 23);
            this.lblTrangThai.TabIndex = 8;
            this.lblTrangThai.Text = "Trạng thái:";
            this.lblTrangThai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboTrangThai.Location = new System.Drawing.Point(83, 73);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(293, 28);
            this.cboTrangThai.TabIndex = 9;
            // 
            // grpHinh
            // 
            this.grpHinh.Controls.Add(this.picKhachHang);
            this.grpHinh.Controls.Add(this.panelImageButtons);
            this.grpHinh.Dock = System.Windows.Forms.DockStyle.Right;
            this.grpHinh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpHinh.Location = new System.Drawing.Point(764, 0);
            this.grpHinh.Name = "grpHinh";
            this.grpHinh.Size = new System.Drawing.Size(200, 130);
            this.grpHinh.TabIndex = 1;
            this.grpHinh.TabStop = false;
            this.grpHinh.Text = "Hình ảnh";
            // 
            // picKhachHang
            // 
            this.picKhachHang.BackColor = System.Drawing.Color.WhiteSmoke;
            this.picKhachHang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picKhachHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picKhachHang.Location = new System.Drawing.Point(3, 23);
            this.picKhachHang.Name = "picKhachHang";
            this.picKhachHang.Size = new System.Drawing.Size(194, 74);
            this.picKhachHang.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picKhachHang.TabIndex = 0;
            this.picKhachHang.TabStop = false;
            // 
            // panelImageButtons
            // 
            this.panelImageButtons.Controls.Add(this.btnChonHinh);
            this.panelImageButtons.Controls.Add(this.btnXoaHinh);
            this.panelImageButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelImageButtons.Location = new System.Drawing.Point(3, 97);
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
            this.panelBottom.Location = new System.Drawing.Point(0, 130);
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
            this.lblTim.Size = new System.Drawing.Size(0, 20);
            this.lblTim.TabIndex = 0;
            // 
            // txtTim
            // 
            this.txtTim.Location = new System.Drawing.Point(85, 14);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(200, 27);
            this.txtTim.TabIndex = 1;
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(291, 12);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(75, 27);
            this.btnTim.TabIndex = 2;
            this.btnTim.Text = "Tìm";
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(372, 12);
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
            // dgvKhachHang
            // 
            this.dgvKhachHang.AllowUserToAddRows = false;
            this.dgvKhachHang.AllowUserToDeleteRows = false;
            this.dgvKhachHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKhachHang.BackgroundColor = System.Drawing.Color.White;
            this.dgvKhachHang.ColumnHeadersHeight = 29;
            this.dgvKhachHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKhachHang.Location = new System.Drawing.Point(0, 0);
            this.dgvKhachHang.MultiSelect = false;
            this.dgvKhachHang.Name = "dgvKhachHang";
            this.dgvKhachHang.ReadOnly = true;
            this.dgvKhachHang.RowHeadersWidth = 51;
            this.dgvKhachHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKhachHang.Size = new System.Drawing.Size(964, 357);
            this.dgvKhachHang.TabIndex = 0;
            this.dgvKhachHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKhachHang_CellClick);
            // 
            // FrmKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.splitContainer);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmKhachHang";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Load += new System.EventHandler(this.FrmKhachHang_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.grpThongTin.ResumeLayout(false);
            this.tableInputs.ResumeLayout(false);
            this.tableInputs.PerformLayout();
            this.grpHinh.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picKhachHang)).EndInit();
            this.panelImageButtons.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.GroupBox grpThongTin, grpHinh;
        private System.Windows.Forms.TableLayoutPanel tableInputs;
        private System.Windows.Forms.Label lblMa, lblTen, lblSDT, lblDiaChi, lblTrangThai, lblTim;
        private System.Windows.Forms.TextBox txtMaKH, txtTenKH, txtSDT, txtDiaChi, txtTim;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.PictureBox picKhachHang;
        private System.Windows.Forms.Panel panelImageButtons, panelBottom, panelSearch, panelButtons;
        private System.Windows.Forms.Button btnChonHinh, btnXoaHinh, btnTim, btnLamMoi, btnThem, btnSua, btnXoa, btnLuu, btnHuy;
        private System.Windows.Forms.DataGridView dgvKhachHang;
    }
}
