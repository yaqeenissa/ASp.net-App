namespace testMigration.Servises.StudentCourses
{
    public interface IstuCou
    {
        Task<List<Tables.StudentCourse>> GetAll();
        Task<Tables.StudentCourse> GetById(int id);
    }
}

