using GenericExample.Constants;
using GenericExample.Core.Documents;
using Microsoft.Extensions.Logging;

namespace GenericExample.Services.Documents
{
    internal abstract class BaseDocumentProcessor<TDocumentCreate, TDocumentUpdate> : IDocumentProcessor<TDocumentCreate, TDocumentUpdate>
         where TDocumentUpdate : IUpdateDocumentModel
    {
        private readonly ILogger<BaseDocumentProcessor<TDocumentCreate, TDocumentUpdate>> _logger;

        public BaseDocumentProcessor(ILogger<BaseDocumentProcessor<TDocumentCreate, TDocumentUpdate>> logger)
        {
            _logger = logger;
        }

        public abstract DocumentType DocumentType { get; }

        #region Create

        public async Task<IEnumerable<Guid>> BulkCreateAsync(IEnumerable<TDocumentCreate> documents)
        {
            try
            {
                return await ProcessBulkCreateAsync(documents);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, DocumentErrors.DocumentsCreateError);
                throw;
            }
        }

        protected virtual async Task<IEnumerable<Guid>> ProcessBulkCreateAsync(IEnumerable<TDocumentCreate> documents)
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> CreateDocumentAsync(TDocumentCreate document)
        {
            try
            {
                return await ProcessCreateDocumentAsync(document);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, DocumentErrors.DocumentCreateError);
                throw;
            }
        }

        protected virtual async Task<Guid> ProcessCreateDocumentAsync(TDocumentCreate document)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Update

        public async Task BulkUpdateAsync(IEnumerable<TDocumentUpdate> models)
        {
            try
            {
                await ProcessBulkUpdateAsync(models);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, DocumentErrors.DocumentsUpdateError);
                throw;
            }
        }

        protected virtual async Task ProcessBulkUpdateAsync(IEnumerable<TDocumentUpdate> models)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateDocumentAsync(TDocumentUpdate model)
        {
            try
            {
                await ProcessUpdateDocumentAsync(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, DocumentErrors.DocumentUpdateError);
                throw;
            }
        }

        protected virtual async Task ProcessUpdateDocumentAsync(TDocumentUpdate model)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Delete

        public async Task BulkDeleteAsync(IEnumerable<Guid> documentsIds)
        {
            try
            {
                await ProcessBulkDeleteAsync(documentsIds);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, DocumentErrors.DocumentsDeleteError);
                throw;
            }
        }

        protected virtual async Task ProcessBulkDeleteAsync(IEnumerable<Guid> documentsIds)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteDocumentAsync(Guid documentId)
        {
            try
            {
                await ProcessDeleteDocumentAsync(documentId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, DocumentErrors.DocumentDeleteError);
                throw;
            }
        }

        protected virtual async Task ProcessDeleteDocumentAsync(Guid documentId)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}
