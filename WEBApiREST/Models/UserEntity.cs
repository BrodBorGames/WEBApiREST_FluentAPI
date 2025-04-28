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
        [JsonIgnore]
        public CollegeEntity? College { get; set; }
        //public UserEntity(Guid id, string firstName, string lastName, int? age, string? telephone, int collegeId)
        //{
        //    Id = id;
        //    FirstName = firstName;
        //    LastName = lastName;
        //    Age = age;
        //    Telephone = telephone;
        //    CollegeId = collegeId;
        //}
    }
}
