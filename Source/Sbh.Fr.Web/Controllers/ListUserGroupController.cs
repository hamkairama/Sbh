using Sbh.Fr.Facade.Interface;
using Sbh.Fr.Facade.Repository;
using Sbh.Fr.Model.ClsGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sbh.Fr.Web.Controllers
{
    public class ListUserGroupController : Controller
    {
        private EnumFuncStatus fn = new EnumFuncStatus();

        IListUser repo;
        public ListUserGroupController()
        {
            repo = new ListUserRepo();
        }

        public ActionResult ListUser()
        {
            //ViewBag.lid = TempData["IdQue"] == null ? id : TempData["IdQue"];
            return View(repo.GridBindAll("ListUser"));
        }

        public ActionResult List(string id)
        {
            ViewBag.lid = TempData["IdQue"] == null ? id : TempData["IdQue"];
            return View(repo.GridBindAll("List"));
        }

        [HttpPost]
        public ActionResult List(object[] selectedObjects, string id)
        {
            bool isList = repo.Add(selectedObjects, int.Parse(id), Session["UserName"].ToString());
            if (isList)
                TempData["msgSuccess"] = "Save & Tag your question success.";
            else
                TempData["msgError"] = "Save & Tag your question failed.";

            TempData.Remove("IdQue");

            return RedirectToAction("Index", "Home");
        }
    }
}