using Sbh.Fr.Model.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbh.Fr.Facade.Interface
{
   public interface IContactUs
    {
        List<ContactUs> GridBind();
        ContactUs Retrived(int id);
        bool Add(ContactUs par);
        bool Edit(int id, ContactUs par);
        bool Delete(int id);
    }
}
