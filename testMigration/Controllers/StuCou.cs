using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using testMigration.Models;
using testMigration.Servises.Student;
using testMigration.Servises.StudentCourses;
using testMigration.Tables;

namespace testMigration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StuCou : ControllerBase
    {
        private readonly AppDBcontext _dbContext;
        private readonly IstuCou _istuCou;

        public StuCou(AppDBcontext dbContext, IstuCou istuCou)
        {
            _dbContext = dbContext;
            _istuCou = istuCou;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudent()
        {
            var list = await _istuCou.GetAll();
            return Ok(list);
        }
        [HttpPost]
        public async Task<IActionResult> postDate(StudentCourseModel stco)
        {
            var obj = new StudentCourse()
            {
                IdOfStudent = stco.IdOfStudent,
                IdOfCourse = stco.IdOfCourse,
                Date = stco.Date
            };

            await _dbContext.AddAsync(obj);
            await _dbContext.SaveChangesAsync();
            return Ok(obj);
        }

    }
}
