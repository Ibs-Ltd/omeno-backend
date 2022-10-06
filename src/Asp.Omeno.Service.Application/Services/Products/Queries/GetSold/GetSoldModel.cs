using Asp.Omeno.Service.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;

namespace Asp.Omeno.Service.Application.Services.Products.Queries.GetSold
{

    public class ProductModel
    {
        public Guid Id { get; set; }
        public DateTime TimeNow { get; set; } = DateTime.Now;
        public bool Active { get; set; }
        public string Name { get; set; }
        public int Timer { get; set; }
        public int TimerFromDb { get; set; }
        public int Index { get; set; }
        public double Price { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public ProductStatusModel Status { get; set; } = new ProductStatusModel();
        public ProductTypeModel Type { get; set; } = new ProductTypeModel();
        public ProductStepModel Step { get; set; } = new ProductStepModel();
        public IList<ProductImagesModel> Images { get; set; } = new List<ProductImagesModel>();
        public Guid FirstImageId { get; set; }
        public IList<BidModel> Biders { get; set; } = new List<BidModel>();
    }

    public class ProductStatusModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class ProductTypeModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class ProductStepModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class ProductImagesModel
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public string FileName { get; set; }
    }

}