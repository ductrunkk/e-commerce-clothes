using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model_64132763.EF;
using model_64132763.ViewModel;

namespace model_64132763.DAO
{
    public class ProductDAO
    {
        Model_64132763DbContext db = null;
        public ProductDAO()
        {
            db = new Model_64132763DbContext();
        }
        public List<string> ListName(string keyword)
        {
            return db.PRODUCTs.Where(x => x.NAME_PRODUCT.Contains(keyword)).Select(x => x.NAME_PRODUCT).ToList();
        }
        public List<ProductViewModel> Search(string keyword, ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        {
            totalRecord = db.PRODUCTs.Where(x => x.NAME_PRODUCT == keyword).Count();
            var model = (from a in db.PRODUCTs
                         join b in db.PRODUCT_CATEGORies
                         on a.ID_CATEGORY equals b.ID_PRODUCT_CATEGORY
                         where a.NAME_PRODUCT.Contains(keyword)
                         select new
                         {
                             CateMetaTitle = b.META_TITLE_PRODUCT_CATEGORY,
                             CateName = b.NAME_PRODUCT_CATEGORY,
                             CreatedDate = a.CREATED_DATE,
                             ID = a.ID_PRODUCT,
                             Images = a.IMAGES,
                             Name = a.NAME_PRODUCT,
                             MetaTitle = a.META_TITLE_PRODUCT,
                             Price = a.PRICE,
                         }).AsEnumerable().Select(x => new ProductViewModel()
                         {
                             CateMetaTitle = x.MetaTitle,
                             CateName = x.Name,
                             CreatedDate = x.CreatedDate,
                             ID = x.ID,
                             Images = x.Images,
                             NameP = x.Name,
                             MetaTitle = x.MetaTitle,
                             Price = x.Price
                         });
            model.OrderByDescending(x => x.CreatedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return model.ToList();
        }
        /// <summary>
        /// Get list new product
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public List<PRODUCT> ListNewProduct(int top)
        {
            return db.PRODUCTs.OrderByDescending(x => x.CREATED_DATE).Take(top).ToList();
        }
        /// <summary>
        /// Get list hot product
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public List<PRODUCT> ListHotProduct(int top)
        {
            return db.PRODUCTs.Where(x => x.VIEW_COUNT > 10).OrderByDescending(x => x.CREATED_DATE).Take(top).ToList();
        }
        /// <summary>
        /// Get product detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PRODUCT ViewDetail(int id)
        {
            return db.PRODUCTs.Find(id);
        }
        /// <summary>
        /// Get list product by category ID
        /// </summary>
        /// <param name="cateID"></param>
        /// <returns></returns>
        public List<PRODUCT> ListByCategoryID(int cateID, ref int totalRecord, int pageIndex=1, int pageSize=2)
        {
            totalRecord = db.PRODUCTs.Where(x => x.ID_CATEGORY == cateID).Count();
            return db.PRODUCTs.Where(x => x.ID_CATEGORY == cateID).OrderByDescending(x=>x.CREATED_DATE).Skip((pageIndex-1)* pageSize).Take(pageSize).ToList();
        }

    }
}
