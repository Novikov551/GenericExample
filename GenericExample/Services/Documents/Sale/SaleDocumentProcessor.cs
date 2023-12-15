using GenericExample.Core.Documents;
using GenericExample.Core.Documents.Incoming;
using Microsoft.Extensions.Logging;

namespace GenericExample.Services.Documents.Invoice
{
    internal class SaleDocumentProcessor : BaseDocumentProcessor<CreateInvoiceDocumentModel, IUpdateDocumentModel>
    {
        private readonly IDocumentBuilder<CreateInvoiceDocumentModel, InvoiceDocumentAgregate> _documentBuilder;
        public SaleDocumentProcessor(IDocumentBuilder<CreateInvoiceDocumentModel,InvoiceDocumentAgregate> builder,
            ILogger<BaseDocumentProcessor<CreateInvoiceDocumentModel, IUpdateDocumentModel>> logger)
            : base(logger)
        {
            _documentBuilder = builder;
        }

        public override DocumentType DocumentType => DocumentType.Incoming;

        protected override async Task<Guid> ProcessCreateDocumentAsync(CreateInvoiceDocumentModel model)
        {
            await _documentBuilder.BuildAsync(model);
            var documentAgregate = _documentBuilder.GetResult();

            return documentAgregate.IncomingDocument.Id;
        }
    }
}
