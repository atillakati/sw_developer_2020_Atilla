using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Wifi.PlaylistEditor.Repositories.MongoDb.Driver
{
    /// <summary>
    /// Interface for data provider, access to database
    /// </summary>
    /// <typeparam name="T">Document data type</typeparam>
    public interface IDataProvider<T>
    {
        /// <summary>
        /// Insert new document into collection
        /// </summary>        
        /// <param name="document">The document to create</param>
        void InsertDocument(T document);

        /// <summary>
        /// Load all documents in collection
        /// </summary>
        /// <returns></returns>
        List<T> LoadAllDocuments();

        /// <summary>
        /// Load document by filter expression
        /// </summary>
        /// <param name="filterAction">The filter to use to load a specific document</param>
        /// <returns></returns>
        T LoadDocumentByFilter(Expression<Func<T, bool>> filterAction);

        /// <summary>
        /// Update a existing document, document will be create if there is no match with filterAction
        /// </summary>
        /// <param name="document">The document to update</param>
        /// <param name="filterAction">The filter to use to update a specific document</param>
        void UpdateDocument(T document, Expression<Func<T, bool>> filterAction);

        /// <summary>
        /// Delete document by filter
        /// </summary>
        /// <param name="filterAction">The filter to use to delete a specific document</param>
        void DeleteDocument(Expression<Func<T, bool>> filterAction);
    }
}
