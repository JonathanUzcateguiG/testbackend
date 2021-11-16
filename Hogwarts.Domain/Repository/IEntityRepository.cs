using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hogwarts.Domain.Repository
{
    public interface IEntityRepository
    {
        void Add(object entity);
        void Update(object entity);
        void Delete(object entity);
        Task SaveChangesAsync();
    }
}
