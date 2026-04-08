using model_64132763.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_64132763.DAO
{
    public class CartDetailDAO
    {
        Model_64132763DbContext db = null;
        public CartDetailDAO()
        {
            db = new Model_64132763DbContext();
        }
        public bool Insert(CART_DETAIL detail)
        {
            try
            {
                db.CART_DETAIL.Add(detail);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;

            }
        }
    }
}
