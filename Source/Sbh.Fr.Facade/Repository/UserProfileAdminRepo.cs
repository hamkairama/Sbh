using Sbh.Fr.Facade.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sbh.Fr.Model.Custom;
using Sbh.Fr.Model.ClsGlobal;
using Sbh.Fr.Model.DbCtx;
using Sbh.Fr.Model.Master;

namespace Sbh.Fr.Facade.Repository
{
    public class UserProfileAdminRepo : IUserProfileAdmin
    {
        private EnumStatus fn = new EnumStatus();
        private DbConn _ctx = new DbConn();

        public UserProfileAdminRepo()
        {
            _ctx = new DbConn();
        }

        public bool Add(UserProfileAdmin par)
        {
            bool res = false;
            try
            {
                SBH_TM_USER_PROFILE_ADMIN a = new SBH_TM_USER_PROFILE_ADMIN()
                {
                    ID = par.ID,
                    ID_USER_ADMIN = par.ID_USER_ADMIN,
                    PHOTO_PATH = par.PHOTO_PATH,
                    GENDER = par.GENDER,
                    BORN = par.BORN,
                    ADDRESS = par.ADDRESS,
                    DESCRIPTION = par.DESCRIPTION,
                    JOB = par.JOB,
                    COMPANY = par.COMPANY,
                    HOBBY = par.HOBBY,

                    CREATED_TIME = DateTime.Now,
                    CREATED_BY = "System",
                    ROW_STATUS = fn.fg.IsActive
                };
                _ctx.SBH_TM_USER_PROFILE_ADMIN.Add(a);
                _ctx.SaveChanges();

                res = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return res;
        }

        public bool Delete(int id)
        {
            bool res = false;
            try
            {
                SBH_TM_USER_PROFILE_ADMIN a = _ctx.SBH_TM_USER_PROFILE_ADMIN.Find(id);
                a.ROW_STATUS = fn.fg.NotActive;
                _ctx.Entry(a).State = System.Data.Entity.EntityState.Modified;
                res = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return res;
        }

        public bool Edit(int id, UserProfileAdmin par)
        {
            bool res = false;
            try
            {
                SBH_TM_USER_PROFILE_ADMIN a = _ctx.SBH_TM_USER_PROFILE_ADMIN.Find(id);
                if (a != null)
                {
                    a.ID = par.ID;
                    a.ID_USER_ADMIN = par.ID_USER_ADMIN;
                    a.PHOTO_PATH = par.PHOTO_PATH;
                    a.GENDER = par.GENDER;
                    a.BORN = par.BORN;
                    a.ADDRESS = par.ADDRESS;
                    a.DESCRIPTION = par.DESCRIPTION;
                    a.JOB = par.JOB;
                    a.COMPANY = par.COMPANY;
                    a.HOBBY = par.HOBBY;

                    a.LAST_MODIFIED_TIME = DateTime.Now;
                    a.LAST_MODIFIED_BY = "System";

                    _ctx.Entry(a).State = System.Data.Entity.EntityState.Modified;
                    _ctx.SaveChanges();

                    res = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return res;
        }

        public List<UserProfileAdmin> GridBind()
        {
            try
            {
                List<UserProfileAdmin> lA = new List<UserProfileAdmin>();
                foreach (var item in _ctx.SBH_TM_USER_PROFILE_ADMIN
                    .Where(x => x.ROW_STATUS == fn.fg.IsActive))
                {
                    UserProfileAdmin oA = new UserProfileAdmin();
                    oA.ID = item.ID;
                    oA.ID_USER_ADMIN = item.ID_USER_ADMIN;
                    oA.PHOTO_PATH = item.PHOTO_PATH;
                    oA.GENDER = item.GENDER;
                    oA.BORN = item.BORN;
                    oA.ADDRESS = item.ADDRESS;
                    oA.DESCRIPTION = item.DESCRIPTION;
                    oA.JOB = item.JOB;
                    oA.COMPANY = item.COMPANY;
                    oA.HOBBY = item.HOBBY;

                    oA.CREATED_TIME = item.CREATED_TIME;
                    oA.CREATED_BY = item.CREATED_BY;
                    oA.LAST_MODIFIED_TIME = item.LAST_MODIFIED_TIME;
                    oA.LAST_MODIFIED_BY = item.LAST_MODIFIED_BY;
                    oA.ROW_STATUS = item.ROW_STATUS;

                    lA.Add(oA);
                }
                return lA;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public UserProfileAdmin Retrived(int id)
        {
            try
            {
                UserProfileAdmin oA = new UserProfileAdmin();
                SBH_TM_USER_PROFILE_ADMIN oB = _ctx.SBH_TM_USER_PROFILE_ADMIN
                    .Where(x => x.ROW_STATUS == fn.fg.IsActive && x.ID == id).FirstOrDefault();
                if (oB != null)
                {
                    oA.ID = oB.ID;
                    oA.ID_USER_ADMIN = oB.ID_USER_ADMIN;
                    oA.PHOTO_PATH = oB.PHOTO_PATH;
                    oA.GENDER = oB.GENDER;
                    oA.BORN = oB.BORN;
                    oA.ADDRESS = oB.ADDRESS;
                    oA.DESCRIPTION = oB.DESCRIPTION;
                    oA.JOB = oB.JOB;
                    oA.COMPANY = oB.COMPANY;
                    oA.HOBBY = oB.HOBBY;

                    oA.CREATED_TIME = oB.CREATED_TIME;
                    oA.CREATED_BY = oB.CREATED_BY;
                    oA.LAST_MODIFIED_TIME = oB.LAST_MODIFIED_TIME;
                    oA.LAST_MODIFIED_BY = oB.LAST_MODIFIED_BY;
                    oA.ROW_STATUS = oB.ROW_STATUS;

                    return oA;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
                throw new Exception(ex.Message);
            }
        }
    }
}
