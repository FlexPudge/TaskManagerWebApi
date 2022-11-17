using TaskManagerWebApi.Interface;

namespace TaskManagerWebApi.Repository
{
    public class UserObjectRepository : IRepository<User>
    {
        private readonly DataContext _context;
        public UserObjectRepository(DataContext context)
        {
            this._context = context;
        }
        public void Create(User item)
        {
            throw new NotImplementedException();
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        public User GetUser(int id)
        {
            throw new NotImplementedException();
        }
        public List<User> GetUsersList()
        {
            return _context.Users!.ToList();
        }
        public void Update(User item)
        {
            throw new NotImplementedException();
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
