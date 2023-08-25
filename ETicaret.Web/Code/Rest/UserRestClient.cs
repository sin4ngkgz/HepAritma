using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Serializers.Json;
using System.Text.Json;

namespace ETicaret.Web.Code.Rest
{
    public class UserRestClient
    {
        private string BASE_API_URI = "https://localhost:7277/api";
        public dynamic Login (string email, string password)
        {
            RestClient client = new RestClient (BASE_API_URI, configureSerialization: s => s.UseSystemTextJson(new JsonSerializerOptions { PropertyNamingPolicy = null }));

            RestRequest req = new RestRequest("/Auth/Login", Method.Post);
            req.AddJsonBody(new
            {
                Email = email,
                Password = password
            });

            RestResponse resp = client.Post(req);
            string msg = resp.Content.ToString();
            dynamic result = JObject.Parse(msg);
            return result;

        }
        public dynamic SignUp (string firstName, string lastName, string phoneNumber, string email, string password) 
        {
            RestClient client = new RestClient(BASE_API_URI, configureSerialization: s => s.UseSystemTextJson(new JsonSerializerOptions { PropertyNamingPolicy = null }));

            RestRequest req = new RestRequest("/User/SignUp", Method.Post);
            req.AddJsonBody(new
            {
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                Email = email,
                Password = password
            });

            RestResponse resp = client.Post(req);
            string msg = resp.Content.ToString();
            dynamic result = JObject.Parse(msg);
            return result;

        }
    }
}
