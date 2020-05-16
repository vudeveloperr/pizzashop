namespace Model.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=PizzaShopHVDbContext")
        {
        }

        public virtual DbSet<tblDonHang> tblDonHangs { get; set; }
        public virtual DbSet<tblLienHe> tblLienHes { get; set; }
        public virtual DbSet<tblMonAn> tblMonAns { get; set; }
        public virtual DbSet<tblNguoiDung> tblNguoiDungs { get; set; }
        public virtual DbSet<tblPhanHoi> tblPhanHois { get; set; }
        public virtual DbSet<tblThanhToan> tblThanhToans { get; set; }
        public virtual DbSet<tblThongTinQuan> tblThongTinQuans { get; set; }
        public virtual DbSet<tblDatMon> tblDatMons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblMonAn>()
                .Property(e => e.Gia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tblMonAn>()
                .Property(e => e.GiaKhuyenMai)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tblNguoiDung>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<tblNguoiDung>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<tblPhanHoi>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<tblThanhToan>()
                .Property(e => e.SoTien)
                .HasPrecision(18, 0);
        }
    }
}
