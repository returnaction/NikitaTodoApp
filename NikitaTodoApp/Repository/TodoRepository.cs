using NikitaTodoApp.Data;
using NikitaTodoApp.Models;
using NikitaTodoApp.Repository.IRepository;

namespace NikitaTodoApp.Repository
{
    public class TodoRepository : Repository<Todo>, ITodoRepository
    {
        private ApplicationDbContext _db;
        public TodoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Todo todo)
        {
            _db.Todos.Update(todo);
        }
    }
}
