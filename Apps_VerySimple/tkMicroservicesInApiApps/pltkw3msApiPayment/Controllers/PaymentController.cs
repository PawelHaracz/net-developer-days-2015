using Microsoft.Azure.AppService.ApiApps.Service;
using pltkw3msApiPayment.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace pltkw3msApiPayment.Controllers
{
    public class PaymentController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "payment-value1", "payment-value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "payment-value" + id.ToString();
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        // Implement a poll trigger.
        //Name have to end with PoolTrigger
        //First parameter need to be triggerState 
        [HttpGet]
        [Route("api/PaidInFull")]
        [ResponseType(typeof(PaymentConfirmation))]
        public HttpResponseMessage PaidInFullPollTrigger(
            //Trigger State - 
            string triggerState,
            //Probability
            double probability)
        {
            if (triggerState != "RUN") return Request.EventWaitPoll(new TimeSpan(0, 1, 0)); //Wait 1 minute
            //Check payment status etc.
            Random rnd = new Random();

            PaymentConfirmation pc = new PaymentConfirmation();
            pc.OrderId = rnd.Next();
            pc.PaymentDate = DateTime.Now;
            if (rnd.NextDouble() < 0.2) throw new ApplicationException("Error in App");
            if (rnd.NextDouble()> probability)
            {
                pc.PaymentType = "AMEX";
                return Request.EventTriggered(values: pc);
            }
            else
            {
                pc.PaymentType = "FAILED";
                return Request.EventTriggered(values: pc);
                //return Request.EventWaitPoll(new TimeSpan(0, 1, 0));
            }
        }

        [HttpGet]
        [Route("api/files/poll/TouchedFiles")]
        public HttpResponseMessage TouchedFilesPollTrigger(
            // triggerState is a UTC timestamp
            string triggerState,
            // Additional parameters
            string searchPattern = "*")
        {
            // Check to see whether there is any file touched after the timestamp.
            var lastTriggerTimeUtc = DateTime.Parse(triggerState).ToUniversalTime();
            var touchedFiles = Directory.EnumerateFiles("D:\\home", searchPattern, SearchOption.AllDirectories);

            // If there are files touched after the timestamp, return their information.
            if (touchedFiles != null && touchedFiles.Count() != 0)
            {
                // Extension method provided by the AppService service SDK.
                return this.Request.EventTriggered(new { files = touchedFiles });
            }
            // If there are no files touched after the timestamp, tell the caller to poll again after 1 mintue.
            else
            {
                // Extension method provided by the AppService service SDK.
                return this.Request.EventWaitPoll(new TimeSpan(0, 1, 0));
            }
        }
    }
    public class PaymentStatusController : ApiController
    {
        [HttpGet]
        public string GetPaymentStatus(string orderId)
        {
            return "PAID";
        }
    }
}
