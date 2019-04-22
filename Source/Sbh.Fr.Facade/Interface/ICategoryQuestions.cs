using Sbh.Fr.Model.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sbh.Fr.Model.Master;

namespace Sbh.Fr.Facade.Interface
{
    public interface ICategoryQuestions
    {
        List<CategoryQuestions> GridBind();
        CategoryQuestions Retrived(int id);
        bool Add(CategoryQuestions par);
        bool Edit(int id, CategoryQuestions par);
        bool Delete(int id, string userName);
        IEnumerable<SBH_TM_CATEGORY_QUESTIONS> ddlCatQuestion();
    }
}
