using model_64132763.EF;
using model_64132763.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_64132763.DAO
{
    public class CartDAO
    {
        Model_64132763DbContext db = null;
        public CartDAO()
        {
            db = new Model_64132763DbContext();
        }
        public int Insert(CART entity)
        {
            db.CARTs.Add(entity);
            db.SaveChanges();
            return entity.ID_CART;
        }
        public List<RevenueByMonth> GetRevenueByMonth()
        {
            var query = (from o in db.CARTs
                         join od in db.CART_DETAIL on o.ID_CART equals od.ID_CART
                         group new { o, od } by new { Year = o.CREATED_DATE.Year, Month = o.CREATED_DATE.Month } into g

                         select new RevenueByMonth
                         {
                             Year = g.Key.Year,
                             Month = g.Key.Month,
                             TotalRevenue = g.Sum(x => x.od.QUANTITY * x.od.PRICE.Value)
                         }).OrderBy(r => r.Year).ThenBy(r => r.Month).ToList();

            return query;
        }
    }
}
