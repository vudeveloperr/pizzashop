namespace Model.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblLienHe")]
    public partial class tblLienHe
    {
        [Key]
        public long MaLienHe { get; set; }

        [Column(TypeName = "ntext")]
        public string NoiDung { get; set; }

        public bool TrangThai { get; set; }
    }
}
