using Hogwarts.Domain.Mapper;
using Hogwarts.Domain.Model.Home;
using Hogwarts.Domain.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hogwarts.Domain.Service
{
    public interface IHomeService
    {
        Task<List<HomeModel>> FindAllHome();
    }

    public class HomeService : IHomeService
    {
        private readonly IHomeRepository _homeRepository;

        public HomeService(IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }

        public async Task<List<HomeModel>> FindAllHome()
        {
            var homeList = await _homeRepository.FindAllHome();
            var mapped = ObjectMapper.Mapper.Map<List<HomeModel>>(homeList);

            return mapped;
        }

    }
}
