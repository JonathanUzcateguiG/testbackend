using System.Threading.Tasks;

namespace Hogwarts.DatabaseContext.Repository
{
    public abstract class AbstractRepository
    {
        protected ApplicationDbContext _dbContext;

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Add(object entity)
        {
            _dbContext.Add(entity);
        }

        public void Update(object entity)
        {
            _dbContext.Update(entity);
        }

        public void Delete(object entity)
        {
            _dbContext.Remove(entity);
        }
    }
}
