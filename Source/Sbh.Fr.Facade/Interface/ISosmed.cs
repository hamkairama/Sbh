using Sbh.Fr.CommonFunction;
using Sbh.Fr.Model.Custom;
using Sbh.Fr.Model.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbh.Fr.Facade.Interface
{
    public interface ISosmed
    {
        List<SBH_TM_SOSMED> GridBind();
        SBH_TM_SOSMED Retrived(int id);
        ResultStatus Add(SBH_TM_SOSMED par);
        ResultStatus Edit(int id, SBH_TM_SOSMED par);
        ResultStatus Delete(int id);
        List<SBH_TM_SOSMED> RetrivedBannerSelected();
    }
}
