using Sbh.Fr.CommonFunction;
using Sbh.Fr.Facade.Interface;
using Sbh.Fr.Facade.Repository;
using Sbh.Fr.Model;
using Sbh.Fr.Model.ClsGlobal;
using Sbh.Fr.Model.Custom;
using Sbh.Fr.Model.DbCtx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sbh.Fr.Web.Controllers
{
    public class GaleryPhotoController : Controller
    {
        ResultStatus rs = new ResultStatus();
        IGaleryPhoto repo;
        public GaleryPhotoController()
        {
            repo = new GaleryPhotoRepo();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Index()
        {
            ViewBag.msgSuccess = TempData["msgSuccess"];
            ViewBag.msgError = TempData["msgError"];
            List<SBH_TM_GALERY_FOTO> res = new List<SBH_TM_GALERY_FOTO>();
            if (!(bool)Session["IsSuperAdmin"])
            {
                res = repo.GetGaleryByUserId((int)Session["Id"]);
            }
            else
            {
                res = repo.GridBind();
            }

            List<SBH_TM_GALERY_FOTO> resNew = new List<SBH_TM_GALERY_FOTO>();         
            if (res.Count > 0)
            {
                var arry = res.Select(i =>
                                new { createdBy = i.CREATED_BY, eventTitle = i.SBH_TM_NEWS.TITLE })
                                .Distinct().OrderByDescending(s => s).ToArray();

                foreach (var item in arry)
                {
                    SBH_TM_GALERY_FOTO glr = new SBH_TM_GALERY_FOTO();
                    glr.CREATED_BY = item.createdBy;
                    glr.DESCRIPTION = item.eventTitle; //use field description to declare event title

                    resNew.Add(glr);
                }
            }

            return View(resNew);
        }

        public ActionResult Create()
        {
            ViewBag.GetNewsList = repo.GetNewsList();
            ViewBag.GetUserList = repo.GetUserList();
            return View();
        }

        [ValidateInput(false)]
        public ActionResult ActionCreate(SBH_TM_GALERY_FOTO galeryView)
        {
            string a = Request.Form["storeImage"];

            try
            {
                string encodedString = Server.HtmlEncode(galeryView.DESCRIPTION);
                galeryView.DESCRIPTION = encodedString;
                galeryView.USER_ID = (int)Session["Id"];
                galeryView.CREATED_BY = Session["UserId"].ToString();
                galeryView.CREATED_TIME = DateTime.Now;
                List<string> lString = CData.GetListString;

                rs = repo.AddAll(galeryView, lString);
                if (rs.IsSuccess)
                {
                    rs.SetSuccessStatus("Data has been created successfully");
                    TempData["msgSuccess"] = rs.MessageText;
                    CData.CleanDataString();
                }
                else
                {
                    rs.SetErrorStatus("Data failed to created");
                    TempData["msgError"] = rs.MessageText;
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                rs.SetErrorStatus("Data failed to created");
                TempData["msgError"] = rs.MessageText;
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            SBH_TM_GALERY_FOTO res = new SBH_TM_GALERY_FOTO();
            ViewBag.GetNewsList = repo.GetNewsList();
            ViewBag.GetUserList = repo.GetUserList();

            res = repo.Retrieve(id);
            return PartialView(res);
        }

        [ValidateInput(false)]
        public ActionResult ActionEdit(SBH_TM_GALERY_FOTO galeryView, HttpPostedFileBase postedFile)
        {
            try
            {
                string encodedString = Server.HtmlEncode(galeryView.DESCRIPTION);
                galeryView.DESCRIPTION = encodedString;

                galeryView.LAST_MODIFIED_BY = Session["UserId"].ToString();
                galeryView.LAST_MODIFIED_TIME = DateTime.Now;

                rs = repo.Edit(galeryView);
                if (rs.IsSuccess)
                {
                    rs.SetSuccessStatus("Data has been edited successfully");
                    TempData["msgSuccess"] = rs.MessageText;
                }
                else
                {
                    rs.SetErrorStatus("Data failed to edited");
                    TempData["msgError"] = rs.MessageText;
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                rs.SetErrorStatus("Data failed to edited");
                TempData["msgError"] = rs.MessageText;
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            SBH_TM_GALERY_FOTO res = new SBH_TM_GALERY_FOTO();

            res = repo.Retrieve(id);
            return PartialView(res);
        }

        public ActionResult ActionDelete(int id)
        {
            try
            {
                rs = repo.Delete(id, Session["UserId"].ToString(), DateTime.Now);
                if (rs.IsSuccess)
                {
                    rs.SetSuccessStatus("Data has been deleted successfully");
                    TempData["msgSuccess"] = rs.MessageText;
                }
                else
                {
                    rs.SetErrorStatus("Data failed to deleted");
                    TempData["msgError"] = rs.MessageText;
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                rs.SetErrorStatus("Data failed to deleted");
                TempData["msgError"] = rs.MessageText;
            }

            return RedirectToAction("Index");
        }

        public ActionResult Detail(int id)
        {
            SBH_TM_GALERY_FOTO res = new SBH_TM_GALERY_FOTO();

            res = repo.Retrieve(id);
            return PartialView(res);
        }

        public ActionResult GetListGaleryByUserId()
        {
            List<SBH_TM_GALERY_FOTO> res = new List<SBH_TM_GALERY_FOTO>();

            res = repo.GetGaleryByUserId((int)Session["Id"]);
            return View(res);
        }

        public ActionResult GetListGaleryByUserIdAndEventTitle(string eventTitle)
        {
            List<SBH_TM_GALERY_FOTO> res = new List<SBH_TM_GALERY_FOTO>();

            res = repo.GetGaleryByUserIdAndEventTitle((int)Session["Id"], eventTitle);
            ViewBag.EventTitle = eventTitle;
            return View("ListGalery", res);
        }


    }

}