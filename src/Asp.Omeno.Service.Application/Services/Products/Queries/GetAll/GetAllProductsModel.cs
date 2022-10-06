using System;
using System.Collections.Generic;

namespace Asp.Omeno.Service.Application.Services.Products.Queries.GetAll
{
    public class GetAllProductsModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Active { get; set; }
        public int Index { get; set; }
        public ProductStatus Status { get; set; } = new ProductStatus();
        public ProductType Type { get; set; } = new ProductType();
        public ProductStep Step { get; set; } = new ProductStep();
        public IList<ProductImages> Images { get; set; } = new List<ProductImages>();
        public IList<GiveawayMembers> Members { get; set; } = new List<GiveawayMembers>();
        public Guid FirstImageId { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class ProductStatus
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class ProductType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class ProductStep
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class ProductImages
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public string FileName { get; set; }
    }

    public class GiveawayMembers
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
    }
}