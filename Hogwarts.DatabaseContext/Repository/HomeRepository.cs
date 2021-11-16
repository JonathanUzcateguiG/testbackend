using Hogwarts.Domain.Entity;
using Hogwarts.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hogwarts.DatabaseContext.Repository
{
    public class HomeRepository : AbstractRepository, IHomeRepository
    {
        public HomeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Home>> FindAllHome()
        {
            return await _dbContext.Home.ToListAsync();
        }

    }
}
