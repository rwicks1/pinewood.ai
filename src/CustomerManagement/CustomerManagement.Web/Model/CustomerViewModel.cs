using System.Text.Json.Serialization;

namespace CustomerManagement.Web.Model
{
    public class CustomerViewModel
    {
        public int? Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
