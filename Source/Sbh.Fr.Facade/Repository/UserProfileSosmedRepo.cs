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
    public class UserProfileSosmedRepo : IUserProfileSosmed
    {
        private EnumStatus fn = new EnumStatus();
        private DbConn _ctx = new DbConn();

        public UserProfileSosmedRepo()
        {
            _ctx = new DbConn();
        }

        public bool Add(UserProfileSosmed par)
        {
            bool res = false;
            try
            {
                SBH_TM_USER_PROFILE_SOSMED a = new SBH_TM_USER_PROFILE_SOSMED()
                {
                    ID = par.ID,
                    USER_PROFILE_ID = par.USER_PROFILE_ID,
                    SOSMED_NAME = par.SOSMED_NAME,
                    SOSMED_PATH = par.SOSMED_PATH,
                    CREATED_TIME = DateTime.Now,
                    CREATED_BY = "System",
                    ROW_STATUS = fn.fg.IsActive
                };
                _ctx.SBH_TM_USER_PROFILE_SOSMED.Add(a);
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
                SBH_TM_USER_PROFILE_SOSMED a = _ctx.SBH_TM_USER_PROFILE_SOSMED.Find(id);
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

        public bool Edit(int id, UserProfileSosmed par)
        {
            bool res = false;
            try
            {
                SBH_TM_USER_PROFILE_SOSMED a = _ctx.SBH_TM_USER_PROFILE_SOSMED.Find(id);
                if (a != null)
                {
                    a.ID = par.ID;
                    a.USER_PROFILE_ID = par.USER_PROFILE_ID;
                    a.SOSMED_NAME = par.SOSMED_NAME;
                    a.SOSMED_PATH = par.SOSMED_PATH;
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

        public List<UserProfileSosmed> GridBind()
        {
            try
            {
                List<UserProfileSosmed> lA = new List<UserProfileSosmed>();
                foreach (var item in _ctx.SBH_TM_USER_PROFILE_SOSMED
                    .Where(x => x.ROW_STATUS == fn.fg.IsActive))
                {
                    UserProfileSosmed oA = new UserProfileSosmed();
                    oA.ID = item.ID;
                    oA.USER_PROFILE_ID = item.USER_PROFILE_ID;
                    oA.SOSMED_NAME = item.SOSMED_NAME;
                    oA.SOSMED_PATH = item.SOSMED_PATH;

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

        public UserProfileSosmed Retrived(int id)
        {
            try
            {
                UserProfileSosmed oA = new UserProfileSosmed();
                SBH_TM_USER_PROFILE_SOSMED oB = _ctx.SBH_TM_USER_PROFILE_SOSMED
                    .Where(x => x.ROW_STATUS == fn.fg.IsActive && x.ID == id).FirstOrDefault();
                if (oB != null)
                {
                    oA.ID = oB.ID;
                    oA.USER_PROFILE_ID = oB.USER_PROFILE_ID;
                    oA.SOSMED_NAME = oB.SOSMED_NAME;
                    oA.SOSMED_PATH = oB.SOSMED_PATH;

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
