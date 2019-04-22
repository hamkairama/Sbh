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
using Sbh.Fr.CommonFunction;

namespace Sbh.Fr.Facade.Repository
{
    public class SosmedRepo : ISosmed
    {
        private EnumStatus fn = new EnumStatus();
        private DbConn _ctx = new DbConn();

        public SosmedRepo()
        {
            _ctx = new DbConn();
        }

        public ResultStatus Add(SBH_TM_SOSMED par)
        {
            ResultStatus rs = new ResultStatus();
            try
            {
                SBH_TM_SOSMED a = new SBH_TM_SOSMED()
                {
                    ID = par.ID,
                    TYPE = par.TYPE,
                    NAME = par.NAME,
                    DESCRIPTION = par.DESCRIPTION,
                    ICON = par.ICON,
                    URL = par.URL,
                    DATA_EMBED = par.DATA_EMBED,
                    HEIGHT = par.HEIGHT,
                    WIDTH = par.WIDTH,
                    DATA_WIDGET_ID = par.DATA_WIDGET_ID,
                    PHOTO_PATH = par.PHOTO_PATH,
                    BANNER_SELECTED = par.BANNER_SELECTED,

                    CREATED_TIME = DateTime.Now,
                    CREATED_BY = "System",
                    ROW_STATUS = fn.fg.IsActive
                };
                _ctx.SBH_TM_SOSMED.Add(a);
                _ctx.SaveChanges();

                rs.SetSuccessStatus("Data has been created successfully");
            }
            catch (Exception ex)
            {
                rs.SetErrorStatus(ex.Message);
            }
            return rs;
        }

        public ResultStatus Delete(int id)
        {
            ResultStatus rs = new ResultStatus();
            try
            {
                SBH_TM_SOSMED a = _ctx.SBH_TM_SOSMED.Find(id);
                a.ROW_STATUS = fn.fg.NotActive;
                _ctx.Entry(a).State = System.Data.Entity.EntityState.Modified;
                rs.SetSuccessStatus("Data has been deleted successfully");
            }
            catch (Exception ex)
            {
                rs.SetErrorStatus(ex.Message);
            }
            return rs;
        }

        public ResultStatus Edit(int id, SBH_TM_SOSMED par)
        {
            ResultStatus rs = new ResultStatus();
            try
            {
                SBH_TM_SOSMED a = _ctx.SBH_TM_SOSMED.Find(id);
                if (a != null)
                {
                    a.ID = par.ID;
                    a.TYPE = par.TYPE;
                    a.NAME = par.NAME;
                    a.DESCRIPTION = par.DESCRIPTION;
                    a.ICON = par.ICON;
                    a.URL = par.URL;
                    a.DATA_EMBED = par.DATA_EMBED;
                    a.HEIGHT = par.HEIGHT;
                    a.WIDTH = par.WIDTH;
                    a.DATA_WIDGET_ID = par.DATA_WIDGET_ID;
                    a.PHOTO_PATH = par.PHOTO_PATH;
                    a.BANNER_SELECTED = par.BANNER_SELECTED;

                    a.LAST_MODIFIED_TIME = DateTime.Now;
                    a.LAST_MODIFIED_BY = "System";

                    _ctx.Entry(a).State = System.Data.Entity.EntityState.Modified;
                    _ctx.SaveChanges();

                    rs.SetSuccessStatus("Data has been created successfully");
                }
            }
            catch (Exception ex)
            {
                rs.SetErrorStatus(ex.Message);
            }
            return rs;
        }

        public List<SBH_TM_SOSMED> GridBind()
        {
            try
            {
                List<SBH_TM_SOSMED> lA = new List<SBH_TM_SOSMED>();
                foreach (var item in _ctx.SBH_TM_SOSMED
                    .Where(x => x.ROW_STATUS == fn.fg.IsActive))
                {
                    SBH_TM_SOSMED oA = new SBH_TM_SOSMED();
                    oA.ID = item.ID;
                    oA.TYPE = item.TYPE;
                    oA.NAME = item.NAME;
                    oA.DESCRIPTION = item.DESCRIPTION;
                    oA.ICON = item.ICON;
                    oA.URL = item.URL;
                    oA.DATA_EMBED = item.DATA_EMBED;
                    oA.HEIGHT = item.HEIGHT;
                    oA.WIDTH = item.WIDTH;
                    oA.DATA_WIDGET_ID = item.DATA_WIDGET_ID;
                    oA.PHOTO_PATH = item.PHOTO_PATH;
                    oA.BANNER_SELECTED = item.BANNER_SELECTED;

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

        public SBH_TM_SOSMED Retrived(int id)
        {
            try
            {
                SBH_TM_SOSMED oA = new SBH_TM_SOSMED();
                SBH_TM_SOSMED oB = _ctx.SBH_TM_SOSMED
                    .Where(x => x.ROW_STATUS == fn.fg.IsActive && x.ID == id).FirstOrDefault();
                if (oB != null)
                {
                    oA.ID = oB.ID;
                    oA.TYPE = oB.TYPE;
                    oA.NAME = oB.NAME;
                    oA.DESCRIPTION = oB.DESCRIPTION;
                    oA.ICON = oB.ICON;
                    oA.URL = oB.URL;
                    oA.DATA_EMBED = oB.DATA_EMBED;
                    oA.HEIGHT = oB.HEIGHT;
                    oA.WIDTH = oB.WIDTH;
                    oA.DATA_WIDGET_ID = oB.DATA_WIDGET_ID;
                    oA.PHOTO_PATH = oB.PHOTO_PATH;
                    oA.BANNER_SELECTED = oB.BANNER_SELECTED;

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

        public List<SBH_TM_SOSMED> RetrivedBannerSelected()
        {
            try
            {
                List<SBH_TM_SOSMED> lA = new List<SBH_TM_SOSMED>();
                foreach (var item in _ctx.SBH_TM_SOSMED
                    .Where(x => x.ROW_STATUS == fn.fg.IsActive && x.BANNER_SELECTED == 1))
                {
                    SBH_TM_SOSMED oA = new SBH_TM_SOSMED();
                    oA.ID = item.ID;
                    oA.TYPE = item.TYPE;
                    oA.NAME = item.NAME;
                    oA.DESCRIPTION = item.DESCRIPTION;
                    oA.ICON = item.ICON;
                    oA.URL = item.URL;
                    oA.DATA_EMBED = item.DATA_EMBED;
                    oA.HEIGHT = item.HEIGHT;
                    oA.WIDTH = item.WIDTH;
                    oA.DATA_WIDGET_ID = item.DATA_WIDGET_ID;
                    oA.PHOTO_PATH = item.PHOTO_PATH;
                    oA.BANNER_SELECTED = item.BANNER_SELECTED;

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
        
    }
}
