using System;
using System.Net.Http;
using Microsoft.Azure.AppService;

namespace Pltkw3msApiUI2.ApiInventoryCatalog
{
    public static class Pltkw3msApiInventoryCatalogAppServiceExtensions
    {
        public static Pltkw3msApiInventoryCatalog CreatePltkw3msApiInventoryCatalog(this IAppServiceClient client)
        {
            return new Pltkw3msApiInventoryCatalog(client.CreateHandler());
        }

        public static Pltkw3msApiInventoryCatalog CreatePltkw3msApiInventoryCatalog(this IAppServiceClient client, params DelegatingHandler[] handlers)
        {
            return new Pltkw3msApiInventoryCatalog(client.CreateHandler(handlers));
        }

        public static Pltkw3msApiInventoryCatalog CreatePltkw3msApiInventoryCatalog(this IAppServiceClient client, Uri uri, params DelegatingHandler[] handlers)
        {
            return new Pltkw3msApiInventoryCatalog(uri, client.CreateHandler(handlers));
        }

        public static Pltkw3msApiInventoryCatalog CreatePltkw3msApiInventoryCatalog(this IAppServiceClient client, HttpClientHandler rootHandler, params DelegatingHandler[] handlers)
        {
            return new Pltkw3msApiInventoryCatalog(rootHandler, client.CreateHandler(handlers));
        }
    }
}
