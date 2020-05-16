namespace Model.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblDatMon")]
    public partial class tblDatMon
    {
        [Key]
        public long MaDonHang { get; set; }

        public long? MaMon { get; set; }
    }
}
