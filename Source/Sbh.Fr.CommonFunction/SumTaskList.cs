using Sbh.Fr.Model.DbCtx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbh.Fr.CommonFunction
{
    public class SumTaskList
    {
        private DbConn _ctx = new DbConn();

        public SumTaskList()
        {
            _ctx = new DbConn();
        }

        public string SumData(int id)
        {
            string res = string.Empty;
            var item = _ctx.TaskListUser.Where(x => x.ID_USER_TAGGING == id).ToList();
            res = item.Count().ToString();
            return res;
        }
    }
}
