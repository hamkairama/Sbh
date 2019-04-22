namespace Sbh.Fr.Model.Custom
{
    using ClsGlobal;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class ChatBox : BaseClass
    {
        public int ID { get; set; }

        public int SENDER_ID { get; set; }

        public String SENDER_NAME { get; set; }

        public int RECEIVER_ID { get; set; }

        public String RECEIVER_NAME { get; set; }

        public string MESSAGE { get; set; }

        public DateTime DATE { get; set; }
             
        public string TIME { get; set; }


    }
}
