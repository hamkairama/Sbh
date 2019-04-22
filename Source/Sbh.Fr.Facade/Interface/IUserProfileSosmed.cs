using Sbh.Fr.Model.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbh.Fr.Facade.Interface
{
    public interface IUserProfileSosmed
    {
        List<UserProfileSosmed> GridBind();
        UserProfileSosmed Retrived(int id);
        bool Add(UserProfileSosmed par);
        bool Edit(int id, UserProfileSosmed par);
        bool Delete(int id);
    }
}
