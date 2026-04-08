using model_64132763.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using Common;
namespace model_64132763.DAO
{
    public class AdvertisementDAO
    {
        Model_64132763DbContext db = null;
        public AdvertisementDAO()
        {
            db = new Model_64132763DbContext();
        }
        public IEnumerable<ADVERTISEMENT> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<ADVERTISEMENT> model = db.ADVERTISEMENTs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.NAME_ADVERTISEMENT.Contains(searchString) || x.NAME_ADVERTISEMENT.Contains(searchString));
            }

            return model.OrderByDescending(x => x.CREATED_DATE).ToPagedList(page, pageSize);

        }
        /// <summary>
        /// List all content for client
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<ADVERTISEMENT> ListAllPaging(int page, int pageSize)
        {
            IQueryable<ADVERTISEMENT> model = db.ADVERTISEMENTs;
            return model.OrderByDescending(x => x.CREATED_DATE).ToPagedList(page, pageSize);

        }
        public ADVERTISEMENT GetByID(int id)
        {
            return db.ADVERTISEMENTs.Find(id);
        }
    }
}
