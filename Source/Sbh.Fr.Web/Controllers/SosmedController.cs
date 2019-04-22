using Sbh.Fr.CommonFunction;
using Sbh.Fr.Facade.Interface;
using Sbh.Fr.Facade.Repository;
using Sbh.Fr.Model;
using Sbh.Fr.Model.ClsGlobal;
using Sbh.Fr.Model.Custom;
using Sbh.Fr.Model.DbCtx;
using Sbh.Fr.Model.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sbh.Fr.Web.Controllers
{
    public class SosmedController : Controller
    {
        ResultStatus rs = new ResultStatus();
        ISosmed repo;
        public SosmedController()
        {
            repo = new SosmedRepo();
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
            List<SBH_TM_SOSMED> sosmedRes = new List<SBH_TM_SOSMED>();

            sosmedRes = repo.GridBind();
            return View(sosmedRes);
        }

        public ActionResult Create()
        {
            ViewBag.GetTypeSosmedList = Dropdown.GetTypeSosmedList();
            ViewBag.GetTrueFalse = Dropdown.GetTrueFalse();

            return View();
        }

        public ActionResult ActionCreate(SBH_TM_SOSMED sosmedView, HttpPostedFileBase postedFile)
        {
            try
            {
                string physicalPath = "";
                if (postedFile != null)
                {
                    string ImageName = System.IO.Path.GetFileName(postedFile.FileName); //file2 to store path and url  
                    physicalPath = Server.MapPath("~" + Common.GetPathFolderImg() + ImageName);

                    sosmedView.PHOTO_PATH = Common.GetPathFolderImg() + ImageName;
                }

                sosmedView.LAST_MODIFIED_BY = Session["UserId"].ToString();
                sosmedView.LAST_MODIFIED_TIME = DateTime.Now;

                rs = repo.Add(sosmedView);
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
            SBH_TM_SOSMED sosmedView = new SBH_TM_SOSMED();
            SBH_TM_SOSMED sosmedRes = new SBH_TM_SOSMED();

            sosmedView.ID = id;
            ViewBag.GetTypeSosmedList = Dropdown.GetTypeSosmedList();
            ViewBag.GetTrueFalse = Dropdown.GetTrueFalse();

            sosmedRes = repo.Retrived(id);
            return PartialView(sosmedRes);
        }
        public ActionResult ActionEdit(SBH_TM_SOSMED sosmedView, HttpPostedFileBase postedFile)
        {
            try
            {
                string physicalPath = "";
                if (postedFile != null)
                {
                    string ImageName = System.IO.Path.GetFileName(postedFile.FileName); //file2 to store path and url  
                    physicalPath = Server.MapPath("~" + Common.GetPathFolderImg() + ImageName);

                    sosmedView.PHOTO_PATH = Common.GetPathFolderImg() + ImageName;
                }

                sosmedView.LAST_MODIFIED_BY = Session["UserId"].ToString();
                sosmedView.LAST_MODIFIED_TIME = DateTime.Now;

                rs = repo.Edit(sosmedView.ID, sosmedView);
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
            SBH_TM_SOSMED sosmedView = new SBH_TM_SOSMED();
            SBH_TM_SOSMED sosmedRes = new SBH_TM_SOSMED();

            sosmedView.ID = id;

            sosmedRes = repo.Retrived(id);
            return PartialView(sosmedRes);
        }
        public ActionResult ActionDelete(int id)
        {
            try
            {
                string userId = Session["UserId"].ToString();
                DateTime dt = DateTime.Now;
                rs = repo.Delete(id);
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
            SBH_TM_SOSMED sosmedView = new SBH_TM_SOSMED();
            SBH_TM_SOSMED sosmedRes = new SBH_TM_SOSMED();

            sosmedView.ID = id;

            sosmedRes = repo.Retrived(id);
            return PartialView(sosmedRes);
        }

       

    }
}