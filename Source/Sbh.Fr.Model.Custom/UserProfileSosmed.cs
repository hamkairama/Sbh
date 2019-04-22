namespace Sbh.Fr.Model.Custom
{
    using ClsGlobal;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class UserProfileSosmed:BaseClass
    {
        public int ID { get; set; }

        public int USER_PROFILE_ID { get; set; }

        [Required]
        [StringLength(100)]
        public string SOSMED_NAME { get; set; }

        [Required]
        [StringLength(100)]
        public string SOSMED_PATH { get; set; }
    }
}
