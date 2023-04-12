using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceTracker.Core.Dto
{
    public class ViewInvoiceDto
    {
        public int Id { get; set; }

        public string InvoiceNumber { get; set; }

        public DateTime Date { get; set;}

        public int Amount { get; set; }

        public string ProjectName { get; set; }

        public string ClientName { get; set; }

        public string InvoicePath { get; set; }
    }
}
