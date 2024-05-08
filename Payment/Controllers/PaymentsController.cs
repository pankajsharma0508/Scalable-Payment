using MediatR;
using Microsoft.AspNetCore.Mvc;
using Payment.Data.Commands;
using Payment.Data.Query;
using Payment.Kafka;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Payment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IMediator mediator;

        public PaymentsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: api/<PaymentsController>
        [HttpGet]
        public async Task<List<Data.Models.Payment>> Get() => await mediator.Send(new GetPaymentsQuery());

        // GET api/<PaymentsController>/5
        [HttpGet("{id}")]
        public async Task<Data.Models.Payment> Get(string id) => await mediator.Send(new GetPaymentQuery { Id = id });


        // POST api/<PaymentsController>
        [HttpPost]
        public  Data.Models.Payment Post([FromBody] Data.Models.Payment payment)
        {
            var result =  mediator.Send(new CreatePaymentCommand { Payment = payment }).Result;
            Producer.ProduceMessage(payment.CartId);

            return result;

        }

        // PUT api/<PaymentsController>/5
        [HttpPut("{id}")]
        public async Task<Data.Models.Payment> Put(int id, [FromBody] Data.Models.Payment payment) => await mediator.Send(new UpdatePaymentCommand { Payment = payment });
        
        // DELETE api/<PaymentsController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(string id) => await mediator.Send(new DeletePaymentCommand { Id = id });
    }
}
