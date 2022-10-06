using MediatR;
using System.Collections.Generic;

namespace Asp.Omeno.Service.Application.Services.Products.Queries.GetAll
{
    public class GetAllProductsQuery : IRequest<IList<GetAllProductsModel>>
    {
        public string Filter { get; set; }
        public int Page { get; set; }
        public int RowsPerPage { get; set; }
    }
}
