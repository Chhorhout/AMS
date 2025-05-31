using System.ComponentModel.DataAnnotations;

namespace AMS.Api.Models
{
    public class Assets
    {
        public Guid AssetId { get; set; }
        public string AssetName { get; set; }
        public string AssetSerialNumber { get; set; }
         public bool HaveWarranty { get; set; }
        public DateTime? WarrantyStartDate { get; set; }
        public DateTime? WarrantyEndDate { get; set; }
        
    }
}