using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BussinessObjects.Models;

public partial class QuizletProjectContext : DbContext
{
    public QuizletProjectContext()
    {
    }

    public QuizletProjectContext(DbContextOptions<QuizletProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChatGpt> ChatGpts { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<ClassMember> ClassMembers { get; set; }

    public virtual DbSet<ClassSet> ClassSets { get; set; }

    public virtual DbSet<FlashCard> FlashCards { get; set; }

    public virtual DbSet<Folder> Folders { get; set; }

    public virtual DbSet<FolderDetail> FolderDetails { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<StudySet> StudySets { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserFlashCard> UserFlashCards { get; set; }

    public virtual DbSet<UserStudySet> UserStudySets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {       
        var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        optionsBuilder.UseSqlServer(config.GetConnectionString("MyDB"));        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChatGpt>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ChatGPT__3214EC074D326756");

            entity.ToTable("ChatGPT");

            entity.Property(e => e.Answer).HasMaxLength(1000);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Question).HasMaxLength(1000);

            entity.HasOne(d => d.User).WithMany(p => p.ChatGpts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__ChatGPT__UserId__5535A963");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Classes__3214EC072E8E38DE");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Classes)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__Classes__Created__3C69FB99");
        });

        modelBuilder.Entity<ClassMember>(entity =>
        {
            entity.HasKey(e => new { e.ClassId, e.MemberId }).HasName("PK__Class_Me__5BD623718E57ABA6");

            entity.ToTable("Class_Member");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Class).WithMany(p => p.ClassMembers)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Class_Mem__Class__4D94879B");

            entity.HasOne(d => d.Member).WithMany(p => p.ClassMembers)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Class_Mem__Membe__4E88ABD4");
        });

        modelBuilder.Entity<ClassSet>(entity =>
        {
            entity.HasKey(e => new { e.SetId, e.ClassId }).HasName("PK__Class_Se__62B9D56121377DA8");

            entity.ToTable("Class_Set");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Class).WithMany(p => p.ClassSets)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Class_Set__Class__49C3F6B7");

            entity.HasOne(d => d.Set).WithMany(p => p.ClassSets)
                .HasForeignKey(d => d.SetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Class_Set__SetId__4AB81AF0");
        });

        modelBuilder.Entity<FlashCard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FlashCar__3214EC079BB9F60E");

            entity.Property(e => e.Answer).HasMaxLength(1000);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Question).HasMaxLength(1000);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Sets).WithMany(p => p.FlashCards)
                .HasForeignKey(d => d.SetsId)
                .HasConstraintName("FK__FlashCard__SetsI__4316F928");
        });

        modelBuilder.Entity<Folder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Folder__3214EC07B1913C1E");

            entity.ToTable("Folder");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Folders)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__Folder__CreatedB__398D8EEE");
        });

        modelBuilder.Entity<FolderDetail>(entity =>
        {
            entity.HasKey(e => new { e.SetId, e.FolderId }).HasName("PK__FolderDe__94C5361A1A5E8F08");

            entity.ToTable("FolderDetail");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Folder).WithMany(p => p.FolderDetails)
                .HasForeignKey(d => d.FolderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FolderDet__Folde__52593CB8");

            entity.HasOne(d => d.Set).WithMany(p => p.FolderDetails)
                .HasForeignKey(d => d.SetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FolderDet__SetId__5165187F");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Role__3214EC07103DE83B");

            entity.ToTable("Role");

            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.RoleName).HasMaxLength(100);
        });

        modelBuilder.Entity<StudySet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StudySet__3214EC07FEC887C5");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.StudySets)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__StudySets__Creat__36B12243");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC071C874D1A");

            entity.ToTable("User");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserRole",
                    r => r.HasOne<Role>().WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__User_Role__RoleI__33D4B598"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__User_Role__UserI__32E0915F"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId").HasName("PK__User_Rol__AF2760ADF304F35E");
                        j.ToTable("User_Role");
                    });
        });

        modelBuilder.Entity<UserFlashCard>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.FlashCardId }).HasName("PK__User_Fla__26A5BA13A1F2FCA3");

            entity.ToTable("User_FlashCard");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.FlashCard).WithMany(p => p.UserFlashCards)
                .HasForeignKey(d => d.FlashCardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__User_Flas__Flash__46E78A0C");

            entity.HasOne(d => d.User).WithMany(p => p.UserFlashCards)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__User_Flas__UserI__45F365D3");
        });

        modelBuilder.Entity<UserStudySet>(entity =>
        {
            entity.HasKey(e => new { e.SetId, e.UserId }).HasName("PK__User_Stu__AF70CBD94C85EDD9");

            entity.ToTable("User_StudySet");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.IsFavorite).HasColumnName("isFavorite");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Set).WithMany(p => p.UserStudySets)
                .HasForeignKey(d => d.SetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__User_Stud__SetId__403A8C7D");

            entity.HasOne(d => d.User).WithMany(p => p.UserStudySets)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__User_Stud__UserI__3F466844");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
