using Asp.Omeno.Service.Common.Enums;
using Asp.Omeno.Service.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;

namespace Asp.Omeno.Service.Application.Services.Products.Commands.Add
{
    public class AddProductCommand : IRequest<AddProductModel>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid ProductTypeId { get; set; }
        public Guid ProductStepId { get; set; }
        public Guid FirstImageId { get; set; }
        public IList<Guid> ImageUrls { get; set; }
        public bool Active { get; set; }
        public int Index { get; set; }

        public Product AddProduct()
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = Name,
                NormalizedName = Name.ToUpper(),
                Description = Description,
                Price = Price,
                StartTime = StartTime,
                EndTime = EndTime,
                Active = Active,
                Index = Index,
                Counter = 10,
                ProductTypeId = ProductTypeId,
                ProductStepId = ProductStepId,
                ProductStatusId = ProductEnum.PRODUCT_STATUS_INPROGRESS,
                FirstImageId = FirstImageId
            };

            return product;
        }

        public IList<ProductImage> AddProductImage(Guid productId)
        {
            IList<ProductImage> images = new List<ProductImage>();
            for (var i = 0; i < ImageUrls.Count; i++)
            {
                images.Add(new ProductImage
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId,
                    ImageId = ImageUrls[i]
                });
            }
            return images;
        }
    }
}
