using GenericExample.Core.Documents.Sale;

namespace GenericExample.Services.Documents.Sale
{
    internal class SaleDocumentPositionBuilder : IDocumentPositionBuilder<CreateSaleDocumentPositionModel, SaleDocumentPosition>
    {
        private SaleDocumentPosition _saleDocumentPosition;

        public async Task BuildAsync(CreateSaleDocumentPositionModel model)
        {
            _saleDocumentPosition = new SaleDocumentPosition
            {
                Amount = model.Amount,
                Code = model.Code,
                CreateDate = DateTime.UtcNow,
                Id = Guid.NewGuid(),
                ModifiedDate = DateTime.UtcNow,
                Name = model.Name,
                Quantity = model.Quantity,
                UnitCode = model.UnitCode,
                Version = Guid.NewGuid(),
            };
        }

        public Task BulkBuildAsync(IEnumerable<CreateSaleDocumentPositionModel> model)
        {
            throw new NotImplementedException();
        }

        public SaleDocumentPosition GetResult()
        {
            return _saleDocumentPosition;
        }

        public IEnumerable<SaleDocumentPosition> GetResults()
        {
            throw new NotImplementedException();
        }
    }
}
