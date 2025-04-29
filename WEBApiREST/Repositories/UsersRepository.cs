using System.Net;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEBApiREST;
using WEBApiREST.Models;

namespace WebAPI1.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationContext _dbcontext;

        public UsersRepository(ApplicationContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<List<UserEntity>> Get()
        {
            return await _dbcontext.User
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<UserEntity?> GetById(Guid id)
        {

            return await _dbcontext.User
                    .AsNoTracking()
                    .FirstOrDefaultAsync(u => u.Id == id);

        }

        public async Task<UserEntity?> GetByFirstName(string FirstName)
        {

            return await _dbcontext.User
                    .AsNoTracking()
                    .FirstOrDefaultAsync(u => u.FirstName == FirstName);

        }

        public async Task<List<UserEntity>> GetByPage(int page, int pageSize)
        {
            return await _dbcontext.User
                        .AsNoTracking()
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ToListAsync();
        }


        public async Task<UserEntity> Add(Guid Id,string FirstName, string LastName, int Age, string Telephone, int CollegeId)
        {
            var userEntity = new UserEntity
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                Age = Age,
                Telephone = Telephone,
                CollegeID = CollegeId
            };
                 
            

            await _dbcontext.User.AddAsync(userEntity);
            await _dbcontext.SaveChangesAsync();
            return userEntity;
        }
        public async Task<UserEntity> Add(UserEntity user)
        {




            await _dbcontext.User.AddAsync(user);
            await _dbcontext.SaveChangesAsync();
            return user;
        }

        public async Task<UserEntity?> Update(UserEntity user)
        {
            var existingUser = await _dbcontext.User.FirstOrDefaultAsync(u => u.Id == user.Id);
            if (existingUser == null)
                return null;

            // Обновляем нужные поля
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Age = user.Age;
            existingUser.Telephone = user.Telephone;
            existingUser.CollegeID = user.CollegeID;

            await _dbcontext.SaveChangesAsync();
            return existingUser;
        }

        public async Task<UserEntity?> Delete(Guid Id)
        {
            var deletedUser = await _dbcontext.User.FirstOrDefaultAsync(x => x.Id == Id);
            if(deletedUser == null)
            {
                return null;
            }
            _dbcontext.User.Remove(deletedUser);
            await _dbcontext.SaveChangesAsync();
            return deletedUser;
        }

        public async Task<UserEntity?> GetWithCollege(Guid id)
        {
            var userWithCollege = await _dbcontext.User.Include(x => x.College).FirstOrDefaultAsync(x => x.Id ==id);
            if(userWithCollege == null)
            {
                return null;
            }
            return userWithCollege;
        }

        public async Task<List<UserEntity?>> GetWithCollege()
        {
            var usersWithCollege = await _dbcontext.User.Include(x => x.College).ToListAsync();
            if (usersWithCollege == null)
            {
                return null;
            }
            return usersWithCollege;
        }
    }
}
