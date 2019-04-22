namespace Sbh.Fr.Model.Custom
{
    using ClsGlobal;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class CategoryQuestions : BaseClass
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string CATEGORY_DESC { get; set; }
    }
}
