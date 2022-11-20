using TaskManagerWebApi.Interface;
using TaskManagerWebApi.Model;

namespace TaskManagerWebApi.Repository
{
    public class StatusRepository : IRepository<Status>
    {
        private readonly DataContext _context;
        public StatusRepository(DataContext context)
        {
            _context = context;
        }
        public void Create(Status status)
        {
            _context.Statuses!.Add(status);
        }
        public void Delete(int id)
        {
            var status = _context.Statuses!.Find(id)!;
            _context.Statuses!.Remove(status);
        }
        public Status GetByID(int id)
        {
            return _context.Statuses!.Find(id)!;
        }
        public List<Status> GetList()
        {
            return _context.Statuses!.ToList();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public void Update(Status status)
        {
            try
            {
                _context.Entry(status).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(nameof(status), ex.Message);
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
