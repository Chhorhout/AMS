using System.ComponentModel.DataAnnotations;

namespace AMS.Api.Models
{
    public class Location
    {

        public Guid LocationId { get; set; }
        public string LocationName { get; set; }
        
    }
}