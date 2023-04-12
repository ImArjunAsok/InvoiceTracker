namespace InvoiceTracker.Core.Dto
{
    public class ViewProjectDto
    {
        public int Id { get; set; }

        public string ProjectCode { get; set; }

        public string ProjectName { get; set; }

        public string? ProjectDescription { get; set; }

        public string UserName { get; set; }

        public string ClientName { get; set; }
    }
}
