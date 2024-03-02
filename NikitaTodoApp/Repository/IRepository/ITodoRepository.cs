using NikitaTodoApp.Models;

namespace NikitaTodoApp.Repository.IRepository
{
    public interface ITodoRepository : IRepository<Todo>
    {
        void Update(Todo todo);
    }
}
