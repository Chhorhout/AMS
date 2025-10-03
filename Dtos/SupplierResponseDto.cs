using System.ComponentModel.DataAnnotations;
namespace AMS.Api.Dtos
{
    public class SupplierResponseDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
