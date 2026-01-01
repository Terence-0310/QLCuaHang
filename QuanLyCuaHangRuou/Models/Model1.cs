using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QuanLyCuaHangRuou
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual DbSet<DoUong> DoUongs { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<KyGuiRuou> KyGuiRuous { get; set; }
        public virtual DbSet<LoaiDoUong> LoaiDoUongs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<VaiTro> VaiTroes { get; set; }
        public virtual DbSet<ViTriLuuTru> ViTriLuuTrus { get; set; }
        public virtual DbSet<vw_DoanhThu> vw_DoanhThu { get; set; }
        public virtual DbSet<vw_TonKho> vw_TonKho { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietHoaDon>()
                .Property(e => e.ThanhTien)
                .HasPrecision(37, 4);

            modelBuilder.Entity<DoUong>()
                .HasMany(e => e.ChiTietHoaDons)
                .WithRequired(e => e.DoUong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.ChiTietHoaDons)
                .WithRequired(e => e.HoaDon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.KyGuiRuous)
                .WithRequired(e => e.KhachHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiDoUong>()
                .HasMany(e => e.DoUongs)
                .WithRequired(e => e.LoaiDoUong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VaiTro>()
                .HasMany(e => e.TaiKhoans)
                .WithRequired(e => e.VaiTro)
                .WillCascadeOnDelete(false);
        }
    }
}
