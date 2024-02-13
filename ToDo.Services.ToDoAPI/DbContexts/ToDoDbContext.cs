using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ToDo.Services.ToDoAPI.Models;

namespace ToDo.Services.ToDoAPI.DbContexts
{
    public class ToDoDbContext: DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options) { }

        public DbSet<TaskOrder> Tasks { get; set; }
        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TaskOrder>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("task_pkey");
                entity.ToTable("Tasks");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name").HasMaxLength(100);
                entity.Property(e => e.Description).HasColumnName("description").HasMaxLength(255);
                entity.HasOne(e => e.Status).WithMany(entity => entity.Tasks);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.Status_Id).HasName("status_pkey");
                entity.ToTable("Statuses");
                entity.Property(e => e.Status_Id).HasColumnName("statusId");
                entity.Property(e => e.StatusName).HasColumnName("statusName");
            });

            modelBuilder.Entity<Status>().HasData(new Status
            {
                Status_Id = 1,
                StatusName = "Создана"
            });
            modelBuilder.Entity<Status>().HasData(new Status
            {
                Status_Id = 2,
                StatusName = "В работе"
            });
            modelBuilder.Entity<Status>().HasData(new Status
            {
                Status_Id = 3,
                StatusName = "Завершена"
            });
 

        }


    }
}
