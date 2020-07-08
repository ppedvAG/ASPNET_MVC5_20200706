namespace School.Service
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using School.Domain.Entities;

    public partial class SchoolModel : DbContext
    {
        public SchoolModel()
            : base("name=SchoolModel")//ConnectionString steht in der Web.Config unter SchoolModel
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Standard> Standard { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentAddress> StudentAddress { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .Property(e => e.CourseName)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Student)
                .WithMany(e => e.Course)
                .Map(m => m.ToTable("StudentCourse").MapLeftKey("CourseId").MapRightKey("StudentId"));

            modelBuilder.Entity<Standard>()
                .Property(e => e.StandardName)
                .IsUnicode(false);

            modelBuilder.Entity<Standard>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Standard>()
                .HasMany(e => e.Student)
                .WithOptional(e => e.Standard)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Standard>()
                .HasMany(e => e.Teacher)
                .WithOptional(e => e.Standard)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Student>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<Student>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .HasOptional(e => e.StudentAddress)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete();

            modelBuilder.Entity<StudentAddress>()
                .Property(e => e.Address1)
                .IsUnicode(false);

            modelBuilder.Entity<StudentAddress>()
                .Property(e => e.Address2)
                .IsUnicode(false);

            modelBuilder.Entity<StudentAddress>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<StudentAddress>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.TeacherName)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .HasMany(e => e.Course)
                .WithOptional(e => e.Teacher)
                .WillCascadeOnDelete();
        }
    }
}
