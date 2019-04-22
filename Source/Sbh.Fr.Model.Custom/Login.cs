using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbh.Fr.Model.Custom
{
    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int Id { get; set; }
        public int IdGroup { get; set; }
        public bool IsSuperAdmin { get; set; }
    }
}
