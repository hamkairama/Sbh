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
using Sbh.Fr.Model.View;
using Sbh.Fr.Model.Master;

namespace Sbh.Fr.Facade.Repository
{
    public class AnswerRepo : IAnswer
    {
        private EnumStatus fn = new EnumStatus();
        private DbConn _ctx = new DbConn();

        public AnswerRepo()
        {
            _ctx = new DbConn();
        }

        public bool Add(Answer ans)
        {
            bool res = false;
            try
            {
                SBH_TR_ANSWER a = new SBH_TR_ANSWER()
                {
                    ID_QUESTIONS = ans.ID_QUESTIONS,
                    ID_USER_ADMIN = ans.ID_USER_ADMIN,
                    ANSWER = ans.ANSWER,
                    CREATED_TIME = DateTime.Now,
                    CREATED_BY = ans.CREATED_BY,
                    ROW_STATUS = fn.fg.IsActive
                };
                _ctx.SBH_TR_ANSWER.Add(a);
                _ctx.SaveChanges();

                SBH_TR_QUESTIONS b = _ctx.SBH_TR_QUESTIONS.Find(ans.ID_QUESTIONS);
                if (b != null)
                {
                    b.MOST_COMMENT_DATE = DateTime.Now;
                    b.MOST_COMMENT = b.MOST_COMMENT + 1;

                    _ctx.Entry(b).State = System.Data.Entity.EntityState.Modified;
                    _ctx.SaveChanges();
                }

                //Answer from Guest doesn't record
                if (ans.ID_USER_ADMIN != 9)
                {
                    SBH_TM_USER_ADMIN c = _ctx.SBH_TM_USER_ADMIN.Find(ans.ID_USER_ADMIN);
                    if (c != null)
                    {
                        int x = 0;
                        if (!String.IsNullOrWhiteSpace(c.MOST_ACT_ANSWER.ToString()))
                            x = int.Parse(c.MOST_ACT_ANSWER.ToString());

                        c.MOST_ACT_ANSWER = x + 1;
                        c.MOST_ACT_ANSWER_DATE = DateTime.Now;

                        _ctx.Entry(c).State = System.Data.Entity.EntityState.Modified;
                        _ctx.SaveChanges();
                    }
                }

                SBH_TR_QUESTIONS_TAGGING d = _ctx.SBH_TR_QUESTIONS_TAGGING.Where(x => x.ID_QUESTIONS == ans.ID_QUESTIONS && x.ID_USER_TAGGING == ans.ID_USER_ADMIN).FirstOrDefault();
                if (d != null)
                {
                    d.ANSWER_STATUS = fn.fg.IsActive;
                    d.LAST_MODIFIED_TIME = DateTime.Now;
                    d.LAST_MODIFIED_BY = ans.CREATED_BY;
                    _ctx.Entry(d).State = System.Data.Entity.EntityState.Modified;
                    _ctx.SaveChanges();
                }
                res = true;
            }
            catch (Exception ex)
            {
                res = false;
            }
            return res;
        }

        public bool Delete(int id)
        {
            bool res = false;
            try
            {
                SBH_TR_ANSWER a = _ctx.SBH_TR_ANSWER.Find(id);
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

        public bool Edit(int id, Answer ans)
        {
            bool res = false;
            try
            {
                SBH_TR_ANSWER a = _ctx.SBH_TR_ANSWER.Find(id);
                if (a != null)
                {
                    a.ID = ans.ID;
                    a.ID_QUESTIONS = ans.ID_QUESTIONS;
                    a.ID_USER_ADMIN = ans.ID_USER_ADMIN;
                    a.ANSWER = ans.ANSWER;
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

        public List<QuestionAndAnswerCustoms> GridBindAll(int id)
        {
            try
            {
                List<QuestionAndAnswerCustoms> lA = new List<QuestionAndAnswerCustoms>();

                List<QuestionAndAnswer> lQa = new List<QuestionAndAnswer>();
                if (id != 0)
                    lQa = _ctx.QuestionAndAnswers.Where(s => s.ID_QUESTIONS == id).OrderByDescending(x => x.ID).ToList();
                else
                    lQa = _ctx.QuestionAndAnswers.OrderByDescending(x => x.ID).ToList();

                foreach (var item in lQa)
                {
                    var QUESTION = "";
                    if (item.QUESTIONS.Length > 150)
                        QUESTION = item.QUESTIONS.Substring(0, 150) + "...";
                    else
                        QUESTION = item.QUESTIONS;

                    QuestionAndAnswerCustoms oA = new QuestionAndAnswerCustoms();
                    oA.Id = item.ID;
                    oA.IdQuestions = item.ID_QUESTIONS;
                    oA.IdCategory = item.ID_CATEGORY;
                    oA.CategoryDesc = item.CATEGORY_DESC;
                    oA.IdUserQuestions = item.ID_USER_QUESTIONS;
                    oA.QuestionsName = item.QUESTIONS_NAME;
                    oA.Questions = QUESTION;
                    oA.Answer = item.ANSWER;
                    oA.IdUserAnswer = item.ID_USER_ANSWER;
                    oA.AnswerName = item.ANSWER_NAME;
                    oA.IdQuestionsAnswer = item.ID_QUESTIONS_ANSWER;
                    oA.DateQustion = item.DATE_QUESTION;
                    oA.DateAnswer = item.DATE_ANSWER;
                    oA.TitleQuestions = item.TITLE_QUESTIONS;
                    oA.SumComment = item.SumComment;
                    oA.MostComment = item.MOST_COMMENT;

                    lA.Add(oA);
                }
                return lA;
            }
            catch (Exception e)
            {
                return null;
                throw;
            }
        }

        public List<TaskListUserCustoms> GridBind(int id)
        {
            try
            {
                List<TaskListUserCustoms> lA = new List<TaskListUserCustoms>();
                foreach (var item in _ctx.TaskListUser.Where(x => x.ID_USER_TAGGING == id).ToList())
                {
                    TaskListUserCustoms oA = new TaskListUserCustoms();
                    oA.ID = item.ID;
                    oA.ID_USER_TAGGING = item.ID_USER_TAGGING;
                    oA.CATEGORY_DESC = item.CATEGORY_DESC;
                    oA.USER_NAME = item.USER_NAME;
                    oA.USER_MAIL = item.USER_MAIL;
                    oA.TITLE_QUESTIONS = item.TITLE_QUESTIONS;
                    oA.QUESTIONS = item.QUESTIONS;
                    oA.CREATED_TIME = item.CREATED_TIME;
                    oA.CREATED_BY = item.CREATED_BY;

                    lA.Add(oA);
                }
                return lA;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Answer Retrived(int id)
        {
            try
            {
                Answer oA = new Answer();
                SBH_TR_QUESTIONS oB = _ctx.SBH_TR_QUESTIONS.Where(x => x.ROW_STATUS == fn.fg.IsActive && x.ID == id).FirstOrDefault();
                if (oB != null)
                {
                    oA.ID_QUESTIONS = id;
                    oA.QUESTIONS = oB.QUESTIONS;
                    oA.TITLE_QUESTIONS = oB.TITLE_QUESTIONS;

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
