using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class MonAnDao
    {
        Model1 db = null;
        public MonAnDao()
        {
            db = new Model1();
        }

        public tblMonAn ViewDetail(int maMon)
        {
            return db.tblMonAns.Find(maMon);
        }
    }
}
