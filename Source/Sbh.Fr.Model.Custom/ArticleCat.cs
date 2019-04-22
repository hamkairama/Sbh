namespace Sbh.Fr.Model.Custom
{
    using ClsGlobal;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class ArticleCat : BaseClass
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string ARTICLE_CAT_DESC { get; set; }
    }
}
