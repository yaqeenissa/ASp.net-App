using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testMigration.Servises.courser;
using testMigration.Servises.Student;
using testMigration.Tables;

namespace testMigration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class courseController : ControllerBase
    {
        private readonly ICourse _course;
        private readonly AppDBcontext _dbcontext;
        public courseController(AppDBcontext dbContext, ICourse courses)
        {
            _dbcontext = dbContext;
            _course = courses; 
        }


        [HttpGet]
        public async Task<IActionResult> GetStudent()
        {
            var list = await _course.GetAll();
            return Ok(list);
        }
        [HttpPost]
        public async Task<IActionResult> createStudent(Course course)
        {
            var obj = new Course()
            {

                Name = course.Name
                 
            };
            await _dbcontext.AddAsync(obj);
            await _dbcontext.SaveChangesAsync();
            return Ok(obj);
        }

    }
}
