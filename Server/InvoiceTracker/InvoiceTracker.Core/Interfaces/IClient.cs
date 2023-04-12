using InvoiceTracker.Core.Dto;
using InvoiceTracker.Core.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceTracker.Core.Interfaces
{
    public interface IClient
    {
        Task<ServiceResponse<bool>> AddClientAsync(AddClientDto dto);

        Task<ServiceResponse<ViewClientDto>> GetByIdClientAsync(int clientId);

        Task<ServiceResponse<List<ViewClientDto>>> GetAllClientsAsync();

        Task<ServiceResponse<bool>> UpdateClientAsync(AddClientDto dto, int clientId);
        
        Task<ServiceResponse<bool>> DeleteClientAsync(int clientId);
    }
}
