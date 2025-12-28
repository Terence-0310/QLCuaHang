namespace QuanLyCuaHangRuou
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietHoaDon")]
    public partial class ChiTietHoaDon
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(30)]
        public string MaHD { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string MaDoUong { get; set; }

        public decimal DonGia { get; set; }

        public int SoLuong { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal? ThanhTien { get; set; }

        public virtual DoUong DoUong { get; set; }

        public virtual HoaDon HoaDon { get; set; }
    }
}
