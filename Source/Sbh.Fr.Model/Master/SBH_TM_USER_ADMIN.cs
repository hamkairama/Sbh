namespace Sbh.Fr.Model.Master
{
    using ClsGlobal;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using Transaksi;

    public partial class SBH_TM_USER_ADMIN : BaseClass
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SBH_TM_USER_ADMIN()
        {
            SBH_TR_ANSWER = new HashSet<SBH_TR_ANSWER>();
            SBH_TR_ARTICLE = new HashSet<SBH_TR_ARTICLE>();
            SBH_TR_QUESTIONS = new HashSet<SBH_TR_QUESTIONS>();
            //SBH_TM_GALERY_FOTO = new HashSet<SBH_TM_GALERY_FOTO>();
        }

        public int ID { get; set; }

        public int? ID_GROUP { get; set; }

        [Required]
        [StringLength(50)]
        public string ID_USER_ADMIN { get; set; }

        [Required]
        [StringLength(100)]
        public string USER_MAIL { get; set; }

        [Required]
        [StringLength(50)]
        public string USER_NAME { get; set; }

        public bool IS_SUPER_ADMIN { get; set; }

        public DateTime? LAST_LOGIN { get; set; }

        [StringLength(50)]
        public string PASSWORD { get; set; }

        public int? MOST_ACT_ANSWER { get; set; }
        public DateTime? MOST_ACT_ANSWER_DATE { get; set; }
        public int? MOST_ACT_QUESTIONS { get; set; }
        public DateTime? MOST_ACT_QUESTIONS_DATE { get; set; }

        public virtual SBH_TM_GROUP SBH_TM_GROUP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SBH_TR_ANSWER> SBH_TR_ANSWER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SBH_TR_ARTICLE> SBH_TR_ARTICLE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SBH_TR_QUESTIONS> SBH_TR_QUESTIONS { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<SBH_TM_GALERY_FOTO> SBH_TM_GALERY_FOTO { get; set; }
    }
}
