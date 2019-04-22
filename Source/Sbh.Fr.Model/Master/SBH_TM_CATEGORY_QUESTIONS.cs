namespace Sbh.Fr.Model.Master
{
    using ClsGlobal;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using Transaksi;

    public partial class SBH_TM_CATEGORY_QUESTIONS : BaseClass
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SBH_TM_CATEGORY_QUESTIONS()
        {
            SBH_TR_QUESTIONS = new HashSet<SBH_TR_QUESTIONS>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string CATEGORY_DESC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SBH_TR_QUESTIONS> SBH_TR_QUESTIONS { get; set; }
        
    }
}
