using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace FlappyBird.Models
{
    public class User : IdentityUser
    {
        [JsonIgnore]
        public virtual List<Score>? Score { get; set; }
    }
}
