using Hogwarts.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hogwarts.Domain.Repository
{
    public interface IRequestLoginRepository : IEntityRepository
    {
        Task<IEnumerable<RequestLogin>> FindAllRequestLogin();

        RequestLogin GetById(int id);
    }
}
