namespace GenericExample.Core
{
    internal class BaseEntity
    {
        public Guid Id { get; set; }
        public Guid Version { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
