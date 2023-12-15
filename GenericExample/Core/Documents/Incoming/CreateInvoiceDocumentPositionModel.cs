namespace GenericExample.Core.Documents.Incoming
{
    internal class CreateInvoiceDocumentPositionModel
    {
        public Guid DocumentId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public double Quantity { get; set; }
        public double Amount { get; set; }
        public string UnitCode { get; set; }
    }
}
