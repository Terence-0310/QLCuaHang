namespace QuanLyCuaHangRuou
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DoUong")]
    public partial class DoUong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DoUong()
        {
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
            KyGuiRuous = new HashSet<KyGuiRuou>();
        }

        [Key]
        [StringLength(20)]
        public string MaDoUong { get; set; }

        [Required]
        [StringLength(200)]
        public string TenDoUong { get; set; }

        [Required]
        [StringLength(20)]
        public string MaLoai { get; set; }

        public decimal DonGia { get; set; }

        public int SoLuongTon { get; set; }

        [StringLength(20)]
        public string DonViTinh { get; set; }

        /// <summary>
        /// Dung tích r??u (ml)
        /// </summary>
        public decimal? DungTich { get; set; }

        /// <summary>
        /// H?n s? d?ng c?a r??u
        /// </summary>
        [Column(TypeName = "date")]
        public DateTime? HanSuDung { get; set; }

        [StringLength(500)]
        public string GhiChu { get; set; }

        [StringLength(50)]
        public string TrangThai { get; set; }

        [StringLength(500)]
        public string HinhPath { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        public virtual LoaiDoUong LoaiDoUong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KyGuiRuou> KyGuiRuous { get; set; }
    }
}
