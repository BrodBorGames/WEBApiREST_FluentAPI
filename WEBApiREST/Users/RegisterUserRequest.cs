using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WEBApiREST.Users
{
    public record RegisterUserRequest(
        [Required] string FirstName,
        [Required] string LastName,
        [AllowNull] int Age,
        [AllowNull] string Telephone,
        [AllowNull] int CollegeID);

}
