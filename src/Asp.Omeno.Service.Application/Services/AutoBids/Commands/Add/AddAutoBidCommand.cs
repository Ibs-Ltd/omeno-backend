using Asp.Omeno.Service.Application.Helpers;
using Asp.Omeno.Service.Domain.Entities;
using MediatR;
using System;

namespace Asp.Omeno.Service.Application.Services.AutoBids.Commands.Add
{
    public class AddAutoBidCommand : IRequest
    {
        public Guid ProductId { get; set; }
        public double MaxPrice { get; set; }
        public Guid User_ID { get; set; }

        public AutoBid AddNewAutoBid()
        {
            return new AutoBid
            {
                Id = Guid.NewGuid(),
                Active = true,
                ProductId = ProductId,
                MaxPrice = MaxPrice,
                UserId = this.User_ID,
                UpdatedAt = DateTime.Now,
                CreatedAt = DateTime.Now,//Convert.ToDateTime("2021-02-25 00:44:18.795025"),
                Status = true,
            };
        }
    }
}
