using System;

namespace Asp.Omeno.Service.Application.Models
{
    public class BidProcessModel
    {
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public DateTime TimeOfBid { get; set; }
    }
}
