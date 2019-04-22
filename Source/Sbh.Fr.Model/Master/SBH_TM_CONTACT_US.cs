namespace Sbh.Fr.Model.Master
{
    using ClsGlobal;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SBH_TM_CONTACT_US : BaseClass
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string NAME_SENDER { get; set; }

        [Required]
        [StringLength(100)]
        public string EMAIL_SENDER { get; set; }

        [Required]
        [StringLength(100)]
        public string PHONE_SENDER { get; set; }

        [StringLength(500)]
        public string DESCRIPTION { get; set; }
    }
}
