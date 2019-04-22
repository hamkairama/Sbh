namespace Sbh.Fr.Model.Transaksi
{
    using ClsGlobal;
    using Master;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SBH_TR_ARTICLE : BaseClass
    {
        public int ID { get; set; }

        public int? ID_USER_ADMIN { get; set; }

        public int? ID_ARTICLE_CAT { get; set; }

        [Column(TypeName = "text")]
        public string ARTICLE { get; set; }

        public virtual SBH_TM_ARTICLE_CAT SBH_TM_ARTICLE_CAT { get; set; }

        public virtual SBH_TM_USER_ADMIN SBH_TM_USER_ADMIN { get; set; }
    }
}
