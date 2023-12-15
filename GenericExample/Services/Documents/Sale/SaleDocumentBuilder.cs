using GenericExample.Core.Documents;
using GenericExample.Core.Documents.Sale;

namespace GenericExample.Services.Documents.Sale
{
    internal class SaleDocumentBuilder : IDocumentBuilder<CreateSaleDocumentModel, SaleDocumentAgregate>
    {
        private SaleDocument _document;
        private List<SaleDocumentPosition> _positions;
        private readonly IDocumentPositionBuilder<CreateSaleDocumentPositionModel, SaleDocumentPosition> _documentPositionBuilder;
        private CreateSaleDocumentModel _source;

        public SaleDocumentBuilder(IDocumentPositionBuilder<CreateSaleDocumentPositionModel, SaleDocumentPosition> documentPositionBuilder)
        {
            _documentPositionBuilder = documentPositionBuilder;
        }

        public Task BuildAsync(CreateSaleDocumentModel createModel)
        {
            _source = createModel;
            _document = null;
            _positions = new List<SaleDocumentPosition>();


            BuildHeader()
                .BuildPositions();

            return Task.CompletedTask;
        }

        public SaleDocumentAgregate GetDocument()
        {
            return new SaleDocumentAgregate
            {
                SaleDocument = _document,
                Positions = _positions,
            };
        }

        private SaleDocumentBuilder BuildHeader()
        {
            _document = new SaleDocument
            {
                Id = Guid.NewGuid(),
                DocumentType = DocumentType.Sale,
                DocumentNumber = _source.DocumentNumber,
                DocumentDate = _source.DocumentDate,
                TotalAmount = _source.TotalAmount,
                CreateDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
                Version = Guid.NewGuid()
            };

            return this;
        }

        private SaleDocumentBuilder BuildPositions()
        {
            foreach (var positionDto in _source.CreatePositionsModels)
            {
                _documentPositionBuilder.BuildAsync(new CreateSaleDocumentPositionModel
                {
                    Amount = positionDto.Amount,
                    Code = positionDto.Code,
                    DocumentId = positionDto.DocumentId,
                    Name = positionDto.Name,
                    Quantity = positionDto.Quantity,
                    UnitCode = positionDto.UnitCode,
                });

                _positions.Add(_documentPositionBuilder.GetResult());
            }

            return this;
        }

        public Task BulkBuildAsync(IEnumerable<CreateSaleDocumentModel> model)
        {
            throw new NotImplementedException();
        }

        public SaleDocumentAgregate GetResult()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SaleDocumentAgregate> GetResults()
        {
            throw new NotImplementedException();
        }
    }
}
