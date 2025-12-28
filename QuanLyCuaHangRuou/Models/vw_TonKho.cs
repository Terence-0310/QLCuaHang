namespace QuanLyCuaHangRuou
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vw_TonKho
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string MaDoUong { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(200)]
        public string TenDoUong { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(100)]
        public string TenLoai { get; set; }

        [Key]
        [Column(Order = 3)]
        public decimal DonGia { get; set; }

        [Key]
        [Column(Order = 4)]
        public decimal SoLuongTon { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(20)]
        public string DonViTinh { get; set; }

        [StringLength(50)]
        public string TrangThai { get; set; }

        [StringLength(500)]
        public string HinhPath { get; set; }
    }
}
