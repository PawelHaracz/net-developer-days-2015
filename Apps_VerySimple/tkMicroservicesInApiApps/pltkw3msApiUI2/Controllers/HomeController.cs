using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Threading;



namespace pltkw3msApiUI2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public async Task<ActionResult> CallAPIDemo()
        {
            //Public, so - no big deal with authentication
            Pltkw3msApiUI2.ApiPayment.Pltkw3msApiPayment p = new Pltkw3msApiUI2.ApiPayment.Pltkw3msApiPayment();
            var result = await p.Payment.PostByValueWithOperationResponseAsync("TEST");
            var result1 = await p.Payment.GetWithOperationResponseAsync();

            //Internal - debug will FAIL; some remarks for internal
            //Pltkw3msApiUI2.ApiShipping.Pltkw3msApiShipping s = new Pltkw3msApiUI2.ApiShipping.Pltkw3msApiShipping(new DelegatingHandler[] { new InternalCredentialHandler() });
            //Public
            Pltkw3msApiUI2.ApiShipping.Pltkw3msApiShipping s = new Pltkw3msApiUI2.ApiShipping.Pltkw3msApiShipping();
            var result2 = await s.Shipping.GetWithOperationResponseAsync();

            return View();
        }
    }

    public class InternalCredentialHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //Nuget: Microsoft.Azure.AppService.ApiApps.Service
            Microsoft.Azure.AppService.ApiApps.Service.Runtime.FromAppSettings(request).SignHttpRequest(request);
            return base.SendAsync(request, cancellationToken);
        }
    }
}