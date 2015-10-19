using System;
using System.Net.Http;
using Microsoft.Azure.AppService;

namespace Pltkw3msApiUI2.ApiShipping
{
    public static class Pltkw3msApiShippingAppServiceExtensions
    {
        public static Pltkw3msApiShipping CreatePltkw3msApiShipping(this IAppServiceClient client)
        {
            return new Pltkw3msApiShipping(client.CreateHandler());
        }

        public static Pltkw3msApiShipping CreatePltkw3msApiShipping(this IAppServiceClient client, params DelegatingHandler[] handlers)
        {
            return new Pltkw3msApiShipping(client.CreateHandler(handlers));
        }

        public static Pltkw3msApiShipping CreatePltkw3msApiShipping(this IAppServiceClient client, Uri uri, params DelegatingHandler[] handlers)
        {
            return new Pltkw3msApiShipping(uri, client.CreateHandler(handlers));
        }

        public static Pltkw3msApiShipping CreatePltkw3msApiShipping(this IAppServiceClient client, HttpClientHandler rootHandler, params DelegatingHandler[] handlers)
        {
            return new Pltkw3msApiShipping(rootHandler, client.CreateHandler(handlers));
        }
    }
}
