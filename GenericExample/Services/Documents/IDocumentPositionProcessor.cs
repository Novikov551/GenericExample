using GenericExample.Core.Documents;

namespace GenericExample.Services.Documents
{
    public interface IDocumentPositionProcessor<TPositionCreate, TPositionUpdate>
    {
        DocumentType DocumentType { get; }
        Task<IEnumerable<Guid>> BulkCreateAsync(IEnumerable<TPositionCreate> models);
        Task<Guid> CreatePositionAsync(TPositionCreate model);
        Task BulkUpdateAsync(IEnumerable<TPositionUpdate> models);
        Task UpdatePositionAsync(TPositionUpdate model);
        Task BulkDeleteAsync(IEnumerable<Guid> positionsIds);
        Task DeletePositionAsync(Guid positionId);
    }
}
