using Sbh.Fr.Model.ClsGlobal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbh.Fr.Model.Master
{
    public class SBH_TM_GENDER : BaseClass
    {
        public string GENDER_ID { get; set; }
        public string GENDER_DESC { get; set; }
    }
}
