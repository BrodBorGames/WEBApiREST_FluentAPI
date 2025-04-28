
using System.Collections.Generic;
using WEBApiREST.Interfaces;
using WEBApiREST.Models;

namespace WEBApiREST
{
    public class DataSeed : IDataSeed
    {
        private readonly ApplicationContext _context;

        public DataSeed(ApplicationContext context)
        {
            _context = context;
        }
        public void SeedData()
        {
            SeedCollege();
            SeedUser();
        }

        private void SeedUser()
        {
            if (!_context.User.Any())
            {
                IEnumerable<UserEntity> Users = [
                    new UserEntity
                    {
                        Id = Guid.NewGuid(),
                        FirstName = "Данил",
                        LastName = "Юсупов",
                        Age = 19,
                        Telephone="+79326044223",
                        CollegeID = 1
                    },
                    new UserEntity{
                        Id = Guid.NewGuid(),
                        FirstName = "Иван",
                        LastName = "Черняков",
                        Age = 20,
                        Telephone = "+79228945234",
                        CollegeID = 2
                    }
                 ];

            }
        }

        private void SeedCollege()
        {
            IEnumerable<CollegeEntity> Colleges = [
                new CollegeEntity{
                    Name = "Первоуральский Металлургический Колледж",
                    Director = "Антипина Ольга Феликсовна"
                },
                new CollegeEntity{
                    Name="Первоуральский Политехникум",
                    Director="Иванов Иван Григорьевич"
                }
                ];
        }
    }
}
