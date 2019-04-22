using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbh.Fr.Model.View
{
    [Table("MostAct")]
    public class MostAct
    {
        [Key]
        public Int64 ID { get; set; }
        public int MOST_ACT_QUESTIONS { get; set; }
        public int MOST_ACT_ANSWER { get; set; }
        public string DESCR { get; set; }
        public int START_COUNT { get; set; }  
    }
}
