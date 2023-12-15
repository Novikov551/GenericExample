namespace GenericExample.Core.Documents.Incoming
{
    internal class InvoiceDocumentAgregate
    {
        public InvoiceDocument IncomingDocument { get; set; }
        public List<InvoiceDocumentPosition> Positions { get; set; }
    }
}
