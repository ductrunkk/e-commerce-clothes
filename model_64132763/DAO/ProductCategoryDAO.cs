using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model_64132763.EF;
namespace model_64132763.DAO
{
    public class ProductCategoryDAO
    {
        Model_64132763DbContext db = null;
        public ProductCategoryDAO()
        {
            db = new Model_64132763DbContext();
        }
        public List<PRODUCT_CATEGORY> ListAll()
        {
            return db.PRODUCT_CATEGORies.Where(x => x.STATUS_PRODUCT_CATEGORY == true).OrderBy(x=>x.DISPLAY_ORDER).ToList();
        }
        public PRODUCT_CATEGORY ViewDetail(int id)
        {
            return db.PRODUCT_CATEGORies.Find(id);
        }
    }
}
