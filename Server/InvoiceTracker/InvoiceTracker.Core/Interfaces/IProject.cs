using InvoiceTracker.Core.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceTracker.Core.Interfaces
{
    public interface IProject
    {
        Task<ServiceResponse<bool>> AddProjectAsync(AddProjectDto dto);

        Task<ServiceResponse<ViewProjectDto>> GetByIdProjectAsync(int projectId);

        Task<ServiceResponse<List<ViewProjectDto>>> GetAllProjectsAsync();

        Task<ServiceResponse<bool>> UpdateProjectAsync(AddProjectDto dto, int projectId);

        Task<ServiceResponse<bool>> DeleteProjectAsync(int projectId);
    }
}
