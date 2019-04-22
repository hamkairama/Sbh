using Sbh.Fr.Facade.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sbh.Fr.Model.Custom;
using Sbh.Fr.Model.ClsGlobal;
using Sbh.Fr.Model.DbCtx;
using Sbh.Fr.Model.Transaksi;
namespace Sbh.Fr.Facade.Repository
{
    public class ArticleRepo : IArticle
    {
        private EnumStatus fn = new EnumStatus();
        private DbConn _ctx = new DbConn();

        public ArticleRepo()
        {
            _ctx = new DbConn();
        }

        public bool Add(Article art)
        {
            bool res = false;
            try
            {
                SBH_TR_ARTICLE a = new SBH_TR_ARTICLE()
                {
                    ID = art.ID,
                    ID_USER_ADMIN = art.ID_USER_ADMIN,
                    ID_ARTICLE_CAT = art.ID_ARTICLE_CAT,
                    ARTICLE = art.ARTICLE,

                    CREATED_TIME = DateTime.Now,
                    CREATED_BY = "System",
                    ROW_STATUS = fn.fg.IsActive
                };
                _ctx.SBH_TR_ARTICLE.Add(a);
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
                SBH_TR_ARTICLE a = _ctx.SBH_TR_ARTICLE.Find(id);
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

        public bool Edit(int id, Article art)
        {
            bool res = false;
            try
            {
                SBH_TR_ARTICLE a = _ctx.SBH_TR_ARTICLE.Find(id);
                if (a != null)
                {
                    a.ID = art.ID;
                    a.ID_USER_ADMIN = art.ID_USER_ADMIN;
                    a.ID_ARTICLE_CAT = art.ID_ARTICLE_CAT;
                    a.ARTICLE = art.ARTICLE;

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

        public List<Article> GridBind()
        {
            try
            {
                List<Article> lA = new List<Article>();
                foreach (var item in _ctx.SBH_TR_ARTICLE
                    .Where(x => x.ROW_STATUS == fn.fg.IsActive))
                {
                    Article oA = new Article();
                    oA.ID = item.ID;
                    oA.ID_USER_ADMIN = item.ID_USER_ADMIN;
                    oA.ID_ARTICLE_CAT = item.ID_ARTICLE_CAT;
                    oA.ARTICLE = item.ARTICLE;

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

        public Article Retrived(int id)
        {
            try
            {
                Article oA = new Article();
                SBH_TR_ARTICLE oB = _ctx.SBH_TR_ARTICLE
                    .Where(x => x.ROW_STATUS == fn.fg.IsActive && x.ID == id).FirstOrDefault();
                if (oB != null)
                {
                    oA.ID = oB.ID;
                    oA.ID_USER_ADMIN = oB.ID_USER_ADMIN;
                    oA.ID_ARTICLE_CAT = oB.ID_ARTICLE_CAT;
                    oA.ARTICLE = oB.ARTICLE;

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
