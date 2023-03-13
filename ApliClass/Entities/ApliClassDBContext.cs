using Microsoft.EntityFrameworkCore;

namespace Entities;

public partial class ApliClassDBContext : DbContext
{
    public ApliClassDBContext()
    {
    }

    public ApliClassDBContext(DbContextOptions<ApliClassDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Assessment> Assessments { get; set; }
    public virtual DbSet<Attendance> Attendances { get; set; }
    public virtual DbSet<AttendanceState> AttendanceStates { get; set; }
    public virtual DbSet<Class> Classes { get; set; }
    public virtual DbSet<Lesson> Lessons { get; set; }
    public virtual DbSet<Student> Students { get; set; }
    public virtual DbSet<TypesOfUser> TypesOfUsers { get; set; }
    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https: //go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            optionsBuilder.UseSqlServer(
                "Server=.;Database=ApliClassDB;Integrated Security=True;Trusted_Connection=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Assessment>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.ClassId).HasColumnName("ClassID");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.StudentId).HasColumnName("StudentID");

            entity.HasOne(d => d.Class)
                .WithMany(p => p.Assessments)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Assessments_Classes");

            entity.HasOne(d => d.Student)
                .WithMany(p => p.Assessments)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Assessments_StudentIDs");
        });

        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.ToTable("Attendance");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.LessonId).HasColumnName("LessonID");

            entity.Property(e => e.StateId).HasColumnName("StateID");

            entity.Property(e => e.StudentId).HasColumnName("StudentID");

            entity.HasOne(d => d.Lesson)
                .WithMany(p => p.Attendances)
                .HasForeignKey(d => d.LessonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Attendance_Lessons");

            entity.HasOne(d => d.State)
                .WithMany(p => p.Attendances)
                .HasForeignKey(d => d.StateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Attendance_State");

            entity.HasOne(d => d.Student)
                .WithMany(p => p.Attendances)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Attendance_StudentID");
        });

        modelBuilder.Entity<AttendanceState>(entity =>
        {
            entity.HasIndex(e => e.State, "UQ_AttendanceStates_State")
                .IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.State)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

            entity.HasOne(d => d.Teacher)
                .WithMany(p => p.Classes)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Classes_TeacherID");
        });

        modelBuilder.Entity<Lesson>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.ClassId).HasColumnName("ClassID");

            entity.Property(e => e.Date).HasColumnType("datetime");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Class)
                .WithMany(p => p.Lessons)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lessons_Class");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.ClassId).HasColumnName("ClassID");

            entity.Property(e => e.StudentId).HasColumnName("StudentID");

            entity.HasOne(d => d.Class)
                .WithMany(p => p.Students)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Students_Class");

            entity.HasOne(d => d.StudentNavigation)
                .WithMany(p => p.Students)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentID_StudentID");
        });

        modelBuilder.Entity<TypesOfUser>(entity =>
        {
            entity.HasIndex(e => e.Type, "UQ_TypesOfUsers_Type")
                .IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "UK_users_Email")
                .IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.PrimerApellido)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.SegundoApellido)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.UserTypeNavigation)
                .WithMany(p => p.Users)
                .HasForeignKey(d => d.UserType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_users_TypesOfUsers");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}