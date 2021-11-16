using Hogwarts.Domain.Entity;
using Hogwarts.Domain.Mapper;
using Hogwarts.Domain.Model.RequestLogin;
using Hogwarts.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Hogwarts.Domain.Service
{
    public interface IRequestLoginService
    {
        Task<List<RequestLoginModel>> FindAllRequestLogin();
        Task<RequestLoginModel> Delete(int id);
        Task<RequestLoginModel> Create(CreateRequestLoginDto createRequestLoginDto);
        Task<RequestLoginModel> Update(UpdateRequestLoginDto updateRequestLoginDto);
    }
    public class RequestLoginService : IRequestLoginService
    {
        private readonly IRequestLoginRepository _requestLoginRepository;

        public RequestLoginService(IRequestLoginRepository requestLoginRepository)
        {
            _requestLoginRepository = requestLoginRepository;
        }

        public async Task<List<RequestLoginModel>> FindAllRequestLogin()
        {
            var requestLoginList = await _requestLoginRepository.FindAllRequestLogin();
            var mapped = ObjectMapper.Mapper.Map<List<RequestLoginModel>>(requestLoginList);

            return mapped;
        }

        public async Task<RequestLoginModel> Create(CreateRequestLoginDto createRequestLoginDto)
        {
            if(createRequestLoginDto.Name.Length > 20)
                throw new ApplicationException($"Name cannot be longer than 20 characters");

            if (createRequestLoginDto.LastName.Length > 20)
                throw new ApplicationException($"Last Name cannot be longer than 20 characters");

            if (createRequestLoginDto.Identification.ToString().Length > 10)
                throw new ApplicationException($"Identification cannot be longer than 10 characters");

            if (createRequestLoginDto.Age.ToString().Length > 2)
                throw new ApplicationException($"Age cannot be longer than 2 characters");

            var mappedEntity = ObjectMapper.Mapper.Map<RequestLogin>(createRequestLoginDto);
            if (mappedEntity == null)
                throw new ApplicationException($"Entity could not be mapped.");

            _requestLoginRepository.Add(mappedEntity);
            await _requestLoginRepository.SaveChangesAsync();

            var newMappedEntity = ObjectMapper.Mapper.Map<RequestLoginModel>(mappedEntity);
            return newMappedEntity;
        }

        public async Task<RequestLoginModel> Update(UpdateRequestLoginDto updateRequestLoginDto)
        {

            if (updateRequestLoginDto.Name.Length > 20)
                throw new ApplicationException($"Name cannot be longer than 20 characters");

            if (updateRequestLoginDto.LastName.Length > 20)
                throw new ApplicationException($"Last Name cannot be longer than 20 characters");

            if (updateRequestLoginDto.Identification.ToString().Length > 10)
                throw new ApplicationException($"Identification cannot be longer than 10 characters");

            if (updateRequestLoginDto.Age.ToString().Length > 2)
                throw new ApplicationException($"Age cannot be longer than 2 characters");

            var mappedEntity = ObjectMapper.Mapper.Map<RequestLogin>(updateRequestLoginDto);
            if (mappedEntity == null)
                throw new ApplicationException($"Entity could not be mapped.");

            _requestLoginRepository.Update(mappedEntity);
            await _requestLoginRepository.SaveChangesAsync();

            var newMappedEntity = ObjectMapper.Mapper.Map<RequestLoginModel>(mappedEntity);
            return newMappedEntity;
        }

        public async Task<RequestLoginModel> Delete(int id)
        {
            var entity = _requestLoginRepository.GetById(id);

            if (entity == null)
                throw new ApplicationException($"Entity not found.");
            _requestLoginRepository.Delete(entity);
            await _requestLoginRepository.SaveChangesAsync();

            var newMappedEntity = ObjectMapper.Mapper.Map<RequestLoginModel>(entity);
            return newMappedEntity;
        }
    }
}
