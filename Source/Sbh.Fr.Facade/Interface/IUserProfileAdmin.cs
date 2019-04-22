using Sbh.Fr.Model.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbh.Fr.Facade.Interface
{
    public interface IUserProfileAdmin
    {
        List<UserProfileAdmin> GridBind();
        UserProfileAdmin Retrived(int id);
        bool Add(UserProfileAdmin par);
        bool Edit(int id, UserProfileAdmin par);
        bool Delete(int id);
    }
}
