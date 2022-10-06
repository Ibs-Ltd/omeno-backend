//using Asp.Omeno.Service.Application.Interfaces;
//using Asp.Omeno.Service.Common.Constants;
//using FluentValidation;
//using MediatR;
//using System;
//using System.Linq;

//namespace Asp.Omeno.Service.Application.Services.Products.Queries.ShowImage
//{
//    public class ShowImageQuery : IRequest<ShowImageModel>
//    {
//        public Guid ImageId { get; set; }
//    }
    
//    public class ShowImageQueryValidator : AbstractValidator<ShowImageQuery>
//    {
//        private readonly IServiceDbContext _context;
//        public ShowImageQueryValidator(IServiceDbContext context)
//        {
//            _context = context ?? throw new ArgumentNullException(nameof(context));
//            Validations();
//        }

//        private void Validations()
//        {
//            RuleFor(x => x.ImageId).NotEmpty().WithMessage(ValidatorMessages.NotEmpty("Image Id"))
//                .DependentRules(() =>
//                {
//                    RuleFor(x => x.ImageId).Must((Id) =>
//                    {
//                        return _context.Images.Any(x => x.Id == Id);
//                    }).WithMessage(ValidatorMessages.NotFound("Image"));
//                });
//        }
//    }



//    public class ShowImageModel
//    {
//        public string Image { get; set; }
//        public string ImageType { get; set; }
//    }
//}
