using JsonConfig;
using System.Collections.Generic;

namespace TestAutomationFramework.Tools
{
    class LoadFromConf
    {
        public static Dictionary<string, User> GetUsers()
        {
            Dictionary<string, User> usersDictionary = new Dictionary<string, User>();
            foreach (dynamic userData in Config.Global)
            {
                if (userData.Key.Contains("_user_id"))
                {
                    User user = new User();

                    string prefix = userData.Key.Substring(0, userData.Key.IndexOf('_'));

                    user.userEmail = Config.Global[prefix + "_user_email"];
                    user.userPassword = Config.Global[prefix + "_user_password"];
                    user.userDescription = Config.Global[prefix + "_user_description"];

                    usersDictionary.Add(Config.Global[prefix + "_user_id"], user);
                }

            }
            return usersDictionary;
        }

        //This is old version of this method. Can be applied when used array of users in the config file.
        //For the flat user list please use new version of this method.
        //public static Dictionary<string, User> GetUsers()
        //{
        //    Dictionary<string, User> usersDictionary = new Dictionary<string, User>();
        //    foreach (dynamic userData in Config.Global.web_settings.users)
        //    {
        //        User user = new User();

        //        user.userEmail = userData.user_email;
        //        user.userPassword = userData.user_password;
        //        user.userDescription = userData.user_description;

        //        usersDictionary.Add(userData.user_id, user);
        //    }
        //    return usersDictionary;
        //}

        public class User
        {
            public string userEmail { get; set; }
            public string userPassword { get; set; }
            public string userDescription { get; set; }
        }

    }
}
