namespace Sbh.Fr.Model.Master
{
    using ClsGlobal;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SBH_TM_GROUP : BaseClass
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SBH_TM_GROUP()
        {
            SBH_TM_USER_ADMIN = new HashSet<SBH_TM_USER_ADMIN>();
        }

        public int ID { get; set; }

        [StringLength(100)]
        public string GROUP_DESC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SBH_TM_USER_ADMIN> SBH_TM_USER_ADMIN { get; set; }
    }
}
