using System.Collections.Generic;
using System.Threading.Tasks;
using MovieRentalApp.DTOs;

namespace MovieRentalApp.Services
{
    public interface IClientService
    {
        Task<IEnumerable<ClientDTO>> GetAllClientsAsync();
        Task<ClientDTO> GetClientByIdAsync(int id);
        Task AddClientAsync(ClientDTO clientDto);
        Task UpdateClientAsync(ClientDTO clientDto);
        Task DeleteClientAsync(int id);
    }
}
