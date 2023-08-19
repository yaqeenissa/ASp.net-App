using Microsoft.EntityFrameworkCore;
using testMigration.Tables;

namespace testMigration
{
    public class AppDBcontext : DbContext
    {
        internal object student;

        public AppDBcontext(DbContextOptions<AppDBcontext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        public DbSet<StudentCourse> studentCourses { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable(nameof(Student));
            modelBuilder.Entity<Student>().HasKey(c => c.id);
            modelBuilder.Entity<Student>().Property(s => s.id).HasColumnName("StudentId");
            modelBuilder.Entity<Student>().Property(s => s.name).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<Course>().ToTable(nameof(Course));
            modelBuilder.Entity<Course>().HasKey(c => c.Id);
            modelBuilder.Entity<Course>().Property(c => c.Id).HasColumnName("Id");
            modelBuilder.Entity<Course>().Property(c => c.Name).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<StudentCourse>().HasKey(sc => new { sc.IdOfStudent, sc.IdOfCourse });

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany()
                .HasForeignKey(sc => sc.IdOfStudent);

            modelBuilder.Entity<StudentCourse>()
               .HasOne(sc => sc.Course)
               .WithMany()
               .HasForeignKey(sc => sc.IdOfCourse);

            modelBuilder.Entity<StudentCourse>()
               .Property(sc => sc.Date)
               .IsRequired()
               .HasConversion(
       v => new DateTime(v.Year, v.Month, v.Day),
       v => new DateOnly(v.Year, v.Month, v.Day));
            base.OnModelCreating(modelBuilder);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //cleared
        }

    }
}
