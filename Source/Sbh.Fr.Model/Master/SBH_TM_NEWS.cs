namespace Sbh.Fr.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SBH_TM_NEWS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SBH_TM_NEWS()
        {
            SBH_TM_GALERY_FOTO = new HashSet<SBH_TM_GALERY_FOTO>();
        }
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string TITLE { get; set; }

        [StringLength(500)]
        public string DESCRIPTION { get; set; }

        public int CATEGORY_ID { get; set; }

        public string FILE_IMAGE1 { get; set; }

        public string FILE_IMAGE2 { get; set; }
        public string FILE_IMAGE3 { get; set; }
        public string FILE_IMAGE4 { get; set; }

        public string TEMPLATE { get; set; }

        public DateTime CREATED_TIME { get; set; }

        [Required]
        [StringLength(50)]
        public string CREATED_BY { get; set; }

        public DateTime? LAST_MODIFIED_TIME { get; set; }

        [StringLength(50)]
        public string LAST_MODIFIED_BY { get; set; }

        public int ROW_STATUS { get; set; }

        public virtual SBH_TM_CATEGORY SBH_TM_CATEGORY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SBH_TM_GALERY_FOTO> SBH_TM_GALERY_FOTO { get; set; }

    }
}
