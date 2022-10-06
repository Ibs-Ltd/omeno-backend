using Asp.Omeno.Service.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Services.Products.Queries.GetImages
{
    public class GetImagesQueryHandler : IRequestHandler<GetImagesQuery, IList<GetImagesModel>>
    {
        private readonly IServiceDbContext _context;
        public GetImagesQueryHandler(IServiceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IList<GetImagesModel>> Handle(GetImagesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Images.Select(image => new GetImagesModel 
            { 
                Id = image.Id,
                Url = image.Url,
                FileName = image.FileName,
                FileType = image.FileType
            }).ToListAsync();
        }
    }
}
