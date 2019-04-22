namespace Sbh.Fr.Model.Master
{
    using ClsGlobal;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SBH_TM_SOSMED : BaseClass
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string TYPE { get; set; }

        [Required]
        [StringLength(500)]
        public string NAME { get; set; }

        [StringLength(500)]
        public string DESCRIPTION { get; set; }

        [StringLength(100)]
        public string ICON { get; set; }

        [StringLength(100)]
        public string URL { get; set; }

        [StringLength(100)]
        public string DATA_EMBED { get; set; }

        public int? HEIGHT { get; set; }

        public int? WIDTH { get; set; }

        [StringLength(100)]
        public string DATA_WIDGET_ID { get; set; }

        [StringLength(100)]
        public string PHOTO_PATH { get; set; }

        public int BANNER_SELECTED { get; set; }
    }
}
