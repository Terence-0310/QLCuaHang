namespace QuanLyCuaHangRuou
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vw_DoanhThu
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(30)]
        public string MaHD { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime NgayHoaDon { get; set; }

        [StringLength(20)]
        public string MaKH { get; set; }

        [StringLength(100)]
        public string TenKH { get; set; }

        [StringLength(20)]
        public string MaNV { get; set; }

        [StringLength(100)]
        public string TenNV { get; set; }

        [Key]
        [Column(Order = 2)]
        public decimal TongTien { get; set; }

        [StringLength(255)]
        public string GhiChu { get; set; }
    }
}
