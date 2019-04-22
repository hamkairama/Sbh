using Sbh.Fr.Facade.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sbh.Fr.Model.View;
using Sbh.Fr.Model.ClsGlobal;
using Sbh.Fr.Model.DbCtx;
using Sbh.Fr.Model.Custom;
using Sbh.Fr.Model.Transaksi;

namespace Sbh.Fr.Facade.Repository
{
    public class ListUserRepo : IListUser
    {
        private EnumStatus fn = new EnumStatus();
        private DbConn _ctx = new DbConn();

        public ListUserRepo()
        {
            _ctx = new DbConn();
        }

        public List<ListUserGroup> GridBindAll(string flag)
        {
            try
            {
                List<ListUserGroup> l = new List<ListUserGroup>();
                var lu = _ctx.ListUser.Where(x => x.ID_GROUP != 4 || x.ID_GROUP != 5).ToList();

                if (flag.ToLower() == "listuser")
                    lu = _ctx.ListUser.ToList();

                foreach (var item in lu)
                {
                    ListUserGroup o = new ListUserGroup();
                    o.ID = item.ID;
                    o.ID_GROUP = item.ID_GROUP;
                    o.GROUP_DESC = item.GROUP_DESC;
                    o.USER_MAIL = item.USER_MAIL;
                    o.USER_NAME = item.USER_NAME;
                    o.GENDER = item.GENDER;
                    o.GENDER_DESC = item.GENDER_DESC;
                    o.BORN = item.BORN;
                    o.ADDRESS = item.ADDRESS;
                    o.DESCRIPTION = item.DESCRIPTION;
                    o.JOB = item.JOB;
                    o.COMPANY = item.COMPANY;
                    o.HOBBY = item.HOBBY;

                    l.Add(o);
                }
                return l;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public List<ListUserGroup> GridBind(int id)
        {
            throw new NotImplementedException();
        }

        public bool Add(object[] id, int qid, string user)
        {
            bool res = false;
            try
            {
                foreach (var item in id)
                {
                    SBH_TR_QUESTIONS_TAGGING a = new SBH_TR_QUESTIONS_TAGGING();
                    a.ID_QUESTIONS = qid;
                    a.ID_USER_TAGGING = int.Parse(item.ToString());
                    a.ANSWER_STATUS = fn.fg.NotActive;
                    a.CREATED_BY = user;
                    a.CREATED_TIME = DateTime.Now;
                    a.ROW_STATUS = fn.fg.IsActive;

                    _ctx.SBH_TR_QUESTIONS_TAGGING.Add(a);
                    _ctx.SaveChanges();
                }
                res = true;
            }
            catch (Exception ex)
            {
                throw;
            }
            return res;
        }
    }
}
