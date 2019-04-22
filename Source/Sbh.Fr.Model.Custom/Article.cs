namespace Sbh.Fr.Model.Custom
{
    using ClsGlobal;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Article : BaseClass
    {
        public int ID { get; set; }

        public int? ID_USER_ADMIN { get; set; }

        public int? ID_ARTICLE_CAT { get; set; }

        [Column(TypeName = "text")]
        public string ARTICLE { get; set; }
    }
}
