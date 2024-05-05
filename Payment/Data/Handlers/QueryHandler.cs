using MediatR;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using Payment.Data.Query;

namespace Payment.Data.Handlers
{
    public class GetPaymentQueryHandler : BaseRequestHandler, IRequestHandler<GetPaymentQuery, Models.Payment?>
    {
        public Task<Models.Payment?> Handle(GetPaymentQuery request, CancellationToken cancellationToken)
        {
            var _dbContext = GetDBContext();
            return _dbContext.Payments.FindAsync(new ObjectId(request.Id)).AsTask();
        }
    }

    public class GetPaymentsQueryHandler : BaseRequestHandler, IRequestHandler<GetPaymentsQuery, List<Models.Payment>>
    {
        public Task<List<Models.Payment>> Handle(GetPaymentsQuery request, CancellationToken cancellationToken)
        {
            var db = GetDBContext();
            return db.Payments.ToListAsync();
        }
    }
}
