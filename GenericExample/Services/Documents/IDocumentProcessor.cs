using GenericExample.Core.Documents;

namespace GenericExample.Services.Documents
{
    internal interface IDocumentProcessor<TDocumentCreate, TDocumentUpdate>
    {
        DocumentType DocumentType { get; }
        Task<IEnumerable<Guid>> BulkCreateAsync(IEnumerable<TDocumentCreate> documents);
        Task<Guid> CreateDocumentAsync(TDocumentCreate document);
        Task BulkUpdateAsync(IEnumerable<TDocumentUpdate> documents);
        Task UpdateDocumentAsync(TDocumentUpdate document);
        Task BulkDeleteAsync(IEnumerable<Guid> documentsIds);
        Task DeleteDocumentAsync(Guid documentId);
    }
}
