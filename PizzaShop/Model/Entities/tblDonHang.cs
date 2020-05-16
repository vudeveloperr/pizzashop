namespace Model.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblDonHang")]
    public partial class tblDonHang
    {
        [Key]
        public long MaDonHang { get; set; }

        public double? TongTien { get; set; }

        public int? SoLuong { get; set; }

        public DateTime? ThoiGianDat { get; set; }

        public DateTime? ThoiGianNhan { get; set; }

        [StringLength(250)]
        public string GhiChu { get; set; }

        [StringLength(250)]
        public string DiaChiNhan { get; set; }

        [StringLength(250)]
        public string TenNguoiNhan { get; set; }

        [StringLength(50)]
        public string SDTNguoiNhan { get; set; }
    }
}
