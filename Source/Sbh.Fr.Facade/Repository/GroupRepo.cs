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
    public class GroupRepo : IGroup
    {
        private EnumStatus fn = new EnumStatus();
        private DbConn _ctx = new DbConn();

        public GroupRepo()
        {
            _ctx = new DbConn();
        }

        public bool Add(Group par)
        {
            bool res = false;
            try
            {
                SBH_TM_GROUP a = new SBH_TM_GROUP()
                {
                    ID = par.ID,
                    GROUP_DESC = par.GROUP_DESC,

                    CREATED_TIME = DateTime.Now,
                    CREATED_BY = "System",
                    ROW_STATUS = fn.fg.IsActive
                };
                _ctx.SBH_TM_GROUP.Add(a);
                _ctx.SaveChanges();

                res = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return res;
        }

        public bool Delete(int id, string userName)
        {
            bool res = false;
            try
            {
                SBH_TM_GROUP a = _ctx.SBH_TM_GROUP.Find(id);
                if (a != null)
                {
                    a.LAST_MODIFIED_TIME = DateTime.Now;
                    a.LAST_MODIFIED_BY = userName;
                    a.ROW_STATUS = fn.fg.NotActive;

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

        public bool Edit(int id, Group par)
        {
            bool res = false;
            try
            {
                SBH_TM_GROUP a = _ctx.SBH_TM_GROUP.Find(id);
                if (a != null)
                {
                    a.GROUP_DESC = par.GROUP_DESC;
                    a.LAST_MODIFIED_TIME = DateTime.Now;
                    a.LAST_MODIFIED_BY = par.LAST_MODIFIED_BY;

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

        public List<Group> GridBind()
        {
            try
            {
                List<Group> lA = new List<Group>();
                foreach (var item in _ctx.SBH_TM_GROUP.Where(x => x.ROW_STATUS == fn.fg.IsActive && x.ID != 4 && x.ID != 5))
                {
                    Group oA = new Group();
                    oA.ID = item.ID;
                    oA.GROUP_DESC = item.GROUP_DESC;

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

        public Group Retrived(int id)
        {
            try
            {
                Group oA = new Group();
                SBH_TM_GROUP oB = _ctx.SBH_TM_GROUP
                    .Where(x => x.ROW_STATUS == fn.fg.IsActive && x.ID == id).FirstOrDefault();
                if (oB != null)
                {
                    oA.ID = oB.ID;
                    oA.GROUP_DESC = oB.GROUP_DESC;

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
