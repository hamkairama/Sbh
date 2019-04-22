using Sbh.Fr.CommonFunction;
using Sbh.Fr.Model;
using Sbh.Fr.Model.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbh.Fr.Facade.Interface
{
    public interface ICategory
    {
        List<SBH_TM_CATEGORY> GridBind();
        SBH_TM_CATEGORY Retrieve(int id);
        ResultStatus Add(SBH_TM_CATEGORY category);
        ResultStatus Edit(SBH_TM_CATEGORY category);
        ResultStatus Delete(int id, string modifiedBy, DateTime modifiedTime);
    }
}
