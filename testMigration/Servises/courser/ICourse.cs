namespace testMigration.Servises.courser
{
    public interface ICourse
    {
        Task<List<Tables.Course>> GetAll();
        Task<Tables.Course> GetById(int id);
    }
}
