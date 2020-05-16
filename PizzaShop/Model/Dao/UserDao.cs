using Model.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class UserDao
    {

        Model1 db = null;
        public UserDao()
        {
            db = new Model1();

            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
        public long Insert(tblNguoiDung entity)
        {
            db.tblNguoiDungs.Add(entity);
            db.SaveChanges();
            return entity.MaNguoiDung;
        }

        public bool Update(tblNguoiDung entity)
        {
            try
            {
                var user = db.tblNguoiDungs.Find(entity.MaNguoiDung);
                //user.TenDangNhap = entity.TenDangNhap;
                
                if (!string.IsNullOrEmpty(entity.MatKhau))
                {
                    user.MatKhau = entity.MatKhau;
                }

                user.GioiTinh = entity.GioiTinh;
                user.SDT = entity.SDT;
                user.Email = entity.Email;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }


        public IEnumerable<tblNguoiDung> ListAllPaging(string searchString, int page, int pagesize)
        {
            IQueryable<tblNguoiDung> model = db.tblNguoiDungs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TenDangNhap.Contains(searchString));
            }
            return model.OrderByDescending(x => x.NgayTao).ToPagedList(page, pagesize);
        }


        public tblNguoiDung GetById(string userName)
        {
            return db.tblNguoiDungs.SingleOrDefault(x => x.TenDangNhap == userName);
        }

        public int Login(string userName, string passWord)
        {
            var result = db.tblNguoiDungs.SingleOrDefault(x => x.TenDangNhap == userName);

            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.TrangThai == false)
                {
                    return -1;
                }
                else
                {
                    if (result.MatKhau == passWord)
                    {
                        return 1;
                    }
                    else
                    {
                        return -2;
                    }
                }
            }
        }


        public tblNguoiDung ViewDetail(int id)
        {
            return db.tblNguoiDungs.Find(id);
        } 


        public bool Delete(int id)
        {
            try
            {
                var user = db.tblNguoiDungs.Find(id);
                db.tblNguoiDungs.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }
    }
}
