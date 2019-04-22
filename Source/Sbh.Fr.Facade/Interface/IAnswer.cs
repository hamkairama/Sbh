using Sbh.Fr.Model.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbh.Fr.Facade.Interface
{
    public interface IAnswer
    {
        List<TaskListUserCustoms> GridBind(int id);
        List<QuestionAndAnswerCustoms> GridBindAll(int id);
        Answer Retrived(int id);
        bool Add(Answer ans);
        bool Edit(int id, Answer ans);
        bool Delete(int id);
    }
}
