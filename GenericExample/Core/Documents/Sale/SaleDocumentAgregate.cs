namespace GenericExample.Core.Documents.Sale
{
    internal class SaleDocumentAgregate
    {
        public SaleDocument SaleDocument { get; set; }
        public List<SaleDocumentPosition> Positions { get; set; }
    }
}
