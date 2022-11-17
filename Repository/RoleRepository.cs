using TaskManagerWebApi.Interface;
using TaskManagerWebApi.Model;

namespace TaskManagerWebApi.Repository
{
    public class RoleRepository :IRepository<Role>
    {
        private readonly DataContext _context;
        public RoleRepository(DataContext context) 
        {
            _context = context;
        }
        public void Create(Role role)
        {
            try
            {
                _context.Roles!.Add(role);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(nameof(role), ex.Message);
            }
        }
        public void Delete(int id)
        {
            try
            {
                var roleToDelete = _context.Roles!.Find(id);
                _context.Roles!.Remove(roleToDelete!);
            }
            catch (Exception)
            {
                throw new ArgumentNullException(nameof(id), message: "ID cannot be null");
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
        public Role GetByID(int id)
        {
            try
            {
                return _context!.Roles!.Find(id)!;
            }
            catch (Exception)
            {

                throw;
            }
           
        }
        public List<Role> GetList()
        {
            return _context.Roles!.ToList();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public void Update(Role role)
        {
            try
            {
                _context.Entry(role).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(nameof(role), ex.Message);
            }
        }
    }
}
