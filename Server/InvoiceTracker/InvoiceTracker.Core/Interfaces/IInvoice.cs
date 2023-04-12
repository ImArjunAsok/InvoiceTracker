using InvoiceTracker.Core.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceTracker.Core.Interfaces
{
    public interface IInvoice
    {
        Task<ServiceResponse<bool>> AddInvoiceAsync(AddInvoiceDto dto);

        Task<ServiceResponse<ViewProjectDto>> GetByProjectIdInvoiceAsync(int projectId);

        Task<ServiceResponse<ViewProjectDto>> GetAllInvoiceAsync();

        Task<ServiceResponse<bool>> UpdateInvoiceAsync(ViewInvoiceDto dto, int invoiceId);

        Task<ServiceResponse<bool>> DeleteInvoiceAsync(int invoiceId);
    }
}
