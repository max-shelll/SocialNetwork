using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetwork.BLL.Services
{
    public class FriendService
    {
        IFriendRepository friendRepository;
        IUserRepository userRepository;
        public FriendService()
        {
            userRepository = new UserRepository();
            friendRepository = new FriendRepository();
        }

        public IEnumerable<Friend> GetIncomingFriendByUserId(int recipientId)
        {
            var friends = new List<Friend>();

            friendRepository.FindAllByUserId(recipientId).ToList().ForEach(m =>
            {
                var senderUserEntity = userRepository.FindById(m.user_id);
                var recipientUserEntity = userRepository.FindById(m.friend_id);

                friends.Add(new Friend(m.id, senderUserEntity.email));
            });

            return friends;
        }
    }
}
