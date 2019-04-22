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
    public class MostActivityRepo : IMostActivity
    {
        private EnumStatus fn = new EnumStatus();
        private DbConn _ctx = new DbConn();

        public MostActivityRepo()
        {
            _ctx = new DbConn();
        }

        public bool Add(MostActivity par)
        {
            bool res = false;
            try
            {
                SBH_TM_MOSTACTIVITY a = new SBH_TM_MOSTACTIVITY()
                {
                    DESCR = par.DESCR,
                    START_COUNT = par.START_COUNT,
                    BEGIN_MOST_COUNT = par.BEGIN_MOST_COUNT,
                    END_MOST_COUNT = par.END_MOST_COUNT,
                    CREATED_TIME = DateTime.Now,
                    CREATED_BY = par.CREATED_BY,
                    ROW_STATUS = fn.fg.IsActive
                };
                _ctx.SBH_TM_MOSTACTIVITY.Add(a);
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
                SBH_TM_MOSTACTIVITY a = _ctx.SBH_TM_MOSTACTIVITY.Find(id);
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

        public bool Edit(int id, MostActivity par)
        {
            bool res = false;
            try
            {
                SBH_TM_MOSTACTIVITY a = _ctx.SBH_TM_MOSTACTIVITY.Find(id);
                if (a != null)
                {
                    a.DESCR = par.DESCR;
                    a.START_COUNT = par.START_COUNT;
                    a.BEGIN_MOST_COUNT = par.BEGIN_MOST_COUNT;
                    a.END_MOST_COUNT = par.END_MOST_COUNT;
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

        public List<MostActivity> GridBind()
        {
            try
            {
                List<MostActivity> lA = new List<MostActivity>();
                foreach (var item in _ctx.SBH_TM_MOSTACTIVITY.Where(x => x.ROW_STATUS == fn.fg.IsActive ))
                {
                    MostActivity oA = new MostActivity();
                    oA.ID = item.ID;
                    oA.DESCR = item.DESCR;
                    oA.START_COUNT = item.START_COUNT;
                    oA.BEGIN_MOST_COUNT = item.BEGIN_MOST_COUNT;
                    oA.END_MOST_COUNT = item.END_MOST_COUNT;

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

        public MostActivity Retrived(int id)
        {
            try
            {
                MostActivity oA = new MostActivity();
                SBH_TM_MOSTACTIVITY oB = _ctx.SBH_TM_MOSTACTIVITY
                    .Where(x => x.ROW_STATUS == fn.fg.IsActive && x.ID == id).FirstOrDefault();
                if (oB != null)
                {
                    oA.ID = oB.ID;
                    oA.DESCR = oB.DESCR;
                    oA.START_COUNT = oB.START_COUNT;
                    oA.BEGIN_MOST_COUNT = oB.BEGIN_MOST_COUNT;
                    oA.END_MOST_COUNT = oB.END_MOST_COUNT;

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