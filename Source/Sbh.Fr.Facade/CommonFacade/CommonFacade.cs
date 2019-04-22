using Sbh.Fr.Facade.Interface;
using Sbh.Fr.Facade.Repository;
using Sbh.Fr.Model.Custom;
using Sbh.Fr.Model.Master;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Sbh.Fr.Facade.CommonFacade
{
    public class CommonFacade
    {
        ISosmed repo;
        public CommonFacade()
        {
            repo = new SosmedRepo();
        }
        public List<SBH_TM_SOSMED> RetrivedBannerSelected()
        {
            List<SBH_TM_SOSMED> sosmedRes = new List<SBH_TM_SOSMED>();

            sosmedRes = repo.RetrivedBannerSelected();
            return sosmedRes;
        }

    }

}
