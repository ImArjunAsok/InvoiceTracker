using InvoiceTracker.Core.Models;
using InvoiceTracker.Core.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceTracker.Core.Interfaces
{
    public interface IApplicationUser
    {
        Task<ServiceResponse<bool>> RegisterUserAsync(RegisterDto dto);

        //Task<ServiceResponse<string>> LoginAsync(LoginDto dto);

        //Task<ServiceResponse<bool>> SendOtpAsync(RegisterDto dto);

        //public string GenerateToken(ApplicationUser user);
    }
}
