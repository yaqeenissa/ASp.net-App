using testMigration.Tables;

namespace testMigration.Servises.StudentCourses
{
    public class impStuCou : IstuCou
    {
        private readonly AppDBcontext _dbcontext;
        public impStuCou(AppDBcontext dbcontext)
        {
               this._dbcontext = dbcontext;
        }
        Task<List<StudentCourse>> IstuCou.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<StudentCourse> IstuCou.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
