using Sbh.Fr.CommonFunction;
using Sbh.Fr.Model;
using Sbh.Fr.Model.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Sbh.Fr.Facade.Interface
{
   public interface IGaleryPhoto
    {
        List<SBH_TM_GALERY_FOTO> GridBind();
        List<SBH_TM_GALERY_FOTO> GridBindTop5();
        SBH_TM_GALERY_FOTO Retrieve(int id);
        ResultStatus Add(SBH_TM_GALERY_FOTO galeryPhoto);
        ResultStatus AddAll(SBH_TM_GALERY_FOTO galeryPhoto, List<string> listString);
        ResultStatus Edit(SBH_TM_GALERY_FOTO galeryPhoto);
        ResultStatus Delete(int id, string modifiedBy, DateTime modifiedTime);
        List<SBH_TM_GALERY_FOTO> GetGaleryByUserId(int userId);
        List<SBH_TM_GALERY_FOTO> GetGaleryByUserIdAndEventTitle(int userId, string eventTitle);
        SelectList GetUserList();
        SelectList GetNewsList();
    }
}
