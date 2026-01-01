namespace QuanLyCuaHangRuou
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ViTriLuuTru")]
    public partial class ViTriLuuTru
    {
        [Key]
        [StringLength(20)]
        public string MaViTri { get; set; }

        [Required]
        [StringLength(100)]
        public string TenViTri { get; set; }

        [StringLength(500)]
        public string MoTa { get; set; }

        [StringLength(50)]
        public string TrangThai { get; set; }
    }
}
