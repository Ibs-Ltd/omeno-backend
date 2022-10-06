using MediatR;
using System;
using System.Collections.Generic;

namespace Asp.Omeno.Service.Application.Services.Products.Queries.GetImages
{
    public class GetImagesQuery : IRequest<IList<GetImagesModel>>
    {
    }

    public class GetImagesModel
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string Url { get; set; }
    }
}
