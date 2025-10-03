using System.ComponentModel.DataAnnotations;

namespace AMS.Api.Dtos
{
    public class AssetCreateDto
    {
        
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string SerialNumber { get; set; }
        public bool HasWarranty { get; set; }
        public DateTime? WarrantyStartDate { get; set; }
        public DateTime? WarrantyEndDate { get; set; }
        public Guid SupplierId { get; set; }
        public Guid LocationId { get; set; }
        public Guid AssetTypeId { get; set; }
        public Guid InvoiceId { get; set; }
        public Guid AssetStatusHistoryId { get; set; }
        public Guid TemporaryUsedRequestId { get; set; }
    }
}