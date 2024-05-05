using MongoDB.Bson;

namespace Payment.Data.Models
{
    public class Payment
    {
        public ObjectId Id { get; set; }

        public string PaymentId => this.Id.ToString();

        public string CartId { get; set; }

        public string Name { get; set; }
    }
}
