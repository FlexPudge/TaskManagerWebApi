using System.Net.WebSockets;
using TaskManagerWebApi.Interface;

namespace TaskManagerWebApi.Repository
{
    public class UserRepository : IRepository<User>
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public void Create(User user)
        {
            try
            {
                _context.Users!.Add(user);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(nameof(user), ex.Message);
            }
        }
        public void Delete(int id)
        {
            try
            {
                var userToDelete = _context.Users!.Find(id);
                _context.Users!.Remove(userToDelete!);
            }
            catch (Exception)
            {
                throw new ArgumentNullException(nameof(id), message: "ID cannot be null");
            }
        }
        public User GetUserByID(int id)
        {
            try
            {
                return _context.Users!.Find(id)!;
            }
            catch (Exception)
            {
                throw new ArgumentNullException(nameof(id), message: "ID cannot be null");
            }
        }
        public List<User> GetUsersList()
        {
            return _context.Users!.ToList();
        }
        public void Update(User user)
        {
            try
            {
                _context.Entry(user).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(nameof(user), ex.Message);
            }
        }
        public void Save()
        {
            _context.SaveChanges();
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
