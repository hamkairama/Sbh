using Sbh.Fr.Model.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbh.Fr.Facade.Interface
{
    public interface IQuestions
    {
        List<Questions> GridBind();
        Questions Retrived(int id);
        object[] Add(Questions par);
        bool Edit(int id, Questions par);
        bool Delete(int id);
    }
}
