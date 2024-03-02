using NikitaTodoApp.Data;
using NikitaTodoApp.Repository.IRepository;

namespace NikitaTodoApp.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public ITodoRepository Todo { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Todo = new TodoRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
