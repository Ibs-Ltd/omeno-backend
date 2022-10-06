using MediatR;
using System;
using System.Collections.Generic;

namespace Asp.Omeno.Service.Application.Services.Packs.Queries.Get
{
    public class GetPacksQuery : IRequest<IList<GetPacksModel>>
    {
    }

    public class GetPacksModel
    {
        public string MenosAmount { get; set; }
        public long? PriceAmount { get; set; }
        public string PriceId { get; set; }
        public int Index { get; set; }
        public string Currency { get; set; }
    }
}
