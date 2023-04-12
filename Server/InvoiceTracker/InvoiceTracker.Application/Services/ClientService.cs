using InvoiceTracker.Core.Dto;
using InvoiceTracker.Core.Interfaces;
using InvoiceTracker.Core.Models;
using InvoiceTracker.Core.Type;
using InvoiceTracker.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceTracker.Application.Services
{
    public class ClientService : IClient
    {
        private readonly InvoiceTrackerDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public ClientService(InvoiceTrackerDbContext db,
                              UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public async Task<ServiceResponse<bool>> AddClientAsync(AddClientDto dto)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                var client = new Client()
                {
                    Name = dto.Name,
                    Address = dto.Address
                };
                _db.Client.Add(client);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.AddError("", ex.ToString());
                response.Result = false;
                return response;
            }
            response.Result = true;
            return response;
        }

        public async Task<ServiceResponse<ViewClientDto>> GetByIdClientAsync(int clientId)
        {
            var response = new ServiceResponse<ViewClientDto>();
            var client = await _db.Client.FirstOrDefaultAsync(m => m.Id == clientId);
            if (client != null)
            {
                response.Result = await _db.Client
                                 .Where(p => p.Id == clientId)
                                 .Select(p => new ViewClientDto
                                 {
                                     Id = p.Id,
                                     Name = p.Name,
                                     Address = p.Address
                                 }).FirstOrDefaultAsync();
            }
            else
                response.AddError("", "Client not found!");
            return response;
        }

        public async Task<ServiceResponse<List<ViewClientDto>>> GetAllClientsAsync()
        {
            var response = new ServiceResponse<List<ViewClientDto>>();
            response.Result = await _db.Client
                .Select(d => new ViewClientDto
                {
                    Id = d.Id,
                    Name = d.Name,
                    Address = d.Address
                }).ToListAsync();
            return response;
        }

        public async Task<ServiceResponse<bool>> UpdateClientAsync(AddClientDto dto, int clientId)
        {
            var client = await _db.Client.FirstOrDefaultAsync(m => m.Id == clientId);
            if (client == null)
            {
                return new ServiceResponse<bool>()
                {
                    Result = false
                };
            }
            client.Name = dto.Name;
            client.Address = dto.Address;
            await _db.SaveChangesAsync();
            return new ServiceResponse<bool>
            {
                Result = true
            };
        }

        public async Task<ServiceResponse<bool>> DeleteClientAsync(int clientId)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                var client = await _db.Client.Where(m => m.Id == clientId).FirstOrDefaultAsync();
                _db.Client.Remove(client);
                _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.AddError("", "Error in deleting the project");
                response.Result = false;
                return response;
            }
            response.Result = true;
            return response;
        }
    }
}
