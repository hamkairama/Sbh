using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbh.Fr.Model.Custom
{
    public class QuestionAndAnswerCustoms
    {
        public Int64 Id { get; set; }

        public int IdQuestions { get; set; }

        public int? IdCategory { get; set; }

        [StringLength(50)]
        public string CategoryDesc { get; set; }

        public int? IdUserQuestions { get; set; }

        [StringLength(50)]
        public string QuestionsName { get; set; }

        [Column(TypeName = "text")]
        public string Questions { get; set; }

        [Column(TypeName = "text")]
        public string Answer { get; set; }

        public int? IdUserAnswer { get; set; }

        [StringLength(50)]
        public string AnswerName { get; set; }

        public int IdQuestionsAnswer { get; set; }

        [StringLength(100)]
        public string TitleQuestions { get; set; }

        public string SumComment { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime? DateQustion { get; set; }
        public DateTime? DateAnswer { get; set; }
        public int? MostComment { get; set; }
    }
}
