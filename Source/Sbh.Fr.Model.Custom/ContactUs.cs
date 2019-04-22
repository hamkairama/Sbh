namespace Sbh.Fr.Model.Custom
{
    using ClsGlobal;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class ContactUs
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
