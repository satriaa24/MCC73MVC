namespace MCC73MVC.Repositories.Interface
{
    public interface IRepositories <Entity, Key> where Entity : class
    {
        public IEnumerable<Entity> Get();
        public Entity Get(Key NIK);
        public int Insert(Entity entity);
        public int Update(Entity entity);
        public int Delete(Key NIK);
    }
}
