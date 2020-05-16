namespace Model.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblNguoiDung")]
    public partial class tblNguoiDung
    {
        [Key]
        [Display(Name = "Mã Người Dùng ")]
        public long MaNguoiDung { get; set; }

        [StringLength(250)]
        [Display(Name = "Tên Đăng Nhập ")]
        public string TenDangNhap { get; set; }

        [StringLength(32)]
        [Display(Name = "Mật Khẩu ")]
        public string MatKhau { get; set; }

        [StringLength(250)]
        [Display(Name = "Email ")]
        public string Email { get; set; }

        [StringLength(5)]
        [Display(Name = "Giới Tính ")]
        public string GioiTinh { get; set; }

        [StringLength(50)]
        [Display(Name = "Số Điện Thoại ")]
        public string SDT { get; set; }

        public DateTime? NgayTao { get; set; }
        [Display(Name = "Trạng Thái ")]
        public bool TrangThai { get; set; }
    }
}
