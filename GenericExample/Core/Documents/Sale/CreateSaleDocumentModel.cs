namespace GenericExample.Core.Documents.Sale
{
    internal class CreateSaleDocumentModel
    {
        public DateTime DocumentDate { get; set; }
        public long DocumentNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public DocumentType DocumentType { get; set; }
        public IEnumerable<CreateSaleDocumentPositionModel> CreatePositionsModels { get; set; }
    }
}
