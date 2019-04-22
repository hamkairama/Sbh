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
    public interface ISlideshow
    {
        List<SBH_TM_SLIDESHOW> GridBind();
        SBH_TM_SLIDESHOW Retrieve(int id);
        ResultStatus Add(SBH_TM_SLIDESHOW slideshow);
        ResultStatus Edit(SBH_TM_SLIDESHOW slideshow);
        ResultStatus Delete(int id, string modifiedBy, DateTime modifiedTime);
    }
}
