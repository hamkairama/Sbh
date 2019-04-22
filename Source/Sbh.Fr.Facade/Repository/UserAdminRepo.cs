using Sbh.Fr.Facade.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sbh.Fr.Model.Custom;
using Sbh.Fr.Model.ClsGlobal;
using Sbh.Fr.Model.DbCtx;
using Sbh.Fr.Model.Master;
using Sbh.Fr.Model.View;
using Sbh.Fr.CommonFunction;
using System.Data.Entity;

namespace Sbh.Fr.Facade.Repository
{
    public class UserAdminRepo : IAdmin
    {
        private EnumStatus fn = new EnumStatus();
        private DbConn _ctx = new DbConn();
        private EnumFuncStatus fnn = new EnumFuncStatus();

        public UserAdminRepo()
        {
            _ctx = new DbConn();
        }

        public object[] Add(Register par)
        {
            object[] res = null;
            try
            {
                if (par.ConfirmPassword != par.Password)
                    throw new Exception("password");
                if (IsValidEmail(par.Email) == false)
                    throw new Exception("email");

                var x = _ctx.SBH_TM_USER_ADMIN.ToList().Count();

                SBH_TM_USER_ADMIN a = new SBH_TM_USER_ADMIN()
                {
                    ID_USER_ADMIN = x.ToString(),
                    ID_GROUP = par.ID_GROUP,
                    USER_MAIL = par.Email,
                    USER_NAME = par.Name,
                    PASSWORD = par.Password,
                    IS_SUPER_ADMIN = par.IsSuperAdmin,
                    CREATED_TIME = DateTime.Now,
                    CREATED_BY = par.CREATED_BY == null ? par.Name : par.CREATED_BY,
                    ROW_STATUS = fn.fg.IsActive
                };
                _ctx.SBH_TM_USER_ADMIN.Add(a);
                _ctx.SaveChanges();

                SBH_TM_USER_PROFILE_ADMIN b = new SBH_TM_USER_PROFILE_ADMIN()
                {
                    ID_USER_ADMIN = x,
                    GENDER = par.Gender,
                    BORN = par.Born,
                    ADDRESS = par.Address,
                    DESCRIPTION = par.OtherDescription,
                    JOB = par.Job,
                    COMPANY = par.Company,
                    HOBBY = par.Hobby,
                    CREATED_TIME = DateTime.Now,
                    CREATED_BY = par.CREATED_BY,
                    ROW_STATUS = fn.fg.IsActive
                };

                _ctx.SBH_TM_USER_PROFILE_ADMIN.Add(b);
                _ctx.SaveChanges();

                res = new object[] { true, fnn.fg.Save };
            }
            catch (Exception ex)
            {
                res = new object[] { false, ex.Message };
            }
            return res;
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<SBH_TM_GROUP> ddlGroup()
        {
            try
            {
                List<SBH_TM_GROUP> lA = _ctx.SBH_TM_GROUP.Where(d => d.ROW_STATUS == fn.fg.IsActive && d.ID != 4 && d.ID != 5).ToList();
                return lA;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<SBH_TM_GENDER> ddlGender()
        {
            try
            {
                List<SBH_TM_GENDER> lA = _ctx.SBH_TM_GENDER.Where(d => d.ROW_STATUS == fn.fg.IsActive).ToList();
                return lA;
            }
            catch (Exception ex)
            {
                throw null;
            }
        }

        public bool Delete(int id)
        {
            bool res = false;
            try
            {
                SBH_TM_USER_ADMIN a = _ctx.SBH_TM_USER_ADMIN.Find(id);
                a.ROW_STATUS = fn.fg.NotActive;
                _ctx.Entry(a).State = System.Data.Entity.EntityState.Modified;
                res = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return res;
        }

        public object[] Edit(int id, Register par)
        {
            object[] res = null;
            try
            {
                if (par.ConfirmPassword != par.Password)
                    throw new Exception("password");
                if (IsValidEmail(par.Email) == false)
                    throw new Exception("email");

                SBH_TM_USER_ADMIN a = _ctx.SBH_TM_USER_ADMIN.Find(id);
                SBH_TM_USER_PROFILE_ADMIN b = _ctx.SBH_TM_USER_PROFILE_ADMIN.Find(id);
                if (a != null && b != null)
                {

                    if (par.ID_GROUP != 0)
                        a.ID_GROUP = par.ID_GROUP;
                    a.USER_MAIL = par.Email;
                    a.USER_NAME = par.Name;
                    if (!string.IsNullOrWhiteSpace(par.Password) || !string.IsNullOrEmpty(par.Password))
                        a.PASSWORD = par.Password;
                    a.IS_SUPER_ADMIN = par.IsSuperAdmin;
                    a.ROW_STATUS = fn.fg.IsActive;
                    a.LAST_MODIFIED_TIME = DateTime.Now;
                    a.LAST_MODIFIED_BY = par.LAST_MODIFIED_BY;

                    _ctx.Entry(a).State = System.Data.Entity.EntityState.Modified;
                    _ctx.SaveChanges();

                    b.GENDER = par.Gender;
                    b.BORN = par.Born;
                    b.ADDRESS = par.Address;
                    b.DESCRIPTION = par.OtherDescription;
                    b.JOB = par.Job;
                    b.COMPANY = par.Company;
                    b.HOBBY = par.Hobby;
                    b.LAST_MODIFIED_TIME = DateTime.Now;
                    b.LAST_MODIFIED_BY = par.LAST_MODIFIED_BY;

                    _ctx.Entry(b).State = System.Data.Entity.EntityState.Modified;
                    _ctx.SaveChanges();

                    res = new object[] { true, fnn.fg.Save };
                }
            }
            catch (Exception ex)
            {
                res = new object[] { false, ex.Message };
            }
            return res;
        }

        public List<UserAdmin> GridBind()
        {
            try
            {
                List<UserAdmin> lA = new List<UserAdmin>();
                foreach (var item in _ctx.SBH_TM_USER_ADMIN.Where(x => x.ROW_STATUS == fn.fg.IsActive))
                {
                    UserAdmin oA = new UserAdmin();
                    oA.ID = item.ID;
                    oA.ID_USER_ADMIN = item.ID_USER_ADMIN;
                    oA.USER_MAIL = item.USER_MAIL;
                    oA.USER_NAME = item.USER_NAME;
                    oA.LAST_LOGIN = item.LAST_LOGIN;
                    oA.PASSWORD = item.PASSWORD;
                    oA.CREATED_TIME = item.CREATED_TIME;
                    oA.CREATED_BY = item.CREATED_BY;
                    oA.LAST_MODIFIED_TIME = item.LAST_MODIFIED_TIME;
                    oA.LAST_MODIFIED_BY = item.LAST_MODIFIED_BY;
                    oA.ROW_STATUS = item.ROW_STATUS;

                    lA.Add(oA);
                }
                return lA;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string GetPwd(int id)
        {
            string pwd = string.Empty;
            try
            {
                SBH_TM_USER_ADMIN a = _ctx.SBH_TM_USER_ADMIN.Where(x => x.ROW_STATUS == fn.fg.IsActive && x.ID == id).FirstOrDefault();
                pwd = a.PASSWORD;
            }
            catch (Exception ex)
            {
                throw;
            }
            return pwd;
        }

        public Login UserLogin(Login par)
        {
            try
            {
                Login oA = new Login();
                SBH_TM_USER_ADMIN oB = _ctx.SBH_TM_USER_ADMIN.Where(d => d.ROW_STATUS == fn.fg.IsActive && d.USER_MAIL == par.Email && d.PASSWORD == par.Password).FirstOrDefault();
                if (oB != null)
                {
                    oA.UserId = oB.ID_USER_ADMIN;
                    oA.UserName = oB.USER_NAME;
                    oA.Id = oB.ID;
                    oA.IdGroup = int.Parse(oB.ID_GROUP.ToString());
                    oA.IsSuperAdmin = oB.IS_SUPER_ADMIN;
                    return oA;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Register Retrived(int id)
        {
            int? ans = 0, que = 0, aq = 0;
            try
            {
                Register oA = new Register();
                var x = from a in _ctx.SBH_TM_USER_ADMIN
                        join b in _ctx.SBH_TM_USER_PROFILE_ADMIN on a.ID_USER_ADMIN equals b.ID_USER_ADMIN.ToString()
                        where a.ROW_STATUS == fn.fg.IsActive && a.ID == id
                        select new
                        {
                            a.ID,
                            a.ID_GROUP,
                            a.ID_USER_ADMIN,
                            a.USER_MAIL,
                            a.USER_NAME,
                            a.IS_SUPER_ADMIN,
                            a.LAST_LOGIN,
                            a.PASSWORD,
                            b.PHOTO_PATH,
                            b.GENDER,
                            b.BORN,
                            b.ADDRESS,
                            b.DESCRIPTION,
                            b.JOB,
                            b.COMPANY,
                            b.HOBBY,
                            a.MOST_ACT_ANSWER,
                            a.MOST_ACT_QUESTIONS
                        };
                foreach (var item in x.ToList())
                {
                    oA.Id = item.ID;
                    oA.Email = item.USER_MAIL;
                    oA.Name = item.USER_NAME;
                    oA.Born = item.BORN;
                    oA.Gender = item.GENDER;
                    oA.Address = item.ADDRESS;
                    oA.Job = item.JOB;
                    oA.Company = item.COMPANY;
                    oA.Hobby = item.HOBBY;
                    oA.OtherDescription = item.DESCRIPTION;
                    oA.ID_GROUP = int.Parse(item.ID_GROUP.ToString());
                    oA.IsSuperAdmin = item.IS_SUPER_ADMIN;
                    oA.MOST_ACT_ANSWER = item.MOST_ACT_ANSWER;
                    oA.MOST_ACT_QUESTIONS = item.MOST_ACT_QUESTIONS;
                    oA.PasswordOld = item.PASSWORD;
                }

                if (!string.IsNullOrWhiteSpace(oA.MOST_ACT_ANSWER.ToString()))
                    ans = oA.MOST_ACT_ANSWER;
                if (!string.IsNullOrWhiteSpace(oA.MOST_ACT_QUESTIONS.ToString()))
                    que = oA.MOST_ACT_QUESTIONS;

                MostAct act = _ctx.MostAct.Where(s => s.MOST_ACT_ANSWER == ans && s.MOST_ACT_QUESTIONS == que).FirstOrDefault();
                oA.DESCR = act.DESCR;
                oA.START_COUNT = act.START_COUNT;

                if (oA != null)
                    return oA;
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
                throw new Exception(ex.Message);
            }
        }

        public ResultStatus ChangePassword(int id, string oldPassword, string newPassword)
        {
            ResultStatus rs = new ResultStatus();
            try
            {
                SBH_TM_USER_ADMIN user = _ctx.SBH_TM_USER_ADMIN.Find(id);

                if (user.PASSWORD == oldPassword)
                {
                    user.LAST_MODIFIED_TIME = DateTime.Now;
                    user.LAST_MODIFIED_BY = user.USER_NAME;
                    user.PASSWORD = newPassword;

                    _ctx.Entry(user).State = EntityState.Modified;
                    _ctx.SaveChanges();
                    rs.SetSuccessStatus("Change password has been success");
                }
                else if (user.PASSWORD == newPassword)
                {
                    rs.SetErrorStatus("New password can not be same old password");
                }
                else
                {
                    rs.SetErrorStatus("Old password is not match");
                }

            }
            catch (Exception ex)
            {
                rs.SetErrorStatus(ex.Message);
            }

            return rs;
        }

    }
}
