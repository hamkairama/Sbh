using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbh.Fr.CommonFunction
{
    public class EnumList
    {
        public enum IHttpMethod
        {
            Post = 0,
            Get = 1,
            Put = 2,
        }

        public enum RowStatus
        {
            InActive = -1,
            Active = 0,
        }

        public enum BookingStatus
        {
            Rejected = -1,
            Submitted = 0,
            Uploaded = 1,
            Completed = 2,
        }
    }
}
