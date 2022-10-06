using MediatR;
using System;
using System.Collections.Generic;

namespace Asp.Omeno.Service.Application.Services.Products.Commands.UploadImages
{
    public class UploadImagesCommand : IRequest<IList<UploadImagesModel>>
    {
    }

    public class UploadImagesModel
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string Url { get; set; }
    }
}
