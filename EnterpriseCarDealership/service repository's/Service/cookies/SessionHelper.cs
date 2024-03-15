using EnterpriseCarDealership.Models;
using System.Text.Json;

namespace EnterpriseCarDealership.service_repository_s.Service.cookies
{//jakob
    public class SessionHelper
    {/// <summary>
    /// denne klasse vil hjælpe os med at skabe en session for hver gange vi logger ind
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
        public static User GetUser(HttpContext context)
        {
            ///vi tager en bestemt User deserialiserer det med json såå vi kan hente informationer om vores User
            String? json = context.Session.GetString("User");
            if (json != null)
            {
                var user = JsonSerializer.Deserialize<User>(json);
                return user;
            }
            //User user = new User();
            //user.UserLoggetOut();

            return null;
        }
        public static void SetUser(User user, HttpContext context)
        {
            ///denne metode serialiserer vores user med json så vi kan gemme vores user
            String json = JsonSerializer.Serialize(user);
            context.Session.SetString("User", json);
        }
    }
}
