using Newtonsoft.Json;
using System.Collections.Generic;

namespace DemoSelenium.DataModel
{
    public class PersonDetailModel
    {
        [JsonProperty("FirstName")]
        public string FirstName { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }

    }

    public class PersonsModel
    {
        [JsonProperty("Persons")]
        public List<PersonDetailModel> Persons { get; set; }
    }

}
