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
    public class CategoryRepo : ICategory
    {
        private EnumStatus eStat = new EnumStatus();
        private ResultStatus rs = new ResultStatus();
        private DbConn _ctx;

        public CategoryRepo()
        {
            _ctx = new DbConn();
        }

        public List<SBH_TM_CATEGORY> GridBind()
        {
            try
            {
                return _ctx.SBH_TM_CATEGORY.Where(x => x.ROW_STATUS == (int)EnumList.RowStatus.Active).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public SBH_TM_CATEGORY Retrieve(int id)
        {
            try
            {
                return _ctx.SBH_TM_CATEGORY.Where(x => x.ID == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ResultStatus Add(SBH_TM_CATEGORY category)
        {
            try
            {
                _ctx.SBH_TM_CATEGORY.Add(category);
                _ctx.SaveChanges();
                rs.SetSuccessStatus();

            }
            catch (Exception ex)
            {
                rs.SetErrorStatus(ex.Message);
            }

            return rs;
        }

        public ResultStatus Edit(SBH_TM_CATEGORY category)
        {
            try
            {
                SBH_TM_CATEGORY categoryNew = _ctx.SBH_TM_CATEGORY.Find(category.ID);
                categoryNew.CATEGORY_NAME = category.CATEGORY_NAME;
                categoryNew.DESCRIPTION = category.DESCRIPTION;
                categoryNew.URL = category.URL;
                categoryNew.CLASS = category.CLASS;
                categoryNew.IMAGE_PATH = category.IMAGE_PATH;
                categoryNew.LAST_MODIFIED_TIME = category.LAST_MODIFIED_TIME;
                categoryNew.LAST_MODIFIED_BY = category.LAST_MODIFIED_BY;
                _ctx.Entry(categoryNew).State = System.Data.Entity.EntityState.Modified;
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
                SBH_TM_CATEGORY category = _ctx.SBH_TM_CATEGORY.Find(id);
                category.LAST_MODIFIED_TIME = modifiedTime;
                category.LAST_MODIFIED_BY = modifiedBy;
                category.ROW_STATUS = eStat.fg.NotActive;

                _ctx.Entry(category).State = EntityState.Modified;
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
