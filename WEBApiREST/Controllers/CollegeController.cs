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
            return Ok(college);
        }

        [HttpPost]
        public async Task<ActionResult<CollegeEntity>> Add(CollegeEntity collegeEntity)
        {
            var college = await _collegeRepository.Create(collegeEntity);
            return Ok(college);
        }
    }
}
