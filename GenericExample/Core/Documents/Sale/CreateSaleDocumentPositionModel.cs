namespace GenericExample.Core.Documents.Sale
{
    internal class CreateSaleDocumentPositionModel
    {
        public Guid DocumentId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public double Quantity { get; set; }
        public double Amount { get; set; }
        public string UnitCode { get; set; }
    }
}
