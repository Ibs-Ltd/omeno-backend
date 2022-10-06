using Asp.Omeno.Service.Domain.Entities.Base;
using System;
using System.Collections.Generic;

namespace Asp.Omeno.Service.Domain.Entities
{
    public class Image : Entity<Guid>
    {
        public string Url { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }

        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
