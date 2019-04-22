namespace Sbh.Fr.Model.Custom
{
    using ClsGlobal;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class UserAdmin : BaseClassClient
    {
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
    }
}
