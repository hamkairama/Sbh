namespace Sbh.Fr.Model.Custom
{
    using ClsGlobal;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class ChangePassword : BaseClass
    {
        [Required]
        [StringLength(50)]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(50)]
        public string NewPassword { get; set; }
        

        [Required]
        [StringLength(50)]
        public string ConfirmPassword { get; set; }
        
        
    }
}
