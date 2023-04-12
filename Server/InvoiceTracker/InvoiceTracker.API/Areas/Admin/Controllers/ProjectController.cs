using InvoiceTracker.Application.Services;
using InvoiceTracker.Core.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceTracker.API.Areas.Admin.Controllers
{
    public class ProjectController : AdminBaseController
    {
        private readonly ProjectService _projectService;

        public ProjectController(ProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
        {
            var res = await _projectService.GetAllProjectsAsync();
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIDProject(int id)
        {
            var res = await _projectService.GetByIdProjectAsync(id);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> AddProject(AddProjectDto dto)
        {
            var res = await _projectService.AddProjectAsync(dto);
            return Ok(res);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProject(AddProjectDto dto, int id)
        {
            var res = await _projectService.UpdateProjectAsync(dto, id);
            return Ok(res);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var res = await _projectService.DeleteProjectAsync(id);
            return Ok(res);
        }
    }
}
