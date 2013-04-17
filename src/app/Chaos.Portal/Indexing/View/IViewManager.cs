namespace Chaos.Portal.Indexing.View
{
    using System.Collections.Generic;

    using Chaos.Portal.Core.Data.Model;
    using Chaos.Portal.Indexing.Solr;

    /// <summary>
    /// The ViewManager interface.
    /// </summary>
    public interface IViewManager
    {
        /// <summary>
        /// The index.
        /// </summary>
        /// <param name="obj">
        /// The object.
        /// </param>
        /// <returns>
        /// The <see>
        ///       <cref>IIndexReport</cref>
        ///     </see> .
        /// </returns>
        void Index(object obj);

        /// <summary>
        /// The index.
        /// </summary>
        /// <param name="obj">
        /// The object.
        /// </param>
        /// <returns>
        /// The <see>
        ///       <cref>IIndexReport</cref>
        ///     </see> .
        /// </returns>
        void Index(IEnumerable<object> objects);

        /// <summary>
        /// The query.
        /// </summary>
        /// <param name="viewName">
        /// The key.
        /// </param>
        /// <param name="query">
        /// The query.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IPagedResult<IResult> Query(string viewName, IQuery query);

        /// <summary>
        /// The add view.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <param name="view">
        /// The view.
        /// </param>
        void AddView(IView view);

        IEnumerable<IView> LoadedViews { get; }

        void Delete();
    }
}