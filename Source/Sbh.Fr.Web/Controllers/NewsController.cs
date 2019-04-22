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
    public class NewsController : Controller
    {
        ResultStatus rs = new ResultStatus();
        INews repo;
        public NewsController()
        {
            repo = new NewsRepo();
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
            List<SBH_TM_NEWS> NEWSRes = new List<SBH_TM_NEWS>();

            NEWSRes = repo.GridBind();
            return View(NEWSRes);
        }

        public ActionResult Create()
        {
            //ViewBag.GetClassButtonList = Dropdown.GetClassButtonList();
            ViewBag.GetTemplateList = Dropdown.GetTemplateList();
            ViewBag.GetCategoryList = repo.GetCategoryList();
            return View();
        }       

        [ValidateInput(false)]
        public ActionResult ActionCreate(SBH_TM_NEWS NEWSView, HttpPostedFileBase postedFile)
        {
            string a = Request.Form["storeImage"];


            try
            {
                string encodedString = Server.HtmlEncode(NEWSView.DESCRIPTION);
                NEWSView.DESCRIPTION = encodedString;
                string physicalPath = "";
                if (postedFile != null)
                {
                    string ImageName = System.IO.Path.GetFileName(postedFile.FileName); //file2 to store path and url  
                    physicalPath = Server.MapPath("~" + Common.GetPathFolderImg() + ImageName);

                    NEWSView.FILE_IMAGE1 = Common.GetPathFolderImg() + ImageName;
                }

                NEWSView.CREATED_BY = Session["UserId"].ToString();
                NEWSView.CREATED_TIME = DateTime.Now;

                rs = repo.Add(NEWSView);
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
            SBH_TM_NEWS NEWSView = new SBH_TM_NEWS();
            SBH_TM_NEWS NEWSRes = new SBH_TM_NEWS();
            //ViewBag.GetClassButtonList = Dropdown.GetClassButtonList();
            ViewBag.GetTemplateList = Dropdown.GetTemplateList();
            ViewBag.GetCategoryList = repo.GetCategoryList();

            NEWSView.ID = id;

            NEWSRes = repo.Retrieve(id);
            return PartialView(NEWSRes);
        }

        [ValidateInput(false)]
        public ActionResult ActionEdit(SBH_TM_NEWS NEWSView, HttpPostedFileBase postedFile)
        {
            try
            {
                //string toInsert = NEWSView.DESCRIPTION;
                string encodedString = Server.HtmlEncode(NEWSView.DESCRIPTION);
                NEWSView.DESCRIPTION = encodedString;
                string physicalPath = "";
                if (postedFile != null)
                {
                    string ImageName = System.IO.Path.GetFileName(postedFile.FileName); //file2 to store path and url  
                    physicalPath = Server.MapPath("~" + Common.GetPathFolderImg() + ImageName);

                    NEWSView.FILE_IMAGE1 = Common.GetPathFolderImg() + ImageName;
                }

                NEWSView.LAST_MODIFIED_BY = Session["UserId"].ToString();
                NEWSView.LAST_MODIFIED_TIME = DateTime.Now;

                rs = repo.Edit(NEWSView);
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
            SBH_TM_NEWS NEWSView = new SBH_TM_NEWS();
            SBH_TM_NEWS NEWSRes = new SBH_TM_NEWS();

            NEWSView.ID = id;

            NEWSRes = repo.Retrieve(id);
            return PartialView(NEWSRes);
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
            SBH_TM_NEWS NEWSView = new SBH_TM_NEWS();
            SBH_TM_NEWS NEWSRes = new SBH_TM_NEWS();

            NEWSView.ID = id;

            NEWSRes = repo.Retrieve(id);
            return PartialView(NEWSRes);
        }

        public ActionResult ListNewsBox(int categoryId)
        {
            ViewBag.msgSuccess = TempData["msgSuccess"];
            ViewBag.msgError = TempData["msgError"];
            List<SBH_TM_NEWS> NEWSRes = new List<SBH_TM_NEWS>();

            NEWSRes = repo.GetnewsByCategoryId(categoryId);
            if (NEWSRes.Count > 0)
            {
                ViewBag.ActiveSubMenu = NEWSRes[0].SBH_TM_CATEGORY.CATEGORY_NAME;
            }

            return View(NEWSRes);
        }

        public ActionResult DetailNewsBox(int categoryId, int newsId)
        {
            ViewBag.msgSuccess = TempData["msgSuccess"];
            ViewBag.msgError = TempData["msgError"];
            List<SBH_TM_NEWS> NEWSRes = new List<SBH_TM_NEWS>();

            NEWSRes = repo.GetnewsByCategoryId(categoryId);
            if (NEWSRes.Count > 0)
            {
                ViewBag.ActiveSubMenu = NEWSRes[0].SBH_TM_CATEGORY.CATEGORY_NAME;
            }

            string templateId = "";
            string templateViewName = "";
            if (newsId > 0)
            {
                templateId = NEWSRes.Where(x => x.ID == newsId).FirstOrDefault().TEMPLATE;
                ViewBag.NewsSelectedId = newsId;
                if (templateId == "1")
                {
                    templateViewName = "DetailNewsBoxTemplate1";
                }
                else if (templateId == "2")
                {
                    templateViewName = "DetailNewsBoxTemplate2";
                }
                else if (templateId == "3")
                {
                    templateViewName = "DetailNewsBoxTemplate3";
                }
                else
                {
                    templateViewName = "DetailNewsBoxTemplate4";
                }
            }

            return View(templateViewName, NEWSRes);

        }

    }

}