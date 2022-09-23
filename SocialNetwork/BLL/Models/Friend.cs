using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Models
{
    public class Friend
    {
        public int Id { get; }
        public string SenderEmail { get; }

        public Friend(int id, string senderEmail)
        {
            this.Id = id;
            this.SenderEmail = senderEmail;
        }
    }
}
