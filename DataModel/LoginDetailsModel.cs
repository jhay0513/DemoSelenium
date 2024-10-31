using Newtonsoft.Json;
using System.Collections.Generic;

namespace DemoSelenium.DataModel
{
    public class LoginDetailsModel
    {

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }

    }

    public class LoginModel
    {
        [JsonProperty("Logins")]
        public List<LoginDetailsModel> Logins { get; set; }
    }

}
