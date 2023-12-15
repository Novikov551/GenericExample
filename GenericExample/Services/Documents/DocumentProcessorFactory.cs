using GenericExample.Core.Documents;
using Microsoft.Extensions.DependencyInjection;

namespace GenericExample.Services.Documents
{
    internal class DocumentProcessorFactory
    {
        private readonly IServiceProvider _provider;

        public DocumentProcessorFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IDocumentProcessor<TCreateModel, TUpdateModel> GetDocumentProcessor<TCreateModel, TUpdateModel>(DocumentType documentType)
        {
            return _provider.GetServices<IDocumentProcessor<TCreateModel, TUpdateModel>>().Single(d => d.DocumentType == documentType);
        }
    }
}
