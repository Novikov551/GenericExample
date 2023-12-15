using GenericExample.Constants;
using GenericExample.Core.Documents;
using Microsoft.Extensions.Logging;

namespace GenericExample.Services.Documents
{
    internal abstract class BaseDocumentPositionProcessor<TPositionCreate, TPositionUpdate> : IDocumentPositionProcessor<TPositionCreate, TPositionUpdate>
         where TPositionUpdate : IUpdateDocumentPositionModel
    {
        private readonly ILogger<BaseDocumentPositionProcessor<TPositionCreate, TPositionUpdate>> _logger;

        public BaseDocumentPositionProcessor(ILogger<BaseDocumentPositionProcessor<TPositionCreate, TPositionUpdate>> logger)
        {
            _logger = logger;
        }

        public abstract DocumentType DocumentType { get; }

        #region Create

        public async Task<IEnumerable<Guid>> BulkCreateAsync(IEnumerable<TPositionCreate> models)
        {
            try
            {
                return await ProcessBulkCreateAsync(models);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, DocumentErrors.DocumentPositionsCreateError);
                throw;
            }
        }

        protected virtual async Task<IEnumerable<Guid>> ProcessBulkCreateAsync(IEnumerable<TPositionCreate> models)
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> CreatePositionAsync(TPositionCreate model)
        {
            try
            {
                return await ProcessCreatePositionAsync(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, DocumentErrors.DocumentPositionCreateError);
                throw;
            }
        }

        protected virtual async Task<Guid> ProcessCreatePositionAsync(TPositionCreate model)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Update

        public async Task BulkUpdateAsync(IEnumerable<TPositionUpdate> models)
        {
            try
            {
                await ProcessBulkUpdateAsync(models);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, DocumentErrors.DocumentPositionsUpdateError);
                throw;
            }
        }

        protected virtual async Task ProcessBulkUpdateAsync(IEnumerable<TPositionUpdate> models)
        {
            throw new NotImplementedException();
        }

        public async Task UpdatePositionAsync(TPositionUpdate model)
        {
            try
            {
                await ProcessUpdatePositionAsync(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, DocumentErrors.DocumentPositionUpdateError);
                throw;
            }
        }

        protected virtual async Task ProcessUpdatePositionAsync(TPositionUpdate model)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Delete

        public async Task BulkDeleteAsync(IEnumerable<Guid> positionsIds)
        {
            try
            {
                await ProcessBulkDeleteAsync(positionsIds);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, DocumentErrors.DocumentPositionsDeleteError);
                throw;
            }
        }

        protected virtual async Task ProcessBulkDeleteAsync(IEnumerable<Guid> positionsIds)
        {
            throw new NotImplementedException();
        }

        public async Task DeletePositionAsync(Guid positionId)
        {
            try
            {
                await ProcessDeletePositionAsync(positionId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, DocumentErrors.DocumentPositionDeleteError);
                throw;
            }
        }

        protected virtual async Task ProcessDeletePositionAsync(Guid positionId)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
