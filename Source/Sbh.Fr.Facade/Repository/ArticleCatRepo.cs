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
    public class ArticleCatRepo : IArticleCat
    {
        private EnumStatus fn = new EnumStatus();
        private DbConn _ctx = new DbConn();

        public ArticleCatRepo()
        {
            _ctx = new DbConn();
        }

        public bool Add(ArticleCat art)
        {
            bool res = false;
            try
            {
                SBH_TM_ARTICLE_CAT a = new SBH_TM_ARTICLE_CAT()
                {
                    ID = art.ID,
                    ARTICLE_CAT_DESC = art.ARTICLE_CAT_DESC,

                    CREATED_TIME = DateTime.Now,
                    CREATED_BY = "System",
                    ROW_STATUS = fn.fg.IsActive
                };
                _ctx.SBH_TM_ARTICLE_CAT.Add(a);
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
                SBH_TM_ARTICLE_CAT a = _ctx.SBH_TM_ARTICLE_CAT.Find(id);
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

        public bool Edit(int id, ArticleCat art)
        {
            bool res = false;
            try
            {
                SBH_TM_ARTICLE_CAT a = _ctx.SBH_TM_ARTICLE_CAT.Find(id);
                if (a != null)
                {
                    a.ID = art.ID;
                    a.ARTICLE_CAT_DESC = art.ARTICLE_CAT_DESC;

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

        public List<ArticleCat> GridBind()
        {
            try
            {
                List<ArticleCat> lA = new List<ArticleCat>();
                foreach (var item in _ctx.SBH_TM_ARTICLE_CAT
                    .Where(x => x.ROW_STATUS == fn.fg.IsActive))
                {
                    ArticleCat oA = new ArticleCat();
                    oA.ID = item.ID;
                    oA.ARTICLE_CAT_DESC = item.ARTICLE_CAT_DESC;

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

        public ArticleCat Retrived(int id)
        {
            try
            {
                ArticleCat oA = new ArticleCat();
                SBH_TM_ARTICLE_CAT oB = _ctx.SBH_TM_ARTICLE_CAT
                    .Where(x => x.ROW_STATUS == fn.fg.IsActive && x.ID == id).FirstOrDefault();
                if (oB != null)
                {
                    oA.ID = oB.ID;
                    oA.ARTICLE_CAT_DESC = oB.ARTICLE_CAT_DESC;

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
