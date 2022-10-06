using Asp.Omeno.Service.Application.Interfaces;
using Asp.Omeno.Service.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Asp.Omeno.Service.Application.Services.Products.Commands.Update
{
    public class UpdateProductCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid ProductTypeId { get; set; }
        public Guid ProductStatusId { get; set; }
        public Guid ProductStepId { get; set; }
        public Guid FirstImageId { get; set; }
        public IList<Guid> ImageUrls { get; set; }
        public bool Active { get; set; }
        public int Index { get; set; }
        public double PriceStart { get; set; }
        public Product UpdateProduct(Product product)
        {
            product.Name = Name;
            product.NormalizedName = Name.ToUpper();
            product.Description = Description;
            product.Price = Price;
            product.StartTime = StartTime;
            product.EndTime = EndTime;
            product.ProductTypeId = ProductTypeId;
            product.ProductStatusId = ProductStatusId;
            product.ProductStepId = ProductStepId;
            product.FirstImageId = FirstImageId;
            product.Active = Active;
            product.Index = Index;
            return product;
        }

        public IList<ProductImage> UpdateProductImages(ICollection<ProductImage> productImages, IServiceDbContext context)
        {
            IList<ProductImage> images = new List<ProductImage>();

            for (var i = 0; i < ImageUrls.Count; i++)
            {
                var productImage = productImages.Any(x => x.ImageId == ImageUrls[i]);
                if (productImage == false)
                {
                    images.Add(new ProductImage
                    {
                        Id = Guid.NewGuid(),
                        ProductId = Id,
                        ImageId = ImageUrls[i]
                    });
                }
            }

            foreach(var image in productImages)
            {
                var shloudDelete = ImageUrls.Any(x => x == image.ImageId);
                if(shloudDelete == false)
                {
                    context.ProductImages.Remove(image);
                }
            }
            return images;  
        }
    }
}
