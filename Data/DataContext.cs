using Microsoft.EntityFrameworkCore;

namespace TaskManagerWebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { 
        }
        public DbSet<Model.Task>? Tasks { get; set; }
        public DbSet<Model.Project>? Projects { get; set; }
        public DbSet<Model.ProjectTask>? ProjectTasks { get; set; }
        public DbSet<Model.Role>? Roles { get; set; }
        public DbSet<Model.Status>? Statuses { get; set; }
        public DbSet<Model.User>? Users { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<Model.Task>().HasMany(x => x.ProjectTasks).WithOne(z => z.IdtaskNavigation).HasForeignKey(x => x.Id);
           // builder.Entity<Model.Project>().HasMany(x => x.ProjectTasks).WithOne(z => z.IdprojectNavigation).HasForeignKey(x => x.Id);
        }
    }
}
