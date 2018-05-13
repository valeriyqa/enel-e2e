using JsonConfig;
using System.Collections.Generic;

namespace TestAutomationFramework.Tools
{
    class LoadUsersFromConf
    {
        public static Dictionary<string, User> GetUsers()
        {
            Dictionary<string, User> usersDictionary = new Dictionary<string, User>();
            foreach (dynamic userData in Config.Global.web_settings.users)
            {
                User user = new User();

                user.userEmail = userData.user_email;
                user.userPassword = userData.user_password;
                user.userDescription = userData.user_description;

                usersDictionary.Add(userData.user_id, user);
            }
            return usersDictionary;
        }

        public class User
        {
            public string userEmail { get; set; }
            public string userPassword { get; set; }
            public string userDescription { get; set; }
        }

    }
}
