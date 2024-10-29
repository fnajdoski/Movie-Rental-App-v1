using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieRentalApp.DTOs;
using MovieRentalApp.Services;

namespace MovieRentalApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientDTO>>> GetAllClients()
        {
            var clients = await _clientService.GetAllClientsAsync();
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDTO>> GetClientById(int id)
        {
            var client = await _clientService.GetClientByIdAsync(id);
            if (client == null) return NotFound();
            return Ok(client);
        }

        [HttpPost]
        public async Task<ActionResult> AddClient(ClientDTO clientDto)
        {
            await _clientService.AddClientAsync(clientDto);
            return CreatedAtAction(nameof(GetClientById), new { id = clientDto.Id }, clientDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateClient(int id, ClientDTO clientDto)
        {
            if (id != clientDto.Id) return BadRequest();
            await _clientService.UpdateClientAsync(clientDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteClient(int id)
        {
            await _clientService.DeleteClientAsync(id);
            return NoContent();
        }
    }
}
