using Sbh.Fr.Model.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbh.Fr.Facade.Interface
{
    public interface IUserProfile
    {
        List<UserProfile> GridBind();
        UserProfile Retrived(int id);
        bool Add(UserProfile par);
        bool Edit(int id, UserProfile par);
        bool Delete(int id);
    }
}
