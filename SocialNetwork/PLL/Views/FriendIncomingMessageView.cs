using SocialNetwork.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetwork.PLL.Views
{
    public class FriendIncomingMessageView
    {
        public void Show(IEnumerable<Friend> incomingMessages)
        {
            Console.WriteLine("Входящие запросы в друзья:");

            if (incomingMessages.Count() == 0)
            {
                Console.WriteLine("Входящих запросов нет");
                return;
            }

            incomingMessages.ToList().ForEach(message =>
            {
                Console.WriteLine("От кого: {0}", message.SenderEmail);
            });
        }
    }
}