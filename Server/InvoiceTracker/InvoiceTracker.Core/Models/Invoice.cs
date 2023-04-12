using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceTracker.Core.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public DateTime Date { get; set; }

        public int Amount { get; set; }

        public int ProjectId { get; set; }

        public Project Project { get; set; }    

        public string InvoicePath { get; set; }
    }
}
