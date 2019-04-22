using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbh.Fr.Model.View
{
    [Table("ListUser")]
    public class ListUser
    {
        [Key]
        public int ID { get; set; }
        public int ID_GROUP { get; set; }
        public string GROUP_DESC { get; set; }
        public string USER_MAIL { get; set; }
        public string USER_NAME { get; set; }
        public char GENDER { get; set; }
        public string GENDER_DESC { get; set; }
        public string BORN { get; set; }
        public string ADDRESS { get; set; }
        public string DESCRIPTION { get; set; }
        public string JOB { get; set; }
        public string COMPANY { get; set; }
        public string HOBBY { get; set; }
    }
}
