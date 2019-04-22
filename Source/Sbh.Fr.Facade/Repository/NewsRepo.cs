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
using Sbh.Fr.Model;
using Sbh.Fr.CommonFunction;
using System.Data.Entity;
using System.Web.Mvc;

namespace Sbh.Fr.Facade.Repository
{
    public class NewsRepo : INews
    {
        private EnumStatus eStat = new EnumStatus();
        private ResultStatus rs = new ResultStatus();
        private DbConn _ctx;

        public NewsRepo()
        {
            _ctx = new DbConn();
        }

        public List<SBH_TM_NEWS> GridBind()
        {
            try
            {
                return _ctx.SBH_TM_NEWS.Where(x => x.ROW_STATUS == (int)EnumList.RowStatus.Active).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<SBH_TM_NEWS> GridBindTop5()
        {
            try
            {
                List<SBH_TM_NEWS> newsListTop5 = new List<SBH_TM_NEWS>();
                int totalRandom = 5;
                List<SBH_TM_NEWS> newsList = _ctx.SBH_TM_NEWS.Where(x => x.ROW_STATUS == (int)EnumList.RowStatus.Active).ToList();
                if (newsList.Count() < 5)
                {
                    totalRandom = newsList.Count();
                }
                for (int i = 0; i < totalRandom; i++)
                {
                    newsListTop5.Add(newsList[i]);
                }

                return newsListTop5;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public SBH_TM_NEWS Retrieve(int id)
        {
            try
            {
                return _ctx.SBH_TM_NEWS.Where(x => x.ID == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ResultStatus Add(SBH_TM_NEWS news)
        {
            try
            {
                _ctx.SBH_TM_NEWS.Add(news);
                _ctx.SaveChanges();
                rs.SetSuccessStatus();

            }
            catch (Exception ex)
            {
                rs.SetErrorStatus(ex.Message);
            }

            return rs;
        }

        public ResultStatus Edit(SBH_TM_NEWS news)
        {
            try
            {
                SBH_TM_NEWS newsNew = _ctx.SBH_TM_NEWS.Find(news.ID);
                newsNew.TITLE = news.TITLE;
                newsNew.DESCRIPTION = news.DESCRIPTION;
                newsNew.CATEGORY_ID = news.CATEGORY_ID;
                newsNew.FILE_IMAGE1 = news.FILE_IMAGE1;
                newsNew.FILE_IMAGE2 = news.FILE_IMAGE2;
                newsNew.FILE_IMAGE3 = news.FILE_IMAGE3;
                newsNew.FILE_IMAGE4 = news.FILE_IMAGE4;
                newsNew.TEMPLATE = news.TEMPLATE;
                newsNew.LAST_MODIFIED_TIME = news.LAST_MODIFIED_TIME;
                newsNew.LAST_MODIFIED_BY = news.LAST_MODIFIED_BY;
                _ctx.Entry(newsNew).State = System.Data.Entity.EntityState.Modified;
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
                SBH_TM_NEWS news = _ctx.SBH_TM_NEWS.Find(id);
                news.LAST_MODIFIED_TIME = modifiedTime;
                news.LAST_MODIFIED_BY = modifiedBy;
                news.ROW_STATUS = eStat.fg.NotActive;

                _ctx.Entry(news).State = EntityState.Modified;
                _ctx.SaveChanges();
                rs.SetSuccessStatus();
            }
            catch (Exception ex)
            {
                rs.SetErrorStatus(ex.Message);
            }

            return rs;
        }

        public List<SBH_TM_NEWS> GetnewsByCategoryId(int categoryId)
        {
            try
            {
                return _ctx.SBH_TM_NEWS.Where(x => x.ROW_STATUS == (int)EnumList.RowStatus.Active && x.CATEGORY_ID == categoryId).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public SelectList GetCategoryList()
        {
            List<SBH_TM_CATEGORY> categories = _ctx.SBH_TM_CATEGORY.Where(x => x.ROW_STATUS == (int)EnumList.RowStatus.Active).ToList();
            SBH_TM_CATEGORY category = new SBH_TM_CATEGORY { ID = 0, CATEGORY_NAME = "Select Category :" };

            categories.Add(category);
            var categoryList = categories.OrderBy(x => x.ID);

            SelectList selectList = new SelectList(categoryList, "ID", "CATEGORY_NAME");
            return selectList;
        }

    }
}
