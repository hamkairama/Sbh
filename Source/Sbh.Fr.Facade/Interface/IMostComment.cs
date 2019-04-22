using Sbh.Fr.Model.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbh.Fr.Facade.Interface
{
    public interface IMostComment
    {
        List<MostComment> GridBind();
        MostComment Retrived(int id);
        bool Add(MostComment par);
        bool Edit(int id, MostComment par);
        bool Delete(int id, string userName);
    }
}
