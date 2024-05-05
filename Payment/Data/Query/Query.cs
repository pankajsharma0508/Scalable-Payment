using MediatR;

namespace Payment.Data.Query
{
    public class GetPaymentQuery : IRequest<Models.Payment>
    {
        public string Id { get; set; }
    }

    public class GetPaymentsQuery : IRequest<List<Models.Payment>>
    {

    }
}
