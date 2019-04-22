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
    public class CategoryQuestionsRepo : ICategoryQuestions
    {
        private EnumStatus fn = new EnumStatus();
        private DbConn _ctx = new DbConn();

        public CategoryQuestionsRepo()
        {
            _ctx = new DbConn();
        }

        public bool Add(CategoryQuestions par)
        {
            bool res = false;
            try
            {
                SBH_TM_CATEGORY_QUESTIONS a = new SBH_TM_CATEGORY_QUESTIONS()
                {
                    CATEGORY_DESC = par.CATEGORY_DESC,
                    CREATED_TIME = par.CREATED_TIME,
                    CREATED_BY = par.CREATED_BY,
                    ROW_STATUS = fn.fg.IsActive
                };
                _ctx.SBH_TM_CATEGORY_QUESTIONS.Add(a);
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
                SBH_TM_CATEGORY_QUESTIONS a = _ctx.SBH_TM_CATEGORY_QUESTIONS.Find(id);
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

        public bool Edit(int id, CategoryQuestions par)
        {
            bool res = false;
            try
            {
                SBH_TM_CATEGORY_QUESTIONS a = _ctx.SBH_TM_CATEGORY_QUESTIONS.Find(id);
                if (a != null)
                {
                    a.CATEGORY_DESC = par.CATEGORY_DESC;
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

        public List<CategoryQuestions> GridBind()
        {
            try
            {
                List<CategoryQuestions> lA = new List<CategoryQuestions>();
                foreach (var item in _ctx.SBH_TM_CATEGORY_QUESTIONS
                    .Where(x => x.ROW_STATUS == fn.fg.IsActive))
                {
                    CategoryQuestions oA = new CategoryQuestions();
                    oA.ID = item.ID;
                    oA.CATEGORY_DESC = item.CATEGORY_DESC;

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

        public IEnumerable<SBH_TM_CATEGORY_QUESTIONS> ddlCatQuestion()
        {
            try
            {
                List<SBH_TM_CATEGORY_QUESTIONS> l = _ctx.SBH_TM_CATEGORY_QUESTIONS.Where(d => d.ROW_STATUS == 0).ToList();
                return l;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public CategoryQuestions Retrived(int id)
        {
            try
            {
                CategoryQuestions oA = new CategoryQuestions();
                SBH_TM_CATEGORY_QUESTIONS oB = _ctx.SBH_TM_CATEGORY_QUESTIONS
                    .Where(x => x.ROW_STATUS == fn.fg.IsActive && x.ID == id).FirstOrDefault();
                if (oB != null)
                {
                    oA.ID = oB.ID;
                    oA.CATEGORY_DESC = oB.CATEGORY_DESC;

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
