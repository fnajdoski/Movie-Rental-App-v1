using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieRentalApp.DTOs;
using MovieRentalApp.Models;
using MovieRentalApp.Repositories;

namespace MovieRentalApp.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClientDTO>> GetAllClientsAsync()
        {
            var clients = await _clientRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ClientDTO>>(clients);
        }

        public async Task<ClientDTO> GetClientByIdAsync(int id)
        {
            var client = await _clientRepository.GetByIdAsync(id);
            return _mapper.Map<ClientDTO>(client);
        }

        public async Task AddClientAsync(ClientDTO clientDto)
        {
            var client = _mapper.Map<Client>(clientDto);
            await _clientRepository.AddAsync(client);
        }

        public async Task UpdateClientAsync(ClientDTO clientDto)
        {
            var client = _mapper.Map<Client>(clientDto);
            await _clientRepository.UpdateAsync(client);
        }

        public async Task DeleteClientAsync(int id)
        {
            await _clientRepository.DeleteAsync(id);
        }
    }
}
