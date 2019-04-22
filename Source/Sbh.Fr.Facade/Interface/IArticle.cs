using Sbh.Fr.Model.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbh.Fr.Facade.Interface
{
   public interface IArticle
    {
        List<Article> GridBind();
        Article Retrived(int id);
        bool Add(Article art);
        bool Edit(int id, Article art);
        bool Delete(int id);
    }
}
