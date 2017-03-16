using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CmsDemo.Web.Startup))]
namespace CmsDemo.Web
{
	public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{

		}
	}
}