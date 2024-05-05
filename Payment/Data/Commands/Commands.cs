using MediatR;

namespace Payment.Data.Commands
{
    public class DeletePaymentCommand : IRequest<bool>
    {
        public string Id { get; set; }
    }

    public class CreatePaymentCommand : IRequest<Models.Payment>
    {
        public Models.Payment Payment { get; set; }
    }

    public class UpdatePaymentCommand : IRequest<Models.Payment>
    {
        public Models.Payment Payment { get; set; }
    }

}
