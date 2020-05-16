namespace Model.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblPhanHoi")]
    public partial class tblPhanHoi
    {
        [Key]
        public long MaNguoiDung { get; set; }

        [StringLength(250)]
        public string TenNguoiDung { get; set; }

        [StringLength(250)]
        public string email { get; set; }

        [StringLength(250)]
        public string DiaChi { get; set; }

        public DateTime? NgayTao { get; set; }

        [Column(TypeName = "ntext")]
        public string NoiDung { get; set; }

        public bool TrangThai { get; set; }
    }
}
