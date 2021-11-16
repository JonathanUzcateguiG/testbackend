using Hogwarts.Domain.Entity;
using Hogwarts.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hogwarts.DatabaseContext.Repository
{
    public class RequestLoginRepository : AbstractRepository, IRequestLoginRepository
    {
        public RequestLoginRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<RequestLogin>> FindAllRequestLogin()
        {
            var query = _dbContext.RequestLogin
               .Include(u => u.Home);

            return await query.ToListAsync();
        }

        public RequestLogin GetById(int id)
        {
            var query = _dbContext.RequestLogin
                .Where(u => u.Id == id)
               .Include(u => u.Home);

            return query.FirstOrDefault();
        }

    }
}
