using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WEBApiREST.Models
{
    public class CollegeEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Director { get; set; } = "";
        //[JsonIgnore]
        public ICollection<UserEntity>? Users { get; set; }
    }
}
