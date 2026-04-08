using model_64132763.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_64132763.DAO
{
    public class MenuDAO
    {
        Model_64132763DbContext db = null;
        public MenuDAO()
        {
            db = new Model_64132763DbContext();
        }
        public List<MENU> ListByGroupID(string groupID)
        {
            return db.MENUs.Where(x => x.ID_TYPE == groupID).OrderBy(x=>x.DISPLAY_ORDER).ToList();
        }
    }
}
