using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Description;
using System.Web.Http.Routing;

namespace ApiDocs.Api.Exstensions.WebApi
{
    public static class WebApiExtensions
    {
        /// <summary>
        /// Retrieve api docs
        /// </summary>
        /// <param name="apiExplorer"></param>
        /// <param name="httpConfig"></param>
        /// <returns></returns>
        public static Collection<ApiDescription> GetAllApiDescriptions(this IApiExplorer apiExplorer, HttpConfiguration httpConfig)
        {
            if (!(apiExplorer is ApiExplorer))
            {
                return apiExplorer.ApiDescriptions;
            }

            IList<ApiDescription> apiDescriptions = new Collection<ApiDescription>();
            var controllerSelector = httpConfig.Services.GetHttpControllerSelector();
            var controllerMappings = controllerSelector.GetControllerMapping();
            
            if (controllerMappings != null)
            {
                foreach (var route in httpConfig.Routes)
                {
                    apiDescriptions = typeof(ApiExplorer).GetMethod("ExploreRouteControllers",
                        bindingAttr: BindingFlags.Instance | BindingFlags.NonPublic,
                        binder: null,
                        types: new[] { typeof(IDictionary<string, HttpControllerDescriptor>), typeof(IHttpRoute) },
                        modifiers: null
                    ).Invoke(apiExplorer, new object[] { controllerMappings, route }) as Collection<ApiDescription>;
                }

                apiDescriptions = apiDescriptions.ToList();
            }

            return new Collection<ApiDescription>(apiDescriptions);
        }
    }
}