namespace GenericExample.Core.Documents
{
    internal class BaseDocument : BaseEntity
    {
        public DateTime DocumentDate { get; set; }
        public long DocumentNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public DocumentType DocumentType { get; set; }
    }
}
