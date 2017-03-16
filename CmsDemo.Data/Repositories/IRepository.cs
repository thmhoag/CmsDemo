using CmsDemo.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsDemo.Data.Repositories
{
	public interface IRepository<T> where T : IEntity
	{
		Task<T> FindByIdAsync(int id);
		Task InsertAsync(T entity);
		Task InsertAsync(IEnumerable<T> entities);
		Task UpdateAsync(T entity);
		Task UpdateAsync(IEnumerable<T> entities);
		Task DeleteAsync(T entity);
		Task DeleteAsync(IEnumerable<T> entities);
		IQueryable<T> Table { get; }
	}
}
