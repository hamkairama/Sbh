using Sbh.Fr.Facade.Interface;
using Sbh.Fr.Facade.Repository;
using Sbh.Fr.Model.ClsGlobal;
using Sbh.Fr.Model.Custom;
using Sbh.Fr.Model.DbCtx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Sbh.Fr.Web.Controllers
{
    public class QuestionController : Controller
    {
        private EnumFuncStatus fn = new EnumFuncStatus();

        IQuestions repo;
        ICategoryQuestions repoCat;

        public QuestionController()
        {
            repo = new QuestionsRepo();
            repoCat = new CategoryQuestionsRepo();
        }

        // GET: Question
        public ActionResult Question()
        {
            ViewBag.IdCat = ddlCatQuestion();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Question(Questions par)
        {
            string id = string.Empty;
            if (!ModelState.IsValid)
            {
                ViewBag.msgError = fn.fg.DataIsntValid;
            }
            else
            {
                par.ID_USER = int.Parse(Session["Id"].ToString());
                par.USER_NAME = Session["UserName"].ToString();
                object[] isSave = repo.Add(par);
                if (isSave[0].ToString() == "1")
                {
                    ViewBag.msgSuccess = fn.fg.Save;
                    id = isSave[1].ToString();
                }
                else
                {
                    ViewBag.msgError = fn.fg.SFailed;
                }
            }
            ViewBag.IdCat = ddlCatQuestion();
            ViewBag.NeedTagQue = "1";
            ViewBag.IdQue = id;
            TempData["IdQue"] = id;
            return View();
        }

        public IEnumerable<SelectListItem> ddlCatQuestion()
        {
            List<SelectListItem> isGet = repoCat.ddlCatQuestion()
                .Select(d => new SelectListItem
                {
                    Value = d.ID.ToString(),
                    Text = d.CATEGORY_DESC
                }).ToList();

            var lGet = new SelectListItem()
            {
                Value = null,
                Text = " "
            };

            isGet.Insert(0, lGet);

            return new SelectList(isGet, "Value", "Text");
        }

    }
}