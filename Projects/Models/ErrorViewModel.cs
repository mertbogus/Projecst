using Xunit.Abstractions;

namespace Projects.Models
{
    public class ErrorViewModel
    {
       
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}