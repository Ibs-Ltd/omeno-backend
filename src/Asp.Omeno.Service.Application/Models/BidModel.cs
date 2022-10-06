using System;

namespace Asp.Omeno.Service.Application.Models
{
    public class BidModel
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public bool IsLast { get; set; }
    }
}
