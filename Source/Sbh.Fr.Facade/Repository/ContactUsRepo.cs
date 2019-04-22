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

namespace Sbh.Fr.Facade.Repository
{
    public class ContactUsRepo : IContactUs
    {
        private EnumStatus fn = new EnumStatus();
        private DbConn _ctx = new DbConn();

        public ContactUsRepo()
        {
            _ctx = new DbConn();
        }

        public bool Add(ContactUs par)
        {
            bool res = false;
            try
            {
                SBH_TM_CONTACT_US a = new SBH_TM_CONTACT_US()
                {
                    ID = par.ID,
                    NAME_SENDER = par.NAME_SENDER,
                    EMAIL_SENDER = par.EMAIL_SENDER,
                    PHONE_SENDER = par.PHONE_SENDER,
                    DESCRIPTION = par.DESCRIPTION,

                    CREATED_TIME = DateTime.Now,
                    CREATED_BY = "System",
                    ROW_STATUS = fn.fg.IsActive
                };
                _ctx.SBH_TM_CONTACT_US.Add(a);
                _ctx.SaveChanges();

                res = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return res;
        }

        public bool Delete(int id)
        {
            bool res = false;
            try
            {
                SBH_TM_CONTACT_US a = _ctx.SBH_TM_CONTACT_US.Find(id);
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

        public bool Edit(int id, ContactUs par)
        {
            bool res = false;
            try
            {
                SBH_TM_CONTACT_US a = _ctx.SBH_TM_CONTACT_US.Find(id);
                if (a != null)
                {
                    a.ID = par.ID;
                    a.NAME_SENDER = par.NAME_SENDER;
                    a.EMAIL_SENDER = par.EMAIL_SENDER;
                    a.PHONE_SENDER = par.PHONE_SENDER;
                    a.DESCRIPTION = par.DESCRIPTION;

                    a.LAST_MODIFIED_TIME = DateTime.Now;
                    a.LAST_MODIFIED_BY = "System";

                    _ctx.Entry(a).State = System.Data.Entity.EntityState.Modified;
                    _ctx.SaveChanges();

                    res = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return res;
        }

        public List<ContactUs> GridBind()
        {
            try
            {
                List<ContactUs> lA = new List<ContactUs>();
                foreach (var item in _ctx.SBH_TM_CONTACT_US
                    .Where(x => x.ROW_STATUS == fn.fg.IsActive))
                {
                    ContactUs oA = new ContactUs();
                    oA.ID = item.ID;
                    oA.NAME_SENDER = item.NAME_SENDER;
                    oA.EMAIL_SENDER = item.EMAIL_SENDER;
                    oA.PHONE_SENDER = item.PHONE_SENDER;
                    oA.DESCRIPTION = item.DESCRIPTION;

                    //oA.CREATED_TIME = item.CREATED_TIME;
                    //oA.CREATED_BY = item.CREATED_BY;
                    //oA.LAST_MODIFIED_TIME = item.LAST_MODIFIED_TIME;
                    //oA.LAST_MODIFIED_BY = item.LAST_MODIFIED_BY;
                    //oA.ROW_STATUS = item.ROW_STATUS;

                    lA.Add(oA);
                }
                return lA;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ContactUs Retrived(int id)
        {
            try
            {
                ContactUs oA = new ContactUs();
                SBH_TM_CONTACT_US oB = _ctx.SBH_TM_CONTACT_US
                    .Where(x => x.ROW_STATUS == fn.fg.IsActive && x.ID == id).FirstOrDefault();
                if (oB != null)
                {
                    oA.ID = oB.ID;
                    oA.NAME_SENDER = oB.NAME_SENDER;
                    oA.EMAIL_SENDER = oB.EMAIL_SENDER;
                    oA.PHONE_SENDER = oB.PHONE_SENDER;
                    oA.DESCRIPTION = oB.DESCRIPTION;

                    //oA.CREATED_TIME = oB.CREATED_TIME;
                    //oA.CREATED_BY = oB.CREATED_BY;
                    //oA.LAST_MODIFIED_TIME = oB.LAST_MODIFIED_TIME;
                    //oA.LAST_MODIFIED_BY = oB.LAST_MODIFIED_BY;
                    //oA.ROW_STATUS = oB.ROW_STATUS;

                    return oA;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
                throw new Exception(ex.Message);
            }
        }
    }
}
