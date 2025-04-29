using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEBApiREST.Models;

namespace WEBApiREST.Repositories
{
    public class CollegeRepository : ICollegeRepository
    {
        private readonly ApplicationContext _dbcontext;

        public CollegeRepository(ApplicationContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<List<CollegeEntity>> Get()
        {
            return await _dbcontext.College
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task<CollegeEntity?> GetById(int Id)
        {
            return await _dbcontext.College
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task Create( string Name, string Director)
        {
            var college = new CollegeEntity
            {
                
                Name = Name,
                Director = Director
            };
            await _dbcontext.College.AddAsync(college);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<CollegeEntity?> Delete(int Id)
        {
           var college = _dbcontext.College.FirstOrDefault(x => x.Id == Id);
            if (college != null) { 
                _dbcontext.College.Remove(college);
                await _dbcontext.SaveChangesAsync();
                return college;
            }
            return null;
        }

        public async Task<CollegeEntity?> Update(CollegeEntity collegeEntity)
        {
            
            var college = await _dbcontext.College.FirstOrDefaultAsync(x => x.Id == collegeEntity.Id);
            if (college != null)
            {
                college.Name = collegeEntity.Name;
                college.Director = collegeEntity.Director;
                
            }
            return college;

        }

        public async Task<CollegeEntity> Create(CollegeEntity collegeEntity)
        {
            var college = collegeEntity;
            await _dbcontext.College.AddAsync(collegeEntity);
            await _dbcontext.SaveChangesAsync();
            return collegeEntity;
        }

    }
}
