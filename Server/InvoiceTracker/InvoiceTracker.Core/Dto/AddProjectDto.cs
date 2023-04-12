using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceTracker.Core.Dto
{
    public class AddProjectDto
    {
        public string ProjectName { get; set; }

        public string ProjectCode { get; set; }

        public string Description { get; set; }

        public string UserEmail { get; set; }

        public int ClientId { get; set; }
    }
}
