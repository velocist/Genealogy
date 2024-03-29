namespace Genealogy.Business.Core
{

    public interface IGenealogyServices<TModel, TEntity, TContext> : IBaseService<TModel, TEntity, TContext>
    {

        /// <summary>
        /// Saves the model with entities.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        bool SaveWithEntities(TModel model);

        /// <summary>
        /// Selects all.
        /// </summary>
        /// <returns></returns>
        IEnumerable<TModel> SelectAll();
    }
}
