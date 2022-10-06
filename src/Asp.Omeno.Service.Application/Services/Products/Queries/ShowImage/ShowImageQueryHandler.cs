//using Asp.Omeno.Service.Application.Interfaces;
//using MediatR;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.IO;
//using System.Threading;
//using System.Threading.Tasks;

//namespace Asp.Omeno.Service.Application.Services.Products.Queries.ShowImage
//{
//    public class ShowImageQueryHandler : IRequestHandler<ShowImageQuery, ShowImageModel>
//    {
//        private readonly IWebHostEnvironment _hostingEnvironment;
//        private readonly IServiceDbContext _context;
//        public ShowImageQueryHandler(IWebHostEnvironment environment, IServiceDbContext context)
//        {
//            _hostingEnvironment = environment ?? throw new ArgumentNullException(nameof(environment));
//            _context = context ?? throw new ArgumentNullException(nameof(context));
//        }
//        public async Task<ShowImageModel> Handle(ShowImageQuery request, CancellationToken cancellationToken)
//        {
//            var image = await _context.Images.FirstOrDefaultAsync(x => x.Id == request.ImageId);
//            string filePath = Path.Combine(image.FileName);
//            //string filePath = Path.Combine(uploadsFolder, image.FileName);
//            return new ShowImageModel
//            {
//                Image = filePath,
//                ImageType = image.FileType
//            };
//        }
//    }
//}
