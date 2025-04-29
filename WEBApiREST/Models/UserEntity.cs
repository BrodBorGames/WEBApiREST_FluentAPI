using System.Text.Json.Serialization;

namespace WEBApiREST.Models
{
    public class UserEntity
    {

        public Guid Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public int? Age { get; set; } = 0;
        public string? Telephone { get; set; } = "";
        public int CollegeID { get; set; }
        public CollegeEntity? College { get; set; }
    }
}
