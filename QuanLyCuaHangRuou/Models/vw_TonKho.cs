namespace QuanLyCuaHangRuou
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vw_TonKho")]
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
        public decimal DonGia { get; set; }

        [Key]
        [Column(Order = 3)]
        public int SoLuongTon { get; set; }
    }
}
