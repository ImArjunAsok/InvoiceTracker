using InvoiceTracker.Core.Dto;
using InvoiceTracker.Core.Interfaces;
using InvoiceTracker.Core.Models;
using InvoiceTracker.Core.Type;
using InvoiceTracker.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceTracker.Application.Services
{
    public class ApplicationUserService : IApplicationUser
    {
        private readonly InvoiceTrackerDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationUserService(InvoiceTrackerDbContext db,
                                      UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public async Task<ServiceResponse<bool>> RegisterUserAsync(RegisterDto dto)
        {
            var user = new ApplicationUser()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                UserName = Guid.NewGuid().ToString(),
                PhoneNumber = dto.PhoneNumber,
            };
            var userStatus = await _userManager.CreateAsync(user, dto.Password);
            if (!userStatus.Succeeded)
            {
                return new ServiceResponse<bool>
                {
                    Result = false
                };
            }
            await _db.SaveChangesAsync();
            return new ServiceResponse<bool>
            {
                Result = true
            };
        }
    }
}
