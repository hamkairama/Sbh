using Sbh.Fr.Model.ClsGlobal;
using Sbh.Fr.Model.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbh.Fr.Facade.Interface
{
    public interface IArticleCat
    {
        List<ArticleCat> GridBind();
        ArticleCat Retrived(int id);
        bool Add(ArticleCat art);
        bool Edit(int id, ArticleCat art);
        bool Delete(int id);
    }
}
