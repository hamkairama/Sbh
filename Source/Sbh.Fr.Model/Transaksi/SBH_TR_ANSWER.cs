namespace Sbh.Fr.Model.Transaksi
{
    using ClsGlobal;
    using Master;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SBH_TR_ANSWER : BaseClass
    {
        public int ID { get; set; }

        public int? ID_QUESTIONS { get; set; }

        public int? ID_USER_ADMIN { get; set; }

        [Column(TypeName = "text")]
        public string ANSWER { get; set; }

        public virtual SBH_TM_USER_ADMIN SBH_TM_USER_ADMIN { get; set; }

        public virtual SBH_TR_QUESTIONS SBH_TR_QUESTIONS { get; set; }
    }
}
