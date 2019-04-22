using Sbh.Fr.Model.ClsGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbh.Fr.Model.Custom
{
    public class QuestionsTagging : BaseClassClient
    {
        public int Id { get; set; }
        public int IdQuestions { get; set; }
        public int IdUserTagging { get; set; }
        public int AnswerStatus { get; set; }
    }
}
