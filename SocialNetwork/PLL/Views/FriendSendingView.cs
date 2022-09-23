using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.PLL.Views
{
    public class FriendSendingView
    {
        UserService userService;
        MessageService messageService;
        FriendService friendService;

        public FriendSendingView(MessageService messageService, UserService userService, FriendService friendService)
        {
            this.messageService = messageService;
            this.userService = userService;
            this.friendService = friendService;
        }

        public void Show(User user)
        {
            var friendSendingData = new AddFriendData();

            Console.Write("Введите почтовый адрес друга: ");
            friendSendingData.RecipientEmail = Console.ReadLine();

            friendSendingData.SenderId = user.Id;

            try
            {
                messageService.AddFriendMessage(friendSendingData);

                SuccessMessage.Show("Сообщение успешно отправлено!");

                user = userService.FindById(user.Id);
            }

            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден!");
            }

            catch (ArgumentNullException)
            {
                AlertMessage.Show("Введите корректное значение!");
            }

            catch (Exception)
            {
                AlertMessage.Show("Произошла ошибка при отправке сообщения!");
            }

        }
    }
}
