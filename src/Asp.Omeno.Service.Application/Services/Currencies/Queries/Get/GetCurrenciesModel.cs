using System;

namespace Asp.Omeno.Service.Application.Services.Currencies.Queries.Get
{
    public class GetCurrenciesModel
    {
        public double currencyRatio { get; set; }
        public Guid Id { get; set; } 
       public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
	    
    }
}