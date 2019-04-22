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
    public class AnswerController : Controller
    {
        private EnumFuncStatus fn = new EnumFuncStatus();

        IAnswer repo;
        public AnswerController()
        {
            repo = new AnswerRepo();
        }

        public ActionResult Answer()
        {
            return View(repo.GridBind(int.Parse(Session["Id"].ToString())));
        }

        public ActionResult Reply(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var isReply = repo.Retrived(int.Parse(id.ToString()));
            if (isReply != null)
            {
                return View(isReply);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reply(Answer par)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.msgError = fn.fg.DataIsntValid;
            }
            else
            {
                if (Session["Id"] == null)
                {
                    par.ID_USER_ADMIN = 9;//Code for Guest
                    par.CREATED_BY = "Guest";
                }
                else
                {
                    par.ID_USER_ADMIN = int.Parse(Session["Id"].ToString());
                    par.CREATED_BY = Session["UserName"].ToString();
                }

                var isSave = repo.Add(par);
                if (isSave == true)
                    TempData["msgS"] = fn.fg.Save;
                else
                    TempData["msgE"] = fn.fg.SFailed;
            }
            return RedirectToAction("DetailQA/" + par.ID_QUESTIONS.ToString(), "Home");
        }
    }
}