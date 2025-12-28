namespace QuanLyCuaHangRuou
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KyGuiRuou")]
    public partial class KyGuiRuou
    {
        [Key]
        [StringLength(20)]
        public string MaKyGui { get; set; }

        [Required]
        [StringLength(20)]
        public string MaKH { get; set; }

        [StringLength(20)]
        public string MaDoUong { get; set; }

        [Required]
        [StringLength(200)]
        public string TenRuou { get; set; }

        public decimal DungTichConLai { get; set; }

        [Required]
        [StringLength(10)]
        public string DonViTinh { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayKyGui { get; set; }

        [Column(TypeName = "date")]
        public DateTime HanKyGui { get; set; }

        [StringLength(100)]
        public string ViTriLuuTru { get; set; }

        [StringLength(50)]
        public string TrangThai { get; set; }

        [StringLength(500)]
        public string HinhPath { get; set; }

        public virtual DoUong DoUong { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
