namespace Sbh.Fr.Model.Custom
{
    using ClsGlobal;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Answer: BaseClassClient
    {
        public int ID { get; set; }

        public int? ID_QUESTIONS { get; set; }

        public int? ID_USER_ADMIN { get; set; }

        [Column(TypeName = "text")]
        public string ANSWER { get; set; }

        [Column(TypeName = "text")]
        public string QUESTIONS { get; set; }

        [StringLength(100)]
        public string TITLE_QUESTIONS { get; set; }
    }
}
