namespace Model.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblThanhToan")]
    public partial class tblThanhToan
    {
        [Key]
        public long MaThanhToan { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        [StringLength(250)]
        public string KieuThanhToan { get; set; }

        [StringLength(250)]
        public string TenNganHang { get; set; }

        public decimal? SoTien { get; set; }
    }
}
