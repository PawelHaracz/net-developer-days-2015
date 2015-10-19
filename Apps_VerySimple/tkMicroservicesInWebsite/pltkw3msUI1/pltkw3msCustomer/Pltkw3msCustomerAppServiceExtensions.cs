using System;
using System.Net.Http;
using Microsoft.Azure.AppService;

namespace Pltkw3msUI1
{
    public static class Pltkw3msCustomerAppServiceExtensions
    {
        public static Pltkw3msCustomer CreatePltkw3msCustomer(this IAppServiceClient client)
        {
            return new Pltkw3msCustomer(client.CreateHandler());
        }

        public static Pltkw3msCustomer CreatePltkw3msCustomer(this IAppServiceClient client, params DelegatingHandler[] handlers)
        {
            return new Pltkw3msCustomer(client.CreateHandler(handlers));
        }

        public static Pltkw3msCustomer CreatePltkw3msCustomer(this IAppServiceClient client, Uri uri, params DelegatingHandler[] handlers)
        {
            return new Pltkw3msCustomer(uri, client.CreateHandler(handlers));
        }

        public static Pltkw3msCustomer CreatePltkw3msCustomer(this IAppServiceClient client, HttpClientHandler rootHandler, params DelegatingHandler[] handlers)
        {
            return new Pltkw3msCustomer(rootHandler, client.CreateHandler(handlers));
        }
    }
}
