using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;

namespace SocialNetwork.Tests
{
    [TestFixture]
    public class RegistrationTests
    {
        [Test]
        public void MustFindRegisterAccount()
        {
            UserService userService = new UserService();

            var userRegistrationData = new UserRegistrationData();

            userRegistrationData.FirstName = "Maxim";

            userRegistrationData.LastName = "Shalaev";

            userRegistrationData.Password = "123456789";

            userRegistrationData.Email = "Maxim@gmail.com";

            userService.Register(userRegistrationData);

            try
            {
                userService.FindByEmail(userRegistrationData.Email);
            }
            catch (UserNotFoundException)
            {
                Assert.Fail();
            }
        }
    }
}
