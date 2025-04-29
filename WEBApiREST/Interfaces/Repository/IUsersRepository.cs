using WEBApiREST.Models;

namespace WebAPI1.Repositories
{
    public interface IUsersRepository
    {
        Task<UserEntity> Add( Guid Id,string FirstName, string LastName, int Age, string Telephone, int CollegeId);
        Task<UserEntity> Add(UserEntity userEntity);
        Task<UserEntity?> Delete(Guid Id);
        Task<UserEntity?> Update(UserEntity user);
        Task<List<UserEntity>> Get();
        Task<UserEntity?> GetByFirstName(string FirstName);
        Task<UserEntity?> GetById(Guid id);
        Task<List<UserEntity>> GetByPage(int page, int pageSize);
        Task<UserEntity?> GetWithCollege(Guid id);
        Task<List<UserEntity?>> GetWithCollege();
    }
}