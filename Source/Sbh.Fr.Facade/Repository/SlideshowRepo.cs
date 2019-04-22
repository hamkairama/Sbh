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
using Sbh.Fr.Model;
using System.Data.Entity;

namespace Sbh.Fr.Facade.Repository
{
    public class SlideshowRepo : ISlideshow
    {
        private EnumStatus eStat = new EnumStatus();
        private ResultStatus rs = new ResultStatus();
        private DbConn _ctx;

        public SlideshowRepo()
        {
            _ctx = new DbConn();
        }

        public List<SBH_TM_SLIDESHOW> GridBind()
        {
            try
            {
                return _ctx.SBH_TM_SLIDESHOW.Where(x => x.ROW_STATUS == (int)EnumList.RowStatus.Active).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public SBH_TM_SLIDESHOW Retrieve(int id)
        {
            try
            {
                return _ctx.SBH_TM_SLIDESHOW.Where(x => x.ID == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ResultStatus Add(SBH_TM_SLIDESHOW slideshow)
        {
            try
            {
                _ctx.SBH_TM_SLIDESHOW.Add(slideshow);
                _ctx.SaveChanges();
                rs.SetSuccessStatus();

            }
            catch (Exception ex)
            {
                rs.SetErrorStatus(ex.Message);
            }

            return rs;
        }

        public ResultStatus Edit(SBH_TM_SLIDESHOW slideshow)
        {
            try
            {
                SBH_TM_SLIDESHOW slideshowNew = _ctx.SBH_TM_SLIDESHOW.Find(slideshow.ID);
                slideshowNew.TITTLE = slideshow.TITTLE;
                slideshowNew.CONTENT_DESCRIPTION = slideshow.CONTENT_DESCRIPTION;
                slideshowNew.CLASS = slideshow.CLASS;
                slideshowNew.PHOTO_PATH = slideshow.PHOTO_PATH;
                slideshowNew.URL = slideshow.URL;
                slideshowNew.LAST_MODIFIED_TIME = slideshow.LAST_MODIFIED_TIME;
                slideshowNew.LAST_MODIFIED_BY = slideshow.LAST_MODIFIED_BY;
                _ctx.Entry(slideshowNew).State = System.Data.Entity.EntityState.Modified;
                _ctx.SaveChanges();
                rs.SetSuccessStatus();
            }
            catch (Exception ex)
            {
                rs.SetErrorStatus(ex.Message);
            }

            return rs;
        }

        public ResultStatus Delete(int id, string modifiedBy, DateTime modifiedTime)
        {
            try
            {
                SBH_TM_SLIDESHOW slideshow = _ctx.SBH_TM_SLIDESHOW.Find(id);
                slideshow.LAST_MODIFIED_TIME = modifiedTime;
                slideshow.LAST_MODIFIED_BY = modifiedBy;
                slideshow.ROW_STATUS = eStat.fg.NotActive;

                _ctx.Entry(slideshow).State = EntityState.Modified;
                _ctx.SaveChanges();
                rs.SetSuccessStatus();
            }
            catch (Exception ex)
            {
                rs.SetErrorStatus(ex.Message);
            }

            return rs;
        }
    }
}
