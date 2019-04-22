using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbh.Fr.Model.View
{
    [Table("QuestionAndAnswer")]
    public partial class QuestionAndAnswer
    {
        [Key]
        public Int64 ID { get; set; }

        public int ID_QUESTIONS { get; set; }

        public int? ID_CATEGORY { get; set; }

        [StringLength(50)]
        public string CATEGORY_DESC { get; set; }

        public int? ID_USER_QUESTIONS { get; set; }

        [StringLength(50)]
        public string QUESTIONS_NAME { get; set; }

        [Column(TypeName = "text")]
        public string QUESTIONS { get; set; }

        [Column(TypeName = "text")]
        public string ANSWER { get; set; }

        public int? ID_USER_ANSWER { get; set; }

        [StringLength(50)]
        public string ANSWER_NAME { get; set; }

        public int ID_QUESTIONS_ANSWER { get; set; }

        public DateTime? DATE_QUESTION { get; set; }
        public DateTime? DATE_ANSWER { get; set; }

        [StringLength(100)]
        public string TITLE_QUESTIONS { get; set; }

        public string SumComment { get; set; }

        public int? MOST_COMMENT { get; set; }
    }
}
