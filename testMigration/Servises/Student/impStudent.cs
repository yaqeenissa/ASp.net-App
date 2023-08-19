using Microsoft.EntityFrameworkCore;


namespace testMigration.Servises.Student

{
    public class impStudent : IStudent
    {
        
            private readonly AppDBcontext _dbContext;

            public impStudent(AppDBcontext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<List<Tables.Student>> GetAll()
            {
            return await _dbContext.Students.ToListAsync();
            }

            public Task<Tables.Student> GetById(int id)
            {
                throw new NotImplementedException();
            }
        
    }
}

