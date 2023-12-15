namespace GenericExample.Core.Documents
{
    internal class BaseDocumentPosition : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public double Quantity { get; set; }
        public double Amount { get; set; }
        public string UnitCode { get; set; }
    }
}
