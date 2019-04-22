using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbh.Fr.Model.ClsGlobal
{
    public class BaseClassClient
    {
        public DateTime CREATED_TIME { get; set; }
        [StringLength(50)]
        public string CREATED_BY { get; set; }
        public DateTime? LAST_MODIFIED_TIME { get; set; }
        [StringLength(50)]
        public string LAST_MODIFIED_BY { get; set; }
        public int ROW_STATUS { get; set; }
    }
}
