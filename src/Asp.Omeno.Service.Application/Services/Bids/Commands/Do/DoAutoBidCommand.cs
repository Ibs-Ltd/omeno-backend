using Asp.Omeno.Service.Application.Models;
using System;

namespace Asp.Omeno.Service.Application.Services.Bids.Commands.Do
{
    public class DoAutobidCommand
    {
        public Guid ProductId { get; set; }
        public DateTime TimeOfBid { get; set; }
        public ProfileModel Profile { get; set; }
    }
}
