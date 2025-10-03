using System.ComponentModel.DataAnnotations;

namespace AMS.Api.Dtos
{
    public class MaintainerTypeCreateDto
    {
        public string Name { get; set; }
        public Guid MaintainerId { get; set; }
    }
}