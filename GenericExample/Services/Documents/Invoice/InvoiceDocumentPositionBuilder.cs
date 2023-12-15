using GenericExample.Core.Documents.Incoming;

namespace GenericExample.Services.Documents.Invoice
{
    internal class InvoiceDocumentPositionBuilder : IDocumentPositionBuilder<CreateInvoiceDocumentPositionModel, InvoiceDocumentPosition>
    {
        private InvoiceDocumentPosition _incomingDocumentPosition;

        public async Task BuildAsync(CreateInvoiceDocumentPositionModel model)
        {
            _incomingDocumentPosition = new InvoiceDocumentPosition
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

        public Task BulkBuildAsync(IEnumerable<CreateInvoiceDocumentPositionModel> model)
        {
            throw new NotImplementedException();
        }

        public InvoiceDocumentPosition GetResult()
        {
            return _incomingDocumentPosition;
        }

        public IEnumerable<InvoiceDocumentPosition> GetResults()
        {
            throw new NotImplementedException();
        }
    }
}
