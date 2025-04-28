using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI1.Repositories;
using WEBApiREST.Models;
using WEBApiREST.Users;

namespace WEBApiREST.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        
        private readonly IUsersRepository _usersRepository;
        public UsersController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;

        }
        //[Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserEntity>>> Get()
        {
            //return await usersRepository.Get();
            var users = await _usersRepository.Get();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserEntity>> GetById(Guid id)
        {
            var user = await _usersRepository.GetById(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }
        [HttpPut]
        public async Task<ActionResult<UserEntity>> Put(UserEntity user)
        {
            if (user == null)
                return BadRequest();

            var existingUser = await _usersRepository.GetById(user.Id);
            if (existingUser == null)
                return NotFound();

            await _usersRepository.Update(user);
            return Ok(user);
        }
        
        [HttpPost]
        public async Task<ActionResult<UserEntity>> CreateUser(UserEntity user)
        {

            user.Id = Guid.NewGuid(); 
            var createdUser = await _usersRepository.Add(user);
            return Ok(createdUser);

        }
    }
}
