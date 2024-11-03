using Genealogy.Business.Core;

namespace Genealogy.Business.Services.Interfaces {
	public interface IRecursoService<TModel, TEntity, TContext> : IGenealogyServices<TModel, TEntity, TContext> {
		void SaveRegisters();
	}
}
