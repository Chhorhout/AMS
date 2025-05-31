using System.ComponentModel.DataAnnotations;

namespace AMS.Api.Dtos
{
    public class LocationCreateDto 
    {
        [MaxLength(100)]
        public string LocationName { get; set; }
        
    }

}