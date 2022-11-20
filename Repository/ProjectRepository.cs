using TaskManagerWebApi.Interface;
using TaskManagerWebApi.Model;

namespace TaskManagerWebApi.Repository
{
    public class ProjectRepository : IRepository<Project>
    {
        private readonly DataContext _context;
        public ProjectRepository(DataContext context)
        {
            _context = context;
        }
        public void Create(Project project)
        {
            _context.Projects!.Add(project);
        }
        public void Delete(int id)
        {
            var project = _context.Projects!.Find(id);
            _context.Projects.Remove(project!);
        }
        public Project GetByID(int id)
        {
            return _context.Projects!.Find(id)!;
        }
        public List<Project> GetList()
        {
            return _context.Projects!.ToList();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public void Update(Project project)
        {
            try
            {
                _context.Entry(project).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(nameof(project), ex.Message);
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
