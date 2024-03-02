namespace NikitaTodoApp.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ITodoRepository Todo { get; }

        void Save();
    }
}
