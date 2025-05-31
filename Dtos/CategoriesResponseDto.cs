using System.ComponentModel.DataAnnotations;

namespace AMS.Api.Dtos
{
    public class CategoriesResponseDto
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}