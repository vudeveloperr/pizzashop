using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ContactDao
    {
        Model1 db = null;

        public ContactDao()
        {
            db = new Model1();
        }

        public long InsertFeedBack(tblPhanHoi phanhoi)
        {
            db.tblPhanHois.Add(phanhoi);
            db.SaveChanges();

            return phanhoi.MaNguoiDung;
        }
    }
}
