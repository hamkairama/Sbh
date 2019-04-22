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
    public class SlideshowController : Controller
    {
        ResultStatus rs = new ResultStatus();
        ISlideshow repo;
        public SlideshowController()
        {
            repo = new SlideshowRepo();
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
            List<SBH_TM_SLIDESHOW> slideshowRes = new List<SBH_TM_SLIDESHOW>();

            slideshowRes = repo.GridBind();
            return View(slideshowRes);
        }

        
        public ActionResult Create()
        {
            ViewBag.GetClassActiveList = Dropdown.GetClassActiveList();

            return View();
        }

        [ValidateInput(false)]
        public ActionResult ActionCreate(SBH_TM_SLIDESHOW slideshowView, HttpPostedFileBase postedFile)
        {
            try
            {
                string encodedString = Server.HtmlEncode(slideshowView.CONTENT_DESCRIPTION);
                slideshowView.CONTENT_DESCRIPTION = encodedString;
                string physicalPath = "";
                if (postedFile != null)
                {
                    string ImageName = System.IO.Path.GetFileName(postedFile.FileName); //file2 to store path and url  
                    physicalPath = Server.MapPath("~" + Common.GetPathFolderImg() + ImageName);

                    slideshowView.PHOTO_PATH = Common.GetPathFolderImg() + ImageName;
                }

                slideshowView.CREATED_BY = Session["UserId"].ToString();
                slideshowView.CREATED_TIME = DateTime.Now;

                rs = repo.Add(slideshowView);
                if (rs.IsSuccess)
                {
                    if (physicalPath != "")
                    {
                        postedFile.SaveAs(physicalPath);
                    }
                    rs.SetSuccessStatus("Data has been created successfully");
                    TempData["msgSuccess"] = rs.MessageText;
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
            SBH_TM_SLIDESHOW slideshowView = new SBH_TM_SLIDESHOW();
            SBH_TM_SLIDESHOW slideshowRes = new SBH_TM_SLIDESHOW();
            ViewBag.GetClassActiveList = Dropdown.GetClassActiveList();

            slideshowView.ID = id;

            slideshowRes = repo.Retrieve(id);
            return PartialView(slideshowRes);
        }

        [ValidateInput(false)]
        public ActionResult ActionEdit(SBH_TM_SLIDESHOW slideshowView, HttpPostedFileBase postedFile)
        {
            try
            {
                string encodedString = Server.HtmlEncode(slideshowView.CONTENT_DESCRIPTION);
                slideshowView.CONTENT_DESCRIPTION = encodedString;
                string physicalPath = "";
                if (postedFile != null)
                {
                    string ImageName = System.IO.Path.GetFileName(postedFile.FileName); //file2 to store path and url  
                    physicalPath = Server.MapPath("~" + Common.GetPathFolderImg() + ImageName);

                    slideshowView.PHOTO_PATH = Common.GetPathFolderImg() + ImageName;
                }

                slideshowView.LAST_MODIFIED_BY = Session["UserId"].ToString();
                slideshowView.LAST_MODIFIED_TIME = DateTime.Now;

                rs = repo.Edit(slideshowView);
                if (rs.IsSuccess)
                {
                    if (physicalPath != "")
                    {
                        postedFile.SaveAs(physicalPath);
                    }

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
            SBH_TM_SLIDESHOW slideshowView = new SBH_TM_SLIDESHOW();
            SBH_TM_SLIDESHOW slideshowRes = new SBH_TM_SLIDESHOW();

            slideshowView.ID = id;

            slideshowRes = repo.Retrieve(id);
            return PartialView(slideshowRes);
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
            SBH_TM_SLIDESHOW slideshowView = new SBH_TM_SLIDESHOW();
            SBH_TM_SLIDESHOW slideshowRes = new SBH_TM_SLIDESHOW();

            slideshowView.ID = id;

            slideshowRes = repo.Retrieve(id);

            return PartialView(slideshowRes);
        }

    }
}