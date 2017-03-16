using CmsDemo.Data.Contexts;
using CmsDemo.Data.Entities;
using CmsDemo.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CmsDemo.Web.Utility
{
	/// <summary>
	/// Custom controller factory implementation for rough dependency injection
	/// </summary>
	public class CustomControllerFactory : DefaultControllerFactory
	{
		private const string CONTEXT_CONTROLLER_KEY = "controller";
		protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
		{
			var controllerName = requestContext.RouteData.Values[CONTEXT_CONTROLLER_KEY].ToString();

			// This is gross. Would normally create some kind of factory for this, but since there is only one controller
			// for this demo I'm going to leave it as an if statement
			if (controllerName.Equals("Customers", StringComparison.InvariantCultureIgnoreCase))
			{
				var repository = new EfRepository<Customer>(new CustomerContext());
				return Activator.CreateInstance(controllerType, new[] { repository }) as Controller;
			}

			return base.GetControllerInstance(requestContext, controllerType);
		}

		public override void ReleaseController(IController controller)
		{
			var dispose = controller as IDisposable;
			dispose?.Dispose();
		}
	}
}