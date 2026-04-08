using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model_64132763.EF;
using PagedList;
using PagedList.Mvc;

namespace model_64132763.DAO
{
    public class UserDAO
    {
        Model_64132763DbContext db = null;
        public UserDAO() 
        { 
            db = new Model_64132763DbContext();
        }
        public IEnumerable<USER_ROLE> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<USER_ROLE> model = db.USER_ROLE;
            if(!string.IsNullOrEmpty(searchString) )
            {
                model = model.Where(x => x.NAME_USER.Contains(searchString) || x.FIRST_NAME.Contains(searchString) || x.LAST_NAME.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CREATED_DATE).ToPagedList(page, pageSize);
        }
        public int Insert(USER_ROLE entity)
        {

            db.USER_ROLE.Add(entity);
            db.SaveChanges();
            return entity.ID_USER;
        }
        public bool Updated(USER_ROLE entity) 
        {
            try
            {
                var user = db.USER_ROLE.Find(entity.ID_USER);
                user.LAST_NAME = entity.LAST_NAME;
                user.FIRST_NAME = entity.FIRST_NAME;
                if(!string.IsNullOrEmpty(entity.PASSWORD_USER))
                {
                    user.PASSWORD_USER = entity.PASSWORD_USER;
                }
                user.ADDRESS_CUSTOMER = entity.ADDRESS_CUSTOMER;
                user.EMAIL = entity.EMAIL;
                user.MODIFIED_BY = entity.MODIFIED_BY;
                user.MODIFIED_DATE = DateTime.Now;

                db.SaveChanges();
                return true;
            }
            catch(Exception ex) 
            {
                return false;
            }
            
        }
        public USER_ROLE GetByID(string userName) 
        {
            return db.USER_ROLE.SingleOrDefault(x => x.NAME_USER == userName);
        }
        public USER_ROLE ViewDetail(int id)
        {
            return db.USER_ROLE.Find(id);
        }
        public int Login(string username, string password)
        {
            var result = db.USER_ROLE.SingleOrDefault(x => x.NAME_USER == username);

            if (result == null) 
                return 0;
            else
            {
                if (result.STATUS_SLIDE == false)
                    return -1;
                else
                {
                    if (result.PASSWORD_USER == password)
                        return 1;
                    else
                        return -2;
                }

            }
        }
        public bool ChangeStatus(int id)
        {
            var user = db.USER_ROLE.Find(id);
            user.STATUS_SLIDE = !user.STATUS_SLIDE;
             db.SaveChanges();
            return user.STATUS_SLIDE;
        } 
        public bool Delete(int id)
        {
            try
            {
                var user = db.USER_ROLE.Find(id);
                db.USER_ROLE.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool CheckUserName(string userName)
        {
            return db.USER_ROLE.Count(x => x.NAME_USER == userName) > 0;
        }
        public bool CheckEmail(string email)
        {
            return db.USER_ROLE.Count(x => x.EMAIL == email) > 0;
        }
    }
}
