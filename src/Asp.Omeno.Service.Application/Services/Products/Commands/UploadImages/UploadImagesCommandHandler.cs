using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using Asp.Omeno.Service.Application.Interfaces;
using Asp.Omeno.Service.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Services.Products.Commands.UploadImages
{
    public class UploadImagesCommandHandler : IRequestHandler<UploadImagesCommand, IList<UploadImagesModel>>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IServiceDbContext _context;
        private readonly IConfiguration _configuration;
        public UploadImagesCommandHandler(IHttpContextAccessor httpContext,  
            IServiceDbContext context,
            IConfiguration configuration)
        {
            _httpContextAccessor = httpContext ?? throw new ArgumentNullException(nameof(httpContext));
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        public async Task<IList<UploadImagesModel>> Handle(UploadImagesCommand request, CancellationToken cancellationToken)
        {
            var httpRequest = _httpContextAccessor.HttpContext.Request.Form;
            IList<Image> productImages = new List<Image>();
            IList<UploadImagesModel> response = new List<UploadImagesModel>();
            if (httpRequest.Files.Count > 0)
            {
                foreach (var formFile in httpRequest.Files)
                {
                    if (formFile.Length > 0)
                    {
                        FileInfo findInfo = new FileInfo(formFile.FileName);
                        string fileExtension = findInfo.Extension.ToLower();
                        Guid Id = Guid.NewGuid();
                        productImages.Add(new Image
                        {
                            Id = Id,
                            Url = _configuration["Amazon:S3Endpoint"] + Id,
                            FileName = formFile.FileName,
                            FileType = "image/" + fileExtension.Substring(1)
                        });

                        await UploadFileToS3(formFile, Id.ToString());
                    }
                }
            }

            _context.Images.AddRange(productImages);
            await _context.SaveChangesAsync();
            foreach (var image in productImages)
            {
                response.Add(new UploadImagesModel
                {
                    Id = image.Id,
                    FileName = image.FileName,
                    FileType = image.FileType,
                    Url = image.Url
                });
            }
            return response;
            //var httpRequest = _httpContextAccessor.HttpContext.Request.Form;
            ////string uploads = Path.Combine(_hostingEnvironment.ContentRootPath, "Uploads");
            //IList<Image> productImages = new List<Image>();
            //IList<UploadImagesModel> response = new List<UploadImagesModel>();
            //if (httpRequest.Files.Count > 0)
            //{
            //    foreach (var formFile in httpRequest.Files)
            //    {
            //        if (formFile.Length > 0)
            //        {
            //            string filePath = Path.Combine(formFile.FileName);

            //            FileInfo findInfo = new FileInfo(formFile.FileName);
            //            string fileExtension = findInfo.Extension.ToLower();
            //            if(fileExtension == ".jpg")
            //            {
            //                fileExtension = ".jpeg";
            //            }
            //            Guid Id = Guid.NewGuid();
            //            productImages.Add(new Image
            //            {
            //                Id = Id,
            //                Url = _configuration["Endpoints:Service"] + "/api/products/:image?ImageId=" + Id,
            //                FileName = formFile.FileName,
            //                FileType = "image/" + fileExtension.Substring(1)
            //            });
            //            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
            //            {
            //                await formFile.CopyToAsync(fileStream);
            //            }
            //        }
            //    }
            //}
            //_context.Images.AddRange(productImages);
            //await _context.SaveChangesAsync();
            //foreach(var image in productImages)
            //{
            //    response.Add(new UploadImagesModel { 
            //        Id = image.Id,
            //        FileName = image.FileName,
            //        FileType = image.FileType,
            //        Url = image.Url
            //    });
            //}
            //return response;
        }

        public async Task UploadFileToS3(IFormFile file, string id)
        {
            using (var client = new AmazonS3Client("AKIA3LQFWTMAWEDNYT77", "fa/FrijQNsDQHP1r1UpjC1ADLwPccUFrDu235xtB", RegionEndpoint.EUCentral1))
            {
                using (var newMemoryStream = new MemoryStream())
                {
                    file.CopyTo(newMemoryStream);

                    var uploadRequest = new TransferUtilityUploadRequest
                    {
                        InputStream = newMemoryStream,
                        Key = id,
                        BucketName = "omeno",
                        CannedACL = S3CannedACL.PublicRead
                    };

                    var fileTransferUtility = new TransferUtility(client);
                    await fileTransferUtility.UploadAsync(uploadRequest);
                }
            }

        }
    }
}
