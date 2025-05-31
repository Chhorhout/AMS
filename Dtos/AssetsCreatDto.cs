using System.ComponentModel.DataAnnotations;

namespace AMS.Api.Dtos
{
    public class AssetsCreateDto
    {
        
        [MaxLength(100)]
        public string AssetName { get; set; }
        [MaxLength(50)]
        public string AssetSerialNumber { get; set; }
        public bool HaveWarranty { get; set; }
        public DateTime? WarrantyStartDate { get; set; }
        public DateTime? WarrantyEndDate { get; set; }
    }
}