using Sbh.Fr.Model.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbh.Fr.Facade.Interface
{
    public interface IMostActivity
    {
        List<MostActivity> GridBind();
        MostActivity Retrived(int id);
        bool Add(MostActivity par);
        bool Edit(int id, MostActivity par);
        bool Delete(int id, string userName);
    }
}
