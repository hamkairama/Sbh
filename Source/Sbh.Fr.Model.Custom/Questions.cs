namespace Sbh.Fr.Model.Custom
{
    using ClsGlobal;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Questions
    {
        public int ID { get; set; }

        public int? ID_CATEGORY { get; set; }

        public int? ID_USER { get; set; }

        [Column(TypeName = "text")]
        public string QUESTIONS { get; set; }

        [StringLength(100)]
        public string TITLE_QUESTIONS { get; set; }

        public string CATEGORY_DESC { get; set; }
        public string USER_NAME { get; set; }
        public DateTime? CREATED_TIME { get; set; }
        public string CREATED_BY { get; set; }
        public int ROW_STATUS { get; set; }

    }
}
