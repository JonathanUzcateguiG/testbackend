using Hogwarts.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hogwarts.Domain.Repository
{
    public interface IHomeRepository : IEntityRepository
    {
        Task<IEnumerable<Home>> FindAllHome();
    }
}
