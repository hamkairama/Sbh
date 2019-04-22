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
    public class GaleryPhotoRepo : IGaleryPhoto
    {
        private EnumStatus eStat = new EnumStatus();
        private ResultStatus rs = new ResultStatus();
        private DbConn _ctx;

        public GaleryPhotoRepo()
        {
            _ctx = new DbConn();
        }

        public List<SBH_TM_GALERY_FOTO> GridBind()
        {
            try
            {
                return _ctx.SBH_TM_GALERY_FOTO.Where(x => x.ROW_STATUS == (int)EnumList.RowStatus.Active).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<SBH_TM_GALERY_FOTO> GridBindTop5()
        {
            try
            {
                List<SBH_TM_GALERY_FOTO> galeryListTop5 = new List<SBH_TM_GALERY_FOTO>();
                int totalRandom = 5;
                List<SBH_TM_GALERY_FOTO> galeryList = _ctx.SBH_TM_GALERY_FOTO.Where(x => x.ROW_STATUS == (int)EnumList.RowStatus.Active).ToList();
                if (galeryList.Count() < 5)
                {
                    totalRandom = galeryList.Count();
                }
                for (int i = 0; i < totalRandom; i++)
                {
                    galeryListTop5.Add(galeryList[i]);
                }

                return galeryListTop5;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public SBH_TM_GALERY_FOTO Retrieve(int id)
        {
            try
            {
                return _ctx.SBH_TM_GALERY_FOTO.Where(x => x.ID == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ResultStatus Add(SBH_TM_GALERY_FOTO galery)
        {
            try
            {
                _ctx.SBH_TM_GALERY_FOTO.Add(galery);
                _ctx.SaveChanges();
                rs.SetSuccessStatus();

            }
            catch (Exception ex)
            {
                rs.SetErrorStatus(ex.Message);
            }

            return rs;
        }

        public ResultStatus AddAll(SBH_TM_GALERY_FOTO galery, List<string> listString)
        {

            using (var dbContextTransaction = _ctx.Database.BeginTransaction())
            {
                try
                {
                    foreach (var item in listString)
                    {
                        SBH_TM_GALERY_FOTO galeryNew = galery;
                        galeryNew.PHOTO_PATH = item;
                        _ctx.SBH_TM_GALERY_FOTO.Add(galery);
                        _ctx.SaveChanges();
                    }

                    dbContextTransaction.Commit();
                    rs.SetSuccessStatus();
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    rs.SetErrorStatus(ex.Message); ;
                }
            }

            return rs;
        }

        public ResultStatus Edit(SBH_TM_GALERY_FOTO galery)
        {
            try
            {
                SBH_TM_GALERY_FOTO galeryNew = _ctx.SBH_TM_GALERY_FOTO.Find(galery.ID);
                galeryNew.PHOTO_PATH = galery.PHOTO_PATH;
                galeryNew.DESCRIPTION = galery.DESCRIPTION;
                galeryNew.NEWS_ID = galery.NEWS_ID;
                galeryNew.USER_ID = galery.USER_ID;
                galeryNew.LAST_MODIFIED_TIME = galery.LAST_MODIFIED_TIME;
                galeryNew.LAST_MODIFIED_BY = galery.LAST_MODIFIED_BY;
                _ctx.Entry(galeryNew).State = System.Data.Entity.EntityState.Modified;
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
                SBH_TM_GALERY_FOTO news = _ctx.SBH_TM_GALERY_FOTO.Find(id);
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

        public List<SBH_TM_GALERY_FOTO> GetGaleryByUserId(int userId)
        {
            try
            {
                return _ctx.SBH_TM_GALERY_FOTO.Where(x => x.ROW_STATUS == (int)EnumList.RowStatus.Active && x.USER_ID == userId).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<SBH_TM_GALERY_FOTO> GetGaleryByUserIdAndEventTitle(int userId, string eventTitle)
        {
            try
            {
                return _ctx.SBH_TM_GALERY_FOTO.Where(x => x.ROW_STATUS == (int)EnumList.RowStatus.Active && x.USER_ID == userId  && x.SBH_TM_NEWS.TITLE.ToUpper() == eventTitle.ToUpper()).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public SelectList GetUserList()
        {
            List<SBH_TM_USER_ADMIN> users = _ctx.SBH_TM_USER_ADMIN.Where(x => x.ROW_STATUS == (int)EnumList.RowStatus.Active).ToList();
            SBH_TM_USER_ADMIN user = new SBH_TM_USER_ADMIN { ID = 0, USER_NAME = "Select User :" };

            users.Add(user);
            var userList = users.OrderBy(x => x.ID);

            SelectList selectList = new SelectList(userList, "ID", "USER_NAME");
            return selectList;
        }

        public SelectList GetNewsList()
        {
            SelectList selectList = null;
            int categoryId = _ctx.SBH_TM_CATEGORY.Where(x => x.CATEGORY_NAME.ToUpper() == "EVENT").FirstOrDefault().ID;
            if (categoryId > 0)
            {
                List<SBH_TM_NEWS> newsList = _ctx.SBH_TM_NEWS.Where(x => x.ROW_STATUS == (int)EnumList.RowStatus.Active && x.CATEGORY_ID == categoryId).ToList();
                SBH_TM_NEWS news = new SBH_TM_NEWS { ID = 0, TITLE = "Select Event :" };

                newsList.Add(news);
                var newsListSelection = newsList.OrderBy(x => x.ID);

                selectList = new SelectList(newsListSelection, "ID", "TITLE");
            }
            
            return selectList;
        }

    }
}
