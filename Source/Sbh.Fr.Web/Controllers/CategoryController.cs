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
    public class CategoryController : Controller
    {
        ResultStatus rs = new ResultStatus();
        ICategory repo;
        public CategoryController()
        {
            repo = new CategoryRepo();
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
            List<SBH_TM_CATEGORY> categoryRes = new List<SBH_TM_CATEGORY>();

            categoryRes = repo.GridBind();
            return View(categoryRes);
        }

        public ActionResult Create()
        {
            ViewBag.GetClassButtonList = Dropdown.GetClassButtonList();
            return View();
        }

        [ValidateInput(false)]
        public ActionResult ActionCreate(SBH_TM_CATEGORY categoryView, HttpPostedFileBase postedFile)
        {
            try
            {
                string encodedString = Server.HtmlEncode(categoryView.DESCRIPTION);
                categoryView.DESCRIPTION = encodedString;
                string physicalPath = "";
                if (postedFile != null)
                {
                    string ImageName = System.IO.Path.GetFileName(postedFile.FileName); //file2 to store path and url  
                    physicalPath = Server.MapPath("~" + Common.GetPathFolderImg() + ImageName);

                    //categoryView.IMAGE_PATH = Common.GetPathFolderImg() + ImageName;
                }

                categoryView.CREATED_BY = Session["UserId"].ToString();
                categoryView.CREATED_TIME = DateTime.Now;

                rs = repo.Add(categoryView);
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
            SBH_TM_CATEGORY categoryView = new SBH_TM_CATEGORY();
            SBH_TM_CATEGORY categoryRes = new SBH_TM_CATEGORY();
            ViewBag.GetClassButtonList = Dropdown.GetClassButtonList();

            categoryView.ID = id;

            categoryRes = repo.Retrieve(id);
            return PartialView(categoryRes);
        }

        [ValidateInput(false)]
        public ActionResult ActionEdit(SBH_TM_CATEGORY categoryView, HttpPostedFileBase postedFile)
        {
            try
            {
                string encodedString = Server.HtmlEncode(categoryView.DESCRIPTION);
                categoryView.DESCRIPTION = encodedString;
                string physicalPath = "";
                if (postedFile != null)
                {
                    string ImageName = System.IO.Path.GetFileName(postedFile.FileName); //file2 to store path and url  
                    physicalPath = Server.MapPath("~" + Common.GetPathFolderImg() + ImageName);

                    //categoryView.IMAGE_PATH = Common.GetPathFolderImg() + ImageName;
                }

                categoryView.LAST_MODIFIED_BY = Session["UserId"].ToString();
                categoryView.LAST_MODIFIED_TIME = DateTime.Now;

                rs = repo.Edit(categoryView);
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
            SBH_TM_CATEGORY categoryView = new SBH_TM_CATEGORY();
            SBH_TM_CATEGORY categoryRes = new SBH_TM_CATEGORY();

            categoryView.ID = id;

            categoryRes = repo.Retrieve(id);
            return PartialView(categoryRes);
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
            SBH_TM_CATEGORY categoryView = new SBH_TM_CATEGORY();
            SBH_TM_CATEGORY categoryRes = new SBH_TM_CATEGORY();

            categoryView.ID = id;

            categoryRes = repo.Retrieve(id);
            return PartialView(categoryRes);
        }

    }
}