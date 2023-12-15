namespace GenericExample.Services.Documents
{
    internal interface IDocumentBuilder<in TCreateDocument,out TDocumentResult>
    {
        Task BuildAsync(TCreateDocument model);
        Task BulkBuildAsync(IEnumerable<TCreateDocument> model);
        TDocumentResult GetResult();
        IEnumerable<TDocumentResult> GetResults();
    }
}
