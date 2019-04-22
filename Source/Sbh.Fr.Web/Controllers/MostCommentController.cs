﻿using Sbh.Fr.Facade.Interface;
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
    public class MostCommentController : Controller
    {
        private EnumFuncStatus fn = new EnumFuncStatus();

        IMostComment repo;
        public MostCommentController()
        {
            repo = new MostCommentRepo();
        }

        public ActionResult ListMostComment()
        {
            ViewBag.msgError = TempData["msgError"];
            ViewBag.msgSuccess = TempData["msgSuccess"];
            TempData.Remove("msgError");
            TempData.Remove("msgSuccess");

            return View(repo.GridBind());
        }

        public ActionResult Detail(int? id)
        {
            return View(repo.Retrived((int)id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Detail(MostComment par)
        {
            if (!ModelState.IsValid)
                TempData["msgError"] = fn.fg.DataIsntValid;
            else
            {
                par.LAST_MODIFIED_BY = Session["UserName"].ToString();

                var isEdit = repo.Edit(par.ID, par);
                if (isEdit)
                    TempData["msgSuccess"] = fn.fg.Edit;
                else
                    TempData["msgError"] = fn.fg.EFailed;
            }
            return RedirectToAction("ListMostComment", "MostComment");
        }

        public ActionResult AddData()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddData(MostComment par)
        {
            par.CREATED_BY = Session["UserName"].ToString();
            par.CREATED_TIME = DateTime.Now;

            var isSave = repo.Add(par);
            if (isSave)
                TempData["msgSuccess"] = fn.fg.Save;
            else
                TempData["msgError"] = fn.fg.SFailed;

            return RedirectToAction("ListMostComment", "MostComment");
        }

        public ActionResult Remove(int? id)
        {
            return View(repo.Retrived((int)id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(int id)
        {
            var isRemove = repo.Delete(id, Session["UserName"].ToString());
            if (isRemove)
                TempData["msgSuccess"] = fn.fg.Delete;
            else
                TempData["msgError"] = fn.fg.DFailed;

            return RedirectToAction("ListMostComment", "MostComment");
        }
    }
}