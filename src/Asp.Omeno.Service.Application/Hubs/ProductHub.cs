using Asp.Omeno.Service.Application.Services.Products.Queries.Get;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Hubs
{
    public class ProductHub : Hub
    {
        private readonly IMediator _mediator;

        public ProductHub(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task GetProducts()
        {
            var products = await _mediator.Send(new GetProductQuery());
            await Clients.All.SendAsync("getProducts", products);
        }
    }
}
