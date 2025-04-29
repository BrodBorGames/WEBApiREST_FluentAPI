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
    public class UsersController : ControllerBase
    {
        
        private readonly IUsersRepository _usersRepository;
        public UsersController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;

        }
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
        [HttpGet("college{id}")]
        public async Task<ActionResult<UserEntity>> GetWithCollege(Guid id)
        {
            var user_college = await _usersRepository.GetWithCollege(id);
            if ( user_college ==null)
            {
                return BadRequest();
            }
            return Ok(user_college);

        }
        [HttpGet("college")]
        public async Task<ActionResult<UserEntity>> GetWithCollege()
        {
            var usersWithCollege = await _usersRepository.GetWithCollege();
            return Ok(usersWithCollege);


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
            return Created();

        }
        
        [HttpDelete]
        public async Task<ActionResult<UserEntity>> Delete(Guid id)
        {
            var deletedUser = await _usersRepository.Delete(id);
            if (deletedUser == null)
            {
                return NotFound();
            }
            return Ok(deletedUser);
        }
    }
}
