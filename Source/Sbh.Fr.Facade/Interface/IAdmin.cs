using Sbh.Fr.CommonFunction;
using Sbh.Fr.Model.Custom;
using Sbh.Fr.Model.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbh.Fr.Facade.Interface
{
    public interface IAdmin
    {
        List<UserAdmin> GridBind();
        Login UserLogin(Login par);
        Register Retrived(int id);
        object[] Add(Register par);
        object[] Edit(int id, Register par);
        bool Delete(int id);
        IEnumerable<SBH_TM_GENDER> ddlGender();
        IEnumerable<SBH_TM_GROUP> ddlGroup();
        string GetPwd(int id);
        ResultStatus ChangePassword(int id, string oldPassword, string newPassword);
    }
}
