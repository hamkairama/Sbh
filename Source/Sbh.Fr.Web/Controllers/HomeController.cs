using Sbh.Fr.Facade.Interface;
using Sbh.Fr.Facade.Repository;
using Sbh.Fr.Model.ClsGlobal;
using Sbh.Fr.Model.Custom;
using Sbh.Fr.Model.DbCtx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sbh.Fr.Model;
using Sbh.Fr.CommonFunction;

namespace Sbh.Fr.Web.Controllers
{
    public class HomeController : Controller
    {
        private EnumFuncStatus fn = new EnumFuncStatus();

        IContactUs repo;
        IAnswer repoAns;
        ISlideshow slideshowRepo;
        INews newsRepo;
        public HomeController()
        {
            repo = new ContactUsRepo();
            repoAns = new AnswerRepo();
            slideshowRepo = new SlideshowRepo();
            newsRepo = new NewsRepo();            
        }

        public ResultStatus GetCountCategory()
        {
            ResultStatus rs = new ResultStatus();
            List<SBH_TM_NEWS> newsList = new List<SBH_TM_NEWS>();

            try
            {
                rs.SetSuccessStatus();
                newsList = newsRepo.GridBind();

                if (newsList != null || newsList.Count > 0)
                {
                    Session["CountLaporanUtama"] = newsList.Where(x => x.SBH_TM_CATEGORY.CATEGORY_NAME.ToUpper().Replace(" ", "") == "LAPORANUTAMA").Count();
                    Session["CountEdukasi"] = newsList.Where(x => x.SBH_TM_CATEGORY.CATEGORY_NAME.ToUpper().Replace(" ", "") == "EDUKASI").Count();
                    Session["CountPsikologi"] = newsList.Where(x => x.SBH_TM_CATEGORY.CATEGORY_NAME.ToUpper().Replace(" ", "") == "PSIKOLOGI").Count();
                    Session["CountSehat"] = newsList.Where(x => x.SBH_TM_CATEGORY.CATEGORY_NAME.ToUpper().Replace(" ", "") == "SEHAT").Count();
                    Session["CountCantik"] = newsList.Where(x => x.SBH_TM_CATEGORY.CATEGORY_NAME.ToUpper().Replace(" ", "") == "CANTIK").Count();
                    Session["CountKehamilan"] = newsList.Where(x => x.SBH_TM_CATEGORY.CATEGORY_NAME.ToUpper().Replace(" ", "") == "KEHAMILAN").Count();

                    Session["CountNutrisi"] = newsList.Where(x => x.SBH_TM_CATEGORY.CATEGORY_NAME.ToUpper().Replace(" ", "") == "NUTRISI").Count();
                    Session["CountKuliner"] = newsList.Where(x => x.SBH_TM_CATEGORY.CATEGORY_NAME.ToUpper().Replace(" ", "") == "KULINER").Count();
                    Session["CountKilas"] = newsList.Where(x => x.SBH_TM_CATEGORY.CATEGORY_NAME.ToUpper().Replace(" ", "") == "KILAS").Count();
                    Session["CountBermain"] = newsList.Where(x => x.SBH_TM_CATEGORY.CATEGORY_NAME.ToUpper().Replace(" ", "") == "BERMAIN").Count();
                    Session["CountRagam"] = newsList.Where(x => x.SBH_TM_CATEGORY.CATEGORY_NAME.ToUpper().Replace(" ", "") == "RAGAM").Count();

                    Session["CountEvent"] = newsList.Where(x => x.SBH_TM_CATEGORY.CATEGORY_NAME.ToUpper().Replace(" ", "") == "EVENT").Count();
                    Session["CountMagazine"] = newsList.Where(x => x.SBH_TM_CATEGORY.CATEGORY_NAME.ToUpper().Replace(" ", "") == "EMAGAZINE").Count();

                }


            }
            catch (Exception e)
            {
                rs.SetErrorStatus(e.Message);
            }

           
            return rs;
        }

        public ActionResult Index()
        {
            //get count category
            ResultStatus rs = new ResultStatus();
            rs = GetCountCategory();

            ViewBag.msgError = TempData["msgError"];
            ViewBag.msgSuccess = TempData["msgSuccess"];
            TempData.Remove("msgError");
            TempData.Remove("msgSuccess");
            return View(repoAns.GridBindAll(0));
        }

        public ActionResult Pure()
        {
            //get count category
            ResultStatus rs = new ResultStatus();
            rs = GetCountCategory();

            ViewBag.GetSlideshow = slideshowRepo.GridBind();
            return View();
        }

        public ActionResult DetailQA(int id)
        {
            if (TempData["msgS"] != null)
            {
                ViewBag.msgSuccess = TempData["msgS"];
                TempData.Remove("msgS");
            }
            if (TempData["msgE"] != null)
            {
                ViewBag.msgError = TempData["msgE"];
                TempData.Remove("msgE");
            }
            return View(repoAns.GridBindAll(id));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return PartialView();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SideContent()
        {
            return View();
        }

        public ActionResult ContactUs()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ContactUs(ContactUs par)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.msgError = fn.fg.DataIsntValid;
            }
            else
            {
                var isSave = repo.Add(par);
                if (isSave == true)
                {
                    ViewBag.msgSuccess = fn.fg.Save;
                }
                else
                {
                    ViewBag.msgError = fn.fg.SFailed;
                }
            }
            return View("ContactUs");
        }

        public ActionResult News()
        {
            return View();
        }

    }
}