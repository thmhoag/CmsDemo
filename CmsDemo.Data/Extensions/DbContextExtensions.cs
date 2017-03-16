using CmsDemo.Core.Utility;
using CmsDemo.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsDemo.Data.Extensions
{
	public static class DbContextExtensions
	{
		/// <summary>
		/// Verifies that the entity is attached to the Entity Framework DbContext
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="context"></param>
		/// <param name="entity"></param>
		/// <returns></returns>
		public static bool IsAttached<T>(this DbContext context, T entity)
			where T : class, IEntity
		{
			Assert.IsNotNull(entity, nameof(entity));

			return context.Set<T>().Local.Contains(entity);
		}
	}
}
