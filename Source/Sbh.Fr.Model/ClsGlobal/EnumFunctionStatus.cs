using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbh.Fr.Model.ClsGlobal
{
    public class EnumFunctionStatus
    {
        public string Save { get; set; }
        public string Edit { get; set; }
        public string Delete { get; set; }

        public string DataNf { get; set; }
        public string DataIsntValid { get; set; }

        public string SFailed { get; set; }
        public string EFailed { get; set; }
        public string DFailed { get; set; }
    }

    public class EnumFuncStatus
    {
        public EnumFuncStatus()
        {
            fg = new EnumFunctionStatus()
            {
                Save = "Save Data Successfully.",
                Edit = "Edit Data Successfully.",
                Delete = "Delete Data Successfully.",
                DataNf = "Data not found!",
                DataIsntValid = "Invalid data!",
                SFailed = "Save Data Failed!",
                EFailed = "Edit Data Failed!",
                DFailed = "Delete Data Failed!"
            };
        }
        public EnumFunctionStatus fg { get; set; }
    }

    public class EnumRowStatus
    {
        public int IsActive { get; set; }
        public int NotActive { get; set; }
    }

    public class EnumStatus
    {
        public EnumStatus()
        {
            fg = new EnumRowStatus()
            {
                IsActive = 0,
                NotActive = -1
            };
        }

        public EnumRowStatus fg { get; set; }
    }
}