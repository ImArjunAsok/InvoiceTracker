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
    public class ProjectService : IProject
    {
        private readonly InvoiceTrackerDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProjectService(InvoiceTrackerDbContext db,
                              UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public async Task<ServiceResponse<bool>> AddProjectAsync(AddProjectDto dto)
        {
            var response = new ServiceResponse<bool>();
            var id = await _userManager.FindByEmailAsync(dto.UserEmail);
            try
            {
                var project = new Project()
                {
                    Name = dto.ProjectName,
                    Code = dto.ProjectCode,
                    Description = dto.Description,
                    ApplicationUserId = id.Id,
                    ClientId = dto.ClientId
                };
                _db.Project.Add(project);
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

        public async Task<ServiceResponse<ViewProjectDto>> GetByIdProjectAsync(int projectId)
        {
            var response = new ServiceResponse<ViewProjectDto>();
            var project = await _db.Project.FirstOrDefaultAsync(m=>m.Id == projectId);
            if (project != null )
            {
                response.Result = await _db.Project
                                 .Where(p => p.Id == projectId)
                                 .Select(p => new ViewProjectDto
                                  {
                                    Id = p.Id,
                                    ProjectCode = p.Code,
                                    ProjectName = p.Name,
                                    ProjectDescription = p.Description,
                                    ClientName = p.Client.Name,
                                    UserName = p.ApplicationUser.FirstName + " " + p.ApplicationUser.LastName
                                   }).FirstOrDefaultAsync();
            }
            else
                response.AddError("", "Project not found!");
            return response;
        }

        public async Task<ServiceResponse<List<ViewProjectDto>>> GetAllProjectsAsync()
        {
            var response = new ServiceResponse<List<ViewProjectDto>>();
            response.Result = await _db.Project
                .Select(d => new ViewProjectDto
                {
                    Id = d.Id,
                    ProjectName = d.Name,
                    ProjectCode = d.Code,
                    ProjectDescription = d.Description,
                    UserName = d.ApplicationUser.FirstName + ' ' + d.ApplicationUser.LastName,
                    ClientName = d.Client.Name
                }).ToListAsync();
            return response;
        }

        public async Task<ServiceResponse<bool>> UpdateProjectAsync(AddProjectDto dto, int projectId)
        {
            var project = await _db.Project.FirstOrDefaultAsync(m=>m.Id == projectId);
            if(project == null)
            {
                return new ServiceResponse<bool>()
                {
                    Result = false
                };  
            }
            var id = await _userManager.FindByEmailAsync(dto.UserEmail);
            project.Name = dto.ProjectName;
            project.Description = dto.Description;
            project.ApplicationUserId = id.Id;
            project.ClientId = dto.ClientId;
            await _db.SaveChangesAsync();

            return new ServiceResponse<bool>
            {
                Result = true
            };
        }

        public async Task<ServiceResponse<bool>> DeleteProjectAsync(int projectId)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                var project = await _db.Project.Where(m => m.Id == projectId).FirstOrDefaultAsync();
                _db.Project.Remove(project);
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
