namespace testMigration.Tables
{
    public class StudentCourse
    {

        public int IdOfStudent { get; set; }
        public int IdOfCourse { get; set;}
        public DateOnly Date { get; set; }
        public Student Student { get; internal set; }
        public Course Course { get; set; }
    }
}
