using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StockChat.Models
{
    public class Message
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime MsgDate { get; set; }

        public string UserID { get; set; }
        public virtual ChatUser Sender { get; set; }

        public Message()
        {
            MsgDate = DateTime.Now;
        }

    }
}
