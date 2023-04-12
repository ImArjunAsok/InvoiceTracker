using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceTracker.Core.Dto
{
    public class AddInvoiceDto
    {
        public string InvoiceNumber { get; set; }

        public DateTime Date { get; set;}

        public int Amount { get; set; }

        public IFormFile InvoiceFile { get; set; }
    }
}
