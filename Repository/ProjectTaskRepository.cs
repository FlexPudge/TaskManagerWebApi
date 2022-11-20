using TaskManagerWebApi.Interface;
using TaskManagerWebApi.Model;

namespace TaskManagerWebApi.Repository
{
    public class ProjectTaskRepository : IRepository<ProjectTask>
    {
        private readonly DataContext _context;
        public ProjectTaskRepository(DataContext context)
        {
            _context = context;
        }
        public void Create(ProjectTask projectTask)
        {
            _context.ProjectTasks!.Add(projectTask);
        }
        public void Delete(int id)
        {
            var projectTask = _context.ProjectTasks!.Find(id);
            _context.ProjectTasks!.Remove(projectTask!);
        }
        public ProjectTask GetByID(int id)
        {
            return _context.ProjectTasks!.Find(id)!;
        }
        public List<ProjectTask> GetList()
        {
            return _context.ProjectTasks!.ToList();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public void Update(ProjectTask projectTask)
        {
            try
            {
                _context.Entry(projectTask).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(nameof(projectTask), ex.Message);
            }
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
