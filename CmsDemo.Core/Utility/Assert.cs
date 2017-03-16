using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsDemo.Core.Utility
{
	/// <summary>
	/// Statis assertion methods for checking arguments
	/// </summary>
	public static class Assert
	{
		/// <summary>
		/// Checks that the object is not null, throws ArgumentNullException if it is.
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="name"></param>
		public static void IsNotNull(object obj, string name)
		{
			if (obj == null)
				throw new ArgumentNullException(name);
		}
	}
}
