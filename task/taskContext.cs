using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace task
{
    public partial class taskContext : DbContext
    {
        public taskContext()
        {
        }

        public taskContext(DbContextOptions<taskContext> options)
            : base(options)
        {
        }

        public virtual DbSet<StatusTask> StatusTasks { get; set; } = null!;
        public virtual DbSet<Task> Tasks { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Data Source=C:\\Users\\toshm\\source\\repos\\task\\task\\bin\\Debug\\task.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StatusTask>(entity =>
            {
                entity.ToTable("StatusTask");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'Свободно'");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("Task");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Datepublic).HasColumnName("datepublic");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.IdStatus).HasColumnName("idStatus");

                entity.Property(e => e.IdUserAccept).HasColumnName("idUserAccept");

                entity.Property(e => e.IdUserCreate).HasColumnName("idUserCreate");

                entity.Property(e => e.Taskname).HasColumnName("taskname");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.IdStatus);

                entity.HasOne(d => d.IdUserAcceptNavigation)
                    .WithMany(p => p.TaskIdUserAcceptNavigations)
                    .HasForeignKey(d => d.IdUserAccept);

                entity.HasOne(d => d.IdUserCreateNavigation)
                    .WithMany(p => p.TaskIdUserCreateNavigations)
                    .HasForeignKey(d => d.IdUserCreate);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Family).HasColumnName("family");

                entity.Property(e => e.Foto).HasColumnName("foto");

                entity.Property(e => e.Lastname).HasColumnName("lastname");

                entity.Property(e => e.Login).HasColumnName("login");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Password).HasColumnName("password");

                entity.Property(e => e.Phone).HasColumnName("phone");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
