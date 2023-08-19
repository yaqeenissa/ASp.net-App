namespace testMigration.Servises.Student
{
    public interface IStudent
    {
        Task<List<Tables.Student>> GetAll();
        Task<Tables.Student> GetById(int id);
    }
}
