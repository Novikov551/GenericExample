using GenericExample.Core.Documents.Incoming;
using GenericExample.Core.Documents;

namespace GenericExample.Services.Documents.Invoice
{
    internal class InvoiceDocumentBuilder : IDocumentBuilder<CreateInvoiceDocumentModel, InvoiceDocumentAgregate>
    {
        private InvoiceDocument _document;
        private List<InvoiceDocumentPosition> _positions;
        private readonly IDocumentPositionBuilder<CreateInvoiceDocumentPositionModel, InvoiceDocumentPosition> _documentPositionBuilder;
        private CreateInvoiceDocumentModel _source;

        public InvoiceDocumentBuilder(IDocumentPositionBuilder<CreateInvoiceDocumentPositionModel, InvoiceDocumentPosition> documentPositionBuilder)
        {
            _documentPositionBuilder = documentPositionBuilder;
        }

        public Task BuildAsync(CreateInvoiceDocumentModel createModel)
        {
            _source = createModel;
            _document = null;
            _positions = new List<InvoiceDocumentPosition>();


            BuildHeader()
                .BuildPositions();

            return Task.CompletedTask;
        }

        public InvoiceDocumentAgregate GetDocument()
        {
            return new InvoiceDocumentAgregate
            {
                IncomingDocument = _document,
                Positions = _positions,
            };
        }

        private InvoiceDocumentBuilder BuildHeader()
        {
            _document = new InvoiceDocument
            {
                Id = Guid.NewGuid(),
                DocumentType = DocumentType.Incoming,
                DocumentNumber = _source.DocumentNumber,
                DocumentDate = _source.DocumentDate,
                TotalAmount = _source.TotalAmount,
                ContractorNumber = _source.ContractorNumber,
                CreateDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
                Version = Guid.NewGuid()
            };

            return this;
        }

        private InvoiceDocumentBuilder BuildPositions()
        {
            foreach (var positionDto in _source.CreatePositionsModels)
            {
                _documentPositionBuilder.BuildAsync(new CreateInvoiceDocumentPositionModel
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

        public Task BulkBuildAsync(IEnumerable<CreateInvoiceDocumentModel> model)
        {
            throw new NotImplementedException();
        }

        public InvoiceDocumentAgregate GetResult()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InvoiceDocumentAgregate> GetResults()
        {
            throw new NotImplementedException();
        }
    }
}
