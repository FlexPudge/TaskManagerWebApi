using TaskManagerWebApi.Interface;
using TaskManagerWebApi.Model;

namespace TaskManagerWebApi.Repository
{
    public class TaskRepository : IRepository<Model.Task>
    {
        private readonly DataContext _context;
        public TaskRepository(DataContext dataContext)
        {
            _context = dataContext;
        }
        public void Create(Model.Task task)
        {
            try
            {
                _context.Tasks!.Add(task);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(nameof(task), ex.Message);
            }
        }
        public void Delete(int id)
        {
            var deleteTask = _context.Tasks!.Find(id);
            _context.Tasks!.Remove(deleteTask!);
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
        public Model.Task GetByID(int id)
        {
            try
            {
                return _context.Tasks!.Find(id)!;
            }
            catch (Exception)
            {
                throw new ArgumentNullException(nameof(id), message: "ID cannot be null");
            }
        }
        public List<Model.Task> GetList()
        {
            return _context.Tasks!.ToList();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public void Update(Model.Task task)
        {
            try
            {
                _context.Entry(task).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(nameof(task), ex.Message);
            }
        }
    }
}
