using System;
using System.Net.Http;
using Microsoft.Azure.AppService;

namespace Pltkw3msApiUI2.ApiPayment
{
    public static class Pltkw3msApiPaymentAppServiceExtensions
    {
        public static Pltkw3msApiPayment CreatePltkw3msApiPayment(this IAppServiceClient client)
        {
            return new Pltkw3msApiPayment(client.CreateHandler());
        }

        public static Pltkw3msApiPayment CreatePltkw3msApiPayment(this IAppServiceClient client, params DelegatingHandler[] handlers)
        {
            return new Pltkw3msApiPayment(client.CreateHandler(handlers));
        }

        public static Pltkw3msApiPayment CreatePltkw3msApiPayment(this IAppServiceClient client, Uri uri, params DelegatingHandler[] handlers)
        {
            return new Pltkw3msApiPayment(uri, client.CreateHandler(handlers));
        }

        public static Pltkw3msApiPayment CreatePltkw3msApiPayment(this IAppServiceClient client, HttpClientHandler rootHandler, params DelegatingHandler[] handlers)
        {
            return new Pltkw3msApiPayment(rootHandler, client.CreateHandler(handlers));
        }
    }
}
