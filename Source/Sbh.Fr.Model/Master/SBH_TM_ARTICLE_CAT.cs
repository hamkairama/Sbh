namespace Sbh.Fr.Model.Master
{
    using ClsGlobal;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using Transaksi;

    public partial class SBH_TM_ARTICLE_CAT: BaseClass
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SBH_TM_ARTICLE_CAT()
        {
            SBH_TR_ARTICLE = new HashSet<SBH_TR_ARTICLE>();
        }

        public int ID { get; set; }

        [StringLength(100)]
        public string ARTICLE_CAT_DESC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SBH_TR_ARTICLE> SBH_TR_ARTICLE { get; set; }
    }
}
