using InformationSecurity.BusinessLogic.Helpers;
using Newtonsoft.Json;

namespace InformationSecurity.Models
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; } = string.Empty;

        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; } = true;
        public bool CheckPassword { get; set; } = true;

        [JsonIgnore]
        public bool NeedEnterPassword => string.IsNullOrEmpty(Password);
    }
}
