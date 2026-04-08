using model_64132763.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_64132763.DAO
{
    public class CategoryDAO
    {
        private Model_64132763DbContext db = null;
        public CategoryDAO()
        {
            db = new Model_64132763DbContext();
        }
        public List<CATEGORY> ListAll()
        {
            return db.CATEGORies.Where(x => x.STATUS_CATEGORY == true).OrderBy(x=>x.DISPLAY_ORDER).ToList();
        }
        public PRODUCT_CATEGORY ViewDetail(int id)
        {
            return db.PRODUCT_CATEGORies.Find(id);
        }
    }
}
