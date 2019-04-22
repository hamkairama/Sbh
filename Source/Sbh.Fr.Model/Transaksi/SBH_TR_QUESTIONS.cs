namespace Sbh.Fr.Model.Transaksi
{
    using ClsGlobal;
    using Master;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SBH_TR_QUESTIONS : BaseClass
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SBH_TR_QUESTIONS()
        {
            SBH_TR_ANSWER = new HashSet<SBH_TR_ANSWER>();
        }

        public int ID { get; set; }

        public int? ID_CATEGORY { get; set; }

        public int? ID_USER { get; set; }

        [Column(TypeName = "text")]
        public string QUESTIONS { get; set; }

        public int MOST_COMMENT { get; set; }

        public DateTime? MOST_COMMENT_DATE { get; set; }

        [StringLength(100)]
        public string TITLE_QUESTIONS { get; set; }

        public int MAXID { get; set; }

        public virtual SBH_TM_CATEGORY_QUESTIONS SBH_TM_CATEGORY_QUESTIONS { get; set; }

        //public virtual SBH_TM_USER SBH_TM_USER { get; set; }
        public virtual SBH_TM_USER_ADMIN SBH_TM_USER_ADMIN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SBH_TR_ANSWER> SBH_TR_ANSWER { get; set; }
    }
}
