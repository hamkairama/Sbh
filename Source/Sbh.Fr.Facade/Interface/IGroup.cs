using Sbh.Fr.Model.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbh.Fr.Facade.Interface
{
   public interface IGroup
    {
        List<Group> GridBind();
        Group Retrived(int id);
        bool Add(Group par);
        bool Edit(int id, Group par);
        bool Delete(int id, string userName);
    }
}
