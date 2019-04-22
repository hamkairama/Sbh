using Sbh.Fr.Model.ClsGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbh.Fr.Model.Transaksi
{
    public class SBH_TR_QUESTIONS_TAGGING: BaseClass
    {
        public int ID { get; set; }
        public int ID_QUESTIONS { get; set; }
        public int ID_USER_TAGGING { get; set; }
        public int ANSWER_STATUS { get; set; }
    }
}
