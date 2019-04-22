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
   public interface INews
    {
        List<SBH_TM_NEWS> GridBind();
        List<SBH_TM_NEWS> GridBindTop5();
        SBH_TM_NEWS Retrieve(int id);
        ResultStatus Add(SBH_TM_NEWS subCategory);
        ResultStatus Edit(SBH_TM_NEWS subCategory);
        ResultStatus Delete(int id, string modifiedBy, DateTime modifiedTime);
        List<SBH_TM_NEWS> GetnewsByCategoryId(int categoryId);
        SelectList GetCategoryList();
    }
}
