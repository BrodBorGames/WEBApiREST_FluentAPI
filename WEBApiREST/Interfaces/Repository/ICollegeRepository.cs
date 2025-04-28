using Microsoft.AspNetCore.Mvc;
using WEBApiREST.Models;

namespace WEBApiREST.Repositories
{
    public interface ICollegeRepository
    {
        Task Create(string Name, string Director);
        Task<CollegeEntity> Create(CollegeEntity entity);
        Task<List<CollegeEntity>> Get();
        
        Task Delete(string Name);
        Task Update(CollegeEntity entity);
        Task<CollegeEntity?> GetById(int id);
    }
}