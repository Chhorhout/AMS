using System.ComponentModel.DataAnnotations;

namespace AMS.Api.Dtos
{
    public class CategoriesCreateDto
    {
        [MaxLength(100)]
        public string CategoryName { get; set; }
    }
}