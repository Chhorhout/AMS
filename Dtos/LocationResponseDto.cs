using System.ComponentModel.DataAnnotations;

namespace AMS.Api.Dtos
{
    public class LocationResponseDto
    {
        public Guid LocationId { get; set; }
        public string LocationName { get; set; }
    }
}