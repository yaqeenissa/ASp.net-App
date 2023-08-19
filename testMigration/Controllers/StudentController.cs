using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testMigration.Tables;
using testMigration.Servises.Student;
using testMigration.Models;

namespace testMigration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
       private readonly AppDBcontext _dbContext;
        private readonly IStudent _Istudent;

        public StudentController(AppDBcontext dbContext, IStudent student)
        {
            _dbContext = dbContext;
            _Istudent = student;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudent()
        {
            var list=await _Istudent.GetAll();
            return Ok(list);
        }
        [HttpPost]
        public async Task<IActionResult> createStudent(StudentModel student)
        {
            var obj = new Student()
            {
                
            name = student.name

        };
            await _dbContext.AddAsync(obj);
            await _dbContext.SaveChangesAsync();
            return Ok(obj);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _dbContext.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            _dbContext.Students.Remove(student);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, Student student)
        {
            if (id != student.id)
            {
                return BadRequest();
            }

            _dbContext.Entry(student).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
            }

            return NoContent();
        }

    }
}
