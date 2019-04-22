using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbh.Fr.Model.View
{
    [Table("TaskListUser")]
    public partial class TaskListUser
    {
        public int ID { get; set; }
        public int ID_USER_TAGGING { get; set; }
        public string CATEGORY_DESC { get; set; }
        public string USER_NAME { get; set; }
        public string USER_MAIL { get; set; }
        public string TITLE_QUESTIONS { get; set; }

        [Column(TypeName = "text")]
        public string QUESTIONS { get; set; }
        public string CREATED_TIME { get; set; }
        public string CREATED_BY { get; set; }
    }
}
