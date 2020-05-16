namespace Model.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblThongTinQuan")]
    public partial class tblThongTinQuan
    {
        [Key]
        public long Ma { get; set; }

        [StringLength(250)]
        public string Ten { get; set; }

        [Column(TypeName = "ntext")]
        public string MoTa { get; set; }

        public bool TrangThai { get; set; }
    }
}
