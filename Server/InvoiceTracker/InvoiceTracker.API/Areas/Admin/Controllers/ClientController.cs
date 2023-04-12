using InvoiceTracker.Application.Services;
using InvoiceTracker.Core.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceTracker.API.Areas.Admin.Controllers
{
    public class ClientController : AdminBaseController
    {
        private readonly ClientService _clientService;

        public ClientController (ClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
        {
            var res = await _clientService.GetAllClientsAsync();
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIDProject(int id)
        {
            var res = await _clientService.GetByIdClientAsync(id);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> AddProject(AddClientDto dto)
        {
            var res = await _clientService.AddClientAsync(dto);
            return Ok(res);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProject(AddClientDto dto, int id)
        {
            var res = await _clientService.UpdateClientAsync(dto, id);
            return Ok(res);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var res = await _clientService.DeleteClientAsync(id);
            return Ok(res);
        }
    }
}
