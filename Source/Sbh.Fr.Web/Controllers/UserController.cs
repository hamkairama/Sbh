using Sbh.Fr.CommonFunction;
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
    public class UserController : Controller
    {
        private EnumFuncStatus fn = new EnumFuncStatus();

        IAdmin repo;
        public UserController()
        {
            repo = new UserAdminRepo();
        }

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login par)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.msgError = fn.fg.DataIsntValid;
            }
            else
            {
                Login isLogin = repo.UserLogin(par);
                if (isLogin != null)
                {
                    Session["UserId"] = isLogin.UserId;
                    Session["UserName"] = isLogin.UserName;
                    Session["Id"] = isLogin.Id;
                    Session["IdGroup"] = isLogin.IdGroup;
                    Session["IsSuperAdmin"] = isLogin.IsSuperAdmin;

                    List<UserAdmin> usrAdmin = new List<UserAdmin>();
                    usrAdmin = repo.GridBind();
                    Session["ListUser"] = usrAdmin.Where(x => x.ID != isLogin.Id).ToList();
                    Session["TotalUser"] = usrAdmin.Count() - 1;

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    Session["UserId"] = null;
                    Session["UserName"] = null;
                    Session["Id"] = null;
                    Session["IdGroup"] = null;
                    Session["IsSuperAdmin"] = null;
                    Session["ListUser"] = null;
                    //ViewBag.msgError = "Wrong email or password!";
                    //ViewBag.loginFalse = "1";
                    TempData["msgError"] = "Wrong email or password!";
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            Session.RemoveAll();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            ViewBag.GENDER_ID = ddlGender();
            ViewBag.IdGroup = ddlGroup();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register par)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.msgError = fn.fg.DataIsntValid;
                ViewBag.GENDER_ID = ddlGender();
                ViewBag.IdGroup = ddlGroup();
            }
            else
            {
                if (par.ID_GROUP == 0)
                {
                    par.ID_GROUP = 4;
                }

                if (Session["UserId"] != null)
                {
                    if (Session["IdGroup"].ToString() == "1" || bool.Parse(Session["IsSuperAdmin"].ToString()) == true)
                    {
                        par.IsSuperAdmin = true;
                    }
                    else
                    {
                        par.IsSuperAdmin = false;
                    }

                    par.CREATED_BY = Session["UserName"].ToString();
                }
                else
                {
                    par.CREATED_BY = par.Name;
                }

                var isSave = repo.Add(par);
                if ((bool)isSave[0] == true)
                {
                    ViewBag.msgSuccess = fn.fg.Save;
                    ViewBag.GENDER_ID = ddlGender();
                    ViewBag.IdGroup = ddlGroup();
                }
                else
                {
                    switch ((string)isSave[1])
                    {
                        case "password":
                            ViewBag.msgError = "Password does'nt match!";
                            break;
                        case "email":
                            ViewBag.msgError = "Email does'nt valid!";
                            break;
                        default:
                            ViewBag.msgError = fn.fg.SFailed;
                            break;
                    }
                    ViewBag.GENDER_ID = ddlGender();
                    ViewBag.IdGroup = ddlGroup();
                }
            }
            return View();
        }

        public IEnumerable<SelectListItem> ddlGroup()
        {
            List<SelectListItem> isGet = repo.ddlGroup().Select(d => new SelectListItem
            {
                Value = d.ID.ToString(),
                Text = d.GROUP_DESC
            }).ToList();

            var lGet = new SelectListItem
            {
                Value = null,
                Text = " "
            };

            isGet.Insert(0, lGet);
            return new SelectList(isGet, "Value", "Text");
        }

        public ActionResult Profile(int? id, string tag)
        {
            if (TempData["msgError"] != null)
            {
                ViewBag.msgError = TempData["msgError"];
                TempData.Remove("msgError");
            }
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var isProfile = repo.Retrived(int.Parse(id.ToString()));

            ViewBag.GENDER_ID = ddlGender();
            ViewBag.IdGroup = ddlGroup();
            ViewBag.Tag = tag;
            ViewBag.Id = id;

            if (isProfile != null)
            {
                return View(isProfile);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Profile(Register par)
        {
            string msgE = string.Empty, msgS = string.Empty;
            //try
            //{
            if (!ModelState.IsValid)
            {
                ViewBag.msgError = fn.fg.DataIsntValid;
            }
            else
            {
                if (par.PasswordOld != null || par.Password != null || par.ConfirmPassword != null)
                {
                    var isGetPwd = repo.GetPwd(par.Id);
                    if (isGetPwd != par.PasswordOld)
                        throw new Exception("Old password is incorrect!");
                    else
                    {
                        if (par.Password != par.ConfirmPassword)
                            throw new Exception("Password does'nt match!");
                    }
                }
                else
                {
                    var isEdit = repo.Edit(int.Parse(Session["Id"].ToString()), par);
                    if ((bool)isEdit[0] == true)
                        TempData["msgSuccess"] = fn.fg.Edit;
                    else
                    {
                        switch ((string)isEdit[1])
                        {
                            case "password":
                                TempData["msgError"] = "Password does'nt match!";
                                break;
                            case "email":
                                TempData["msgError"] = "Email does'nt valid!";
                                break;
                            default:
                                TempData["msgError"] = fn.fg.SFailed;
                                break;
                        }
                        //ViewBag.GENDER_ID = ddlGender();
                        //ViewBag.IdGroup = ddlGroup();
                    }
                }
            }
            //}
            //catch (Exception ex)
            //{
            //    TempData["msgError"] = fn.fg.EFailed;
            //}
            return RedirectToAction("Index", "Home");
        }

        public IEnumerable<SelectListItem> ddlGender()
        {
            List<SelectListItem> isGet = repo.ddlGender().Select(d => new SelectListItem
            {
                Value = d.GENDER_ID.ToString(),
                Text = d.GENDER_DESC
            }).ToList();

            var lGet = new SelectListItem()
            {
                Value = null,
                Text = " "
            };

            isGet.Insert(0, lGet);
            return new SelectList(isGet, "Value", "Text");
        }

        public ActionResult ViewProfile(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var isProfile = repo.Retrived(int.Parse(id.ToString()));

            return PartialView("ViewProfile", isProfile);
        }

        public ActionResult ChangePassword()
        {
            return PartialView("ChangePassword");
        }

        public ActionResult ActionChangePassword(ChangePassword changePassword)
        {
            ResultStatus rs = new ResultStatus();
            changePassword.CREATED_BY = Session["UserName"].ToString();
            changePassword.CREATED_TIME = DateTime.Now;
            changePassword.LAST_MODIFIED_BY= Session["UserName"].ToString();
            changePassword.LAST_MODIFIED_TIME = DateTime.Now;

            //if (ModelState.IsValid)
            //{
                try
                {
                    rs = repo.ChangePassword(Convert.ToInt32(Session["UserId"]), changePassword.OldPassword, changePassword.NewPassword);
                    if (rs.IsSuccess)
                    {
                        TempData["msgSuccess"] = rs.MessageText;
                    }
                    else
                    {
                        TempData["msgError"] = rs.MessageText;
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    rs.SetErrorStatus("Data failed to changed");
                    TempData["msgError"] = rs.MessageText;
                }
            //}
            //else
            //{
            //    TempData["ErrorPageModal"] = "Invalid data";
            //}
            return RedirectToAction("Index", "Home");
        }
    }
}