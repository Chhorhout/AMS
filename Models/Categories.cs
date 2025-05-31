using System.ComponentModel.DataAnnotations;

namespace AMS.Api.Models
{
    public class Categories
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}