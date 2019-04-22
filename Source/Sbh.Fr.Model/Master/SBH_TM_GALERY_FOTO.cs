namespace Sbh.Fr.Model
{
    using Master;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class SBH_TM_GALERY_FOTO
    {
        public int ID { get; set; }
        public int USER_ID { get; set; }
        public int NEWS_ID { get; set; }
        public string PHOTO_PATH { get; set; }
        public string DESCRIPTION { get; set; }
        public DateTime CREATED_TIME { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime? LAST_MODIFIED_TIME { get; set; }
        public string LAST_MODIFIED_BY { get; set; }
        public int ROW_STATUS { get; set; }


        //public virtual SBH_TM_USER_ADMIN SBH_TM_USER_ADMIN { get; set; }
        public virtual SBH_TM_NEWS SBH_TM_NEWS { get; set; }

    }
}
