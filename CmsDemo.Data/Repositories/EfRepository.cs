using CmsDemo.Core.Utility;
using CmsDemo.Data.Entities;
using CmsDemo.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsDemo.Data.Repositories
{
	/// <summary>
	/// Generic repository for Entity Framework entities
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class EfRepository<T> : IRepository<T> where T : class, IEntity
	{
		private readonly DbContext _context;

		private DbSet<T> _entities;
		protected virtual DbSet<T> Entities
		{
			get
			{
				if (_entities == null)
					_entities = _context.Set<T>();

				return _entities;
			}
		}

		/// <summary>
		/// The base entity from Entity Framework, supplied for the ability to query
		/// </summary>
		public virtual IQueryable<T> Table => this.Entities;

		public EfRepository(DbContext context)
		{
			this._context = context;
		}

		/// <summary>
		/// Checks to see if an entity is attached to the context and attaches it if it's not already.
		/// </summary>
		/// <param name="entity"></param>
		protected void EnsureAttached(T entity)
		{
			Assert.IsNotNull(entity, nameof(entity));

			var isAttached = this._context.IsAttached(entity);
			if (!isAttached)
				this.Entities.Attach(entity);
		}

		/// <summary>
		/// Checks to see if a list of entities are attached to the context and adds any that aren't already.
		/// </summary>
		/// <param name="entities"></param>
		protected void EnsureAttached(IEnumerable<T> entities)
		{
			Assert.IsNotNull(entities, nameof(entities));

			foreach (var entity in entities)
			{
				EnsureAttached(entity);
			}
		}

		/// <summary>
		/// Verifies that the state of the entity matches the entityState argument passed, modifies it to match if it doesn't already.
		/// </summary>
		/// <param name="entity"></param>
		/// <param name="entityState"></param>
		protected void EnsureState(T entity, EntityState entityState)
		{
			Assert.IsNotNull(entity, nameof(entity));

			EnsureAttached(entity);
			this._context.Entry(entity).State = entityState;
		}

		/// <summary>
		/// Verifies that the state of the entities matches the entityState argument passed, modifies them to match if they don't already.
		/// </summary>
		/// <param name="entities"></param>
		/// <param name="entityState"></param>
		protected void EnsureState(IEnumerable<T> entities, EntityState entityState)
		{
			Assert.IsNotNull(entities, nameof(entities));

			EnsureAttached(entities);
			foreach (var entity in entities)
			{
				EnsureState(entity, entityState);
			}
		}

		/// <summary>
		/// Find and return an entity by id asynchronously.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public virtual async Task<T> FindByIdAsync(int id) => await this.Entities.FindAsync(id);

		/// <summary>
		/// Inserts a new entity into the database asynchronously.
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		public virtual async Task InsertAsync(T entity)
		{
			Assert.IsNotNull(entity, nameof(entity));

			this.Entities.Add(entity);
			await this._context.SaveChangesAsync();
		}

		/// <summary>
		/// Inserts a range of entities into the database asynchronously.
		/// </summary>
		/// <param name="entities"></param>
		/// <returns></returns>
		public virtual async Task InsertAsync(IEnumerable<T> entities)
		{
			Assert.IsNotNull(entities, nameof(entities));

			this.Entities.AddRange(entities);
			await this._context.SaveChangesAsync();
		}

		/// <summary>
		/// Updates an entity in the database asynchronously.
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		public virtual async Task UpdateAsync(T entity)
		{
			Assert.IsNotNull(entity, nameof(entity));

			EnsureState(entity, EntityState.Modified);
			await this._context.SaveChangesAsync();
		}

		/// <summary>
		/// Updates a range of entities in the database asynchronously.
		/// </summary>
		/// <param name="entities"></param>
		/// <returns></returns>
		public virtual async Task UpdateAsync(IEnumerable<T> entities)
		{
			Assert.IsNotNull(entities, nameof(entities));

			EnsureState(entities, EntityState.Modified);
			await this._context.SaveChangesAsync();
		}

		/// <summary>
		/// Deletes an entity from the database asynchronously.
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		public virtual async Task DeleteAsync(T entity)
		{
			Assert.IsNotNull(entity, nameof(entity));

			EnsureAttached(entity);
			this.Entities.Remove(entity);
			await this._context.SaveChangesAsync();
		}

		/// <summary>
		/// Deletes a range of entities from the database asynchronously.
		/// </summary>
		/// <param name="entities"></param>
		/// <returns></returns>
		public virtual async Task DeleteAsync(IEnumerable<T> entities)
		{
			Assert.IsNotNull(entities, nameof(entities));

			EnsureAttached(entities);
			this.Entities.RemoveRange(entities);
			await this._context.SaveChangesAsync();
		}
	}
}
