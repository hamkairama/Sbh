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
using Sbh.Fr.Model.Master;

namespace Sbh.Fr.Facade.Repository
{
    public class QuestionsRepo : IQuestions
    {
        private EnumStatus fn = new EnumStatus();
        private DbConn _ctx = new DbConn();

        public QuestionsRepo()
        {
            _ctx = new DbConn();
        }

        public object[] Add(Questions par)
        {
            object[] res;
            string flag = "0";
            try
            {
                int maxid = 0;
                try
                {
                    SBH_TR_QUESTIONS o = _ctx.SBH_TR_QUESTIONS.OrderByDescending(s => s.ID).First();
                    maxid = o.ID + 1;
                }
                catch { maxid = maxid + 1; }


                SBH_TR_QUESTIONS a = new SBH_TR_QUESTIONS()
                {
                    ID_CATEGORY = par.ID_CATEGORY,
                    ID_USER = par.ID_USER,
                    QUESTIONS = par.QUESTIONS,
                    CREATED_TIME = DateTime.Now,
                    CREATED_BY = par.USER_NAME,
                    ROW_STATUS = fn.fg.IsActive,
                    MOST_COMMENT = 0,
                    TITLE_QUESTIONS = par.TITLE_QUESTIONS,
                    MAXID = maxid
                };
                _ctx.SBH_TR_QUESTIONS.Add(a);
                _ctx.SaveChanges();

                SBH_TM_USER_ADMIN b = _ctx.SBH_TM_USER_ADMIN.Find(par.ID_USER);
                if (b != null)
                {
                    int x = 0;
                    if (!String.IsNullOrWhiteSpace(b.MOST_ACT_QUESTIONS.ToString()))
                        x = int.Parse(b.MOST_ACT_QUESTIONS.ToString());

                    b.MOST_ACT_QUESTIONS = x + 1;
                    b.MOST_ACT_QUESTIONS_DATE = DateTime.Now;

                    _ctx.Entry(b).State = System.Data.Entity.EntityState.Modified;
                    _ctx.SaveChanges();
                }

                flag = "1";
                res = new object[] { flag, maxid };
            }
            catch (Exception ex)
            {
                res = new object[] { flag, "" };
                throw new Exception(ex.Message);
            }
            return res;
        }

        public bool Delete(int id)
        {
            bool res = false;
            try
            {
                SBH_TR_QUESTIONS a = _ctx.SBH_TR_QUESTIONS.Find(id);
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

        public bool Edit(int id, Questions par)
        {
            bool res = false;
            try
            {
                SBH_TR_QUESTIONS a = _ctx.SBH_TR_QUESTIONS.Find(id);
                if (a != null)
                {
                    a.ID_CATEGORY = par.ID_CATEGORY;
                    //a.ID_USER = par.ID_USER;
                    a.QUESTIONS = par.QUESTIONS;
                    a.CREATED_BY = null;
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

        public List<Questions> GridBind()
        {
            try
            {
                List<Questions> lA = new List<Questions>();
                foreach (var item in _ctx.SBH_TR_QUESTIONS.Where(x => x.ROW_STATUS == fn.fg.IsActive))
                {
                    Questions oA = new Questions();
                    oA.ID = item.ID;
                    oA.ID_CATEGORY = item.ID_CATEGORY;
                    //oA.ID_USER = item.ID_USER;
                    oA.QUESTIONS = item.QUESTIONS;
                    //oA.CREATED_TIME = item.CREATED_TIME;
                    //oA.CREATED_BY = item.CREATED_BY;
                    //oA.LAST_MODIFIED_TIME = item.LAST_MODIFIED_TIME;
                    //oA.LAST_MODIFIED_BY = item.LAST_MODIFIED_BY;
                    //oA.ROW_STATUS = item.ROW_STATUS;

                    lA.Add(oA);
                }
                return lA;
            }
            catch (Exception ex)
            {
                return null;
                throw new Exception(ex.Message);
            }
        }

        public Questions Retrived(int id)
        {
            try
            {
                Questions oA = new Questions();
                SBH_TR_QUESTIONS oB = _ctx.SBH_TR_QUESTIONS.Where(x => x.ID == id && x.ROW_STATUS == fn.fg.IsActive).FirstOrDefault();
                if (oB != null)
                {
                    oA.ID = oB.ID;
                    oA.ID_CATEGORY = oB.ID_CATEGORY;
                    //oA.ID_USER = oB.ID_USER;
                    oA.QUESTIONS = oB.QUESTIONS;
                    //oA.CREATED_TIME = oB.CREATED_TIME;
                    //oA.CREATED_BY = oB.CREATED_BY;
                    //oA.LAST_MODIFIED_TIME = oB.LAST_MODIFIED_TIME;
                    //oA.LAST_MODIFIED_BY = oB.LAST_MODIFIED_BY;
                    //oA.ROW_STATUS = oB.ROW_STATUS;

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
