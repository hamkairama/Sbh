namespace Sbh.Fr.Model.Custom
{
    using ClsGlobal;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Group : BaseClass
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string GROUP_DESC { get; set; }
    }
}
