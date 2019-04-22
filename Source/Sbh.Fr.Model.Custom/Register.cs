using Sbh.Fr.Model.ClsGlobal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbh.Fr.Model.Custom
{
    public class Register : BaseClassClient
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string PasswordOld { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(50)]
        public string ConfirmPassword { get; set; }

        public DateTime? Born { get; set; }

        [StringLength(1)]
        public string Gender { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(100)]
        public string Job { get; set; }

        [StringLength(100)]
        public string Company { get; set; }

        [StringLength(100)]
        public string Hobby { get; set; }

        [StringLength(100)]
        [Display(Name = "Other Description")]
        public string OtherDescription { get; set; }

        public int ID_GROUP { get; set; }
        public bool IsSuperAdmin { get; set; }

        public string DESCR { get; set; }
        public int START_COUNT { get; set; }

        public int? MOST_ACT_ANSWER { get; set; }
        public int? MOST_ACT_QUESTIONS { get; set; }
        
    }
}
