using Microsoft.EntityFrameworkCore;
using Task = TaskManagerWebApi.Model.Task;

namespace TaskManagerWebApi.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Task>? Tasks { get; set; }
        public DbSet<Project>? Projects { get; set; }
        public DbSet<ProjectTask>? ProjectTasks { get; set; }
        public DbSet<Role>? Roles { get; set; }
        public DbSet<Status>? Statuses { get; set; }
        public DbSet<User>? Users { get; set; }
        
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

    }
}
