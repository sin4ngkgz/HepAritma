namespace ETicaret.Web.Code
{
    public class Repo
    {
        public static class Session
        {
            public static string? Email
            {
                get
                {
                    string email = (new HttpContextAccessor()).HttpContext.Session.GetString("Email");
                    return email;
                }
                set
                {
                    (new HttpContextAccessor()).HttpContext.Session.SetString("Email", value ?? "");
                }
            }
            public static string? Token
            {
                get
                {
                    string token = (new HttpContextAccessor()).HttpContext.Session.GetString("Token");
                    return token;
                }
                set
                {
                    (new HttpContextAccessor()).HttpContext.Session.SetString("Token", value ?? "");
                }
            }
            public static string? Role
            {
                get
                {
                    string role = (new HttpContextAccessor()).HttpContext.Session.GetString("Role");
                    return role;
                }
                set
                {
                    (new HttpContextAccessor()).HttpContext.Session.SetString("Role", value ?? "");
                }
            }
            public static string? Product
            {
                get
                {
                    string product = (new HttpContextAccessor()).HttpContext.Session.GetString("Product");
                    return product;
                }
                set
                {
                    (new HttpContextAccessor()).HttpContext.Session.SetString("Product", value ?? "");
                }
            }
            public static string? User
            {
                get
                {
                    string user = (new HttpContextAccessor()).HttpContext.Session.GetString("User");
                    return user;
                }
                set
                {
                    (new HttpContextAccessor()).HttpContext.Session.SetString("User", value ?? "");
                }
            }
        }
    }
}
