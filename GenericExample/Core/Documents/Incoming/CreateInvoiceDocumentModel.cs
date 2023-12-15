namespace GenericExample.Core.Documents.Incoming
{
    internal class CreateInvoiceDocumentModel
    {
        public DateTime DocumentDate { get; set; }
        public long DocumentNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public DocumentType DocumentType { get; set; }
        public long ContractorNumber { get; set; }
        public IEnumerable<CreateInvoiceDocumentPositionModel> CreatePositionsModels { get; set; }
    }
}
