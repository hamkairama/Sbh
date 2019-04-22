using Sbh.Fr.Model.ClsGlobal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbh.Fr.Model.Custom
{
   public class MostComment : BaseClassClient
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string DESCR { get; set; }

        public int START_COUNT { get; set; }

        public int BEGIN_MOST_COUNT { get; set; }

        public int END_MOST_COUNT { get; set; }
    }
}
