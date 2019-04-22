using Sbh.Fr.Model.Custom;
using Sbh.Fr.Model.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbh.Fr.Facade.Interface
{
    public interface IListUser
    {
        List<ListUserGroup> GridBind(int id);
        List<ListUserGroup> GridBindAll(string flag);
        bool Add(object[] id, int qid, string user);
    }
}
