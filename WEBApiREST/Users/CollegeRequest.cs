using System.ComponentModel.DataAnnotations;

namespace WEBApiREST.Users
{
    public record CollegeRequest(
        [Required] string Name,
        [Required] string Director);
}
