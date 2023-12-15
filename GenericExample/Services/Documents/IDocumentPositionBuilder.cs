namespace GenericExample.Services.Documents
{
    internal interface IDocumentPositionBuilder<in TPositionCreate,out TPositionResult>
    {
        Task BuildAsync(TPositionCreate model);
        Task BulkBuildAsync(IEnumerable<TPositionCreate> model);
        TPositionResult GetResult();
        IEnumerable<TPositionResult> GetResults();
    }
}
