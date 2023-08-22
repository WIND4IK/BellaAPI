using DomainBellaNS.API.InvoiceAPI;
using Microsoft.AspNetCore.Mvc;
using System.ServiceModel;

namespace BellaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : ControllerBase
    {
        [HttpPost("Invoice")]
        public Invoice Invoice(GenerateInvoiceRequest request)
        {
            using (ChannelFactory<InvoiceAPI> cf = new ChannelFactory<InvoiceAPI>(new BasicHttpBinding(), new EndpointAddress("http://localhost:3333/bella/InvoiceAPI")))
            {
                InvoiceAPI channel = cf.CreateChannel();
                return channel.Invoice(request);
            }
        }
    }
}