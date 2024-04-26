
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebApiTrade.Models
{
    public partial class DProduct
    {

        public DProduct()
        {
            DProductImages = new HashSet<DProductImage>();
        }

        public int Id { get; set; }
        public int ProductTypeId { get; set; } 
        public string Manufacturer { get; set; } = null!;
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int? InStock { get; set; }
        public virtual DProductType? ProductType { get; set; } = null;

        [JsonInclude]
        public virtual ICollection<DProductImage>? DProductImages { get; set; } = null;
    }
}
