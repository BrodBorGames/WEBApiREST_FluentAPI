using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI1.Repositories;
using WEBApiREST.Models;
using WEBApiREST.Repositories;

namespace WEBApiREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollegeController: ControllerBase
    {
        private readonly ICollegeRepository _collegeRepository;
        public CollegeController(ICollegeRepository collegeRepository)
        {
            _collegeRepository = collegeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CollegeEntity>>> Get()
        {
            var colleges = await _collegeRepository.Get();
            return Ok(colleges);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CollegeEntity>> GetById(int id)
        {
            var college = await _collegeRepository.GetById(id);
            if(college == null)
            {
                return NotFound();
            }
            return Ok(college);
        }
        

        [HttpPost]
        public async Task<ActionResult<CollegeEntity>> Add(CollegeEntity collegeEntity)
        {
            var college = await _collegeRepository.Create(collegeEntity);
            return Created();
        }
        [HttpPut]
        public async Task<ActionResult<CollegeEntity>> Put(CollegeEntity college)
        {
            if (college == null)
                return BadRequest();
            var existingCollege = await _collegeRepository.Update(college);
            if (existingCollege == null)
                return NotFound();

            return Ok(existingCollege);
        }
        [HttpDelete]
        public async Task<ActionResult<CollegeEntity>> Delete (int Id)
        {
            var deletedCollege = await _collegeRepository.Delete(Id);
            if(deletedCollege == null)
            {
                return NotFound();
            }
            return Ok(deletedCollege);

        }
    }
}
