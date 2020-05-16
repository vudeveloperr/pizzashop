namespace Model.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblMonAn")]
    public partial class tblMonAn
    {
        [Key]
        public long MaMon { get; set; }

        [StringLength(250)]
        public string TenMon { get; set; }

        public decimal? Gia { get; set; }

        public decimal? GiaKhuyenMai { get; set; }

        [StringLength(500)]
        public string AnhMon { get; set; }

        public int? SoLuong { get; set; }

        [StringLength(250)]
        public string LoaiMon { get; set; }

        [StringLength(500)]
        public string MoTa { get; set; }

        [StringLength(250)]
        public string KichThuoc { get; set; }

        [StringLength(250)]
        public string dvt { get; set; }

        public decimal? GiaVua { get; set; }

        public decimal? GiaLon { get; set; }
    }
}
