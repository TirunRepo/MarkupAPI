namespace Markup.Common.RequestModels
{
    public class MarkupCalculationRequest
    {
        public int? SupplierId { get; set; }
        public int? SailingId { get; set; }
        public decimal BaseFare { get; set; }
        public DateTime BookingDate { get; set; }
    }
}
