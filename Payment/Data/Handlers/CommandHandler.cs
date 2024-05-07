using MediatR;
using MongoDB.Bson;
using MongoDB.Driver;
using Payment.Data.Commands;

namespace Payment.Data.Handlers
{
    public class CreatePaymentCommandHandler : BaseRequestHandler, IRequestHandler<CreatePaymentCommand, Models.Payment>
    {
        public async Task<Models.Payment> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            var _dbContext = GetDBContext();
            _dbContext.Payments.Add(request.Payment);
            await _dbContext.SaveChangesAsync();
            return request.Payment;
        }
    }

    public class UpdatePaymentCommandHandler : BaseRequestHandler, IRequestHandler<UpdatePaymentCommand, Models.Payment>
    {
        public async Task<Models.Payment> Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
        {
            var _dbContext = GetDBContext();
            var payment = await _dbContext.Payments.FindAsync(request.Payment.Id);
            if (payment != null)
            {
                // Update specific properties
                payment.Name = request.Payment.Name;
                await _dbContext.SaveChangesAsync();
            }
            return payment;
        }
    }

    public class DeletePaymentCommandHandler : BaseRequestHandler, IRequestHandler<DeletePaymentCommand, bool>
    {
        public async Task<bool> Handle(DeletePaymentCommand request, CancellationToken cancellationToken)
        {
            var _dbContext = GetDBContext();

            var Payment = await _dbContext.Payments.FindAsync(new ObjectId(request.Id));
            if (Payment != null)
            {
                _dbContext.Payments.Remove(Payment);
                await _dbContext.SaveChangesAsync();
            }
            return true;
        }
    }


    public class BaseRequestHandler
    {
        protected MongoDbContext GetDBContext()
        {
            var connectionString = "mongodb+srv://yashveersingh83:Ruchi%4001664265237@yashmongocluster.whtjz12.mongodb.net/?retryWrites=true&w=majority&appName=YashMongoCluster";
            if (connectionString == null)
            {
                Console.WriteLine("You must set your 'DB_URL' environment variable. ");
                Environment.Exit(0);
            }
            var client = new MongoClient(connectionString);
            return MongoDbContext.Create(client.GetDatabase("Payment_DB"));
        }
    }
}
