using Microsoft.EntityFrameworkCore;
using testMigration.Tables;

namespace testMigration.Servises.courser
{
    
    public class impCourses : ICourse
    {

        private readonly AppDBcontext _DBcontext;

        public impCourses(AppDBcontext dbcontext)
        {
            _DBcontext = dbcontext;

        }
        public async Task<List<Course>> GetAll()
        {
            return  await _DBcontext.Courses.ToListAsync(); 
        }

        public Task<Course> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
