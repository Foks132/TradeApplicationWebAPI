using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebApiTrade.Models
{
    public partial class DProductImage
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public byte[] Image { get; set; } = null!;
        public string Name { get; set; } = null!;

        [JsonIgnore]
        public virtual DProduct? Product { get; set; } = null;
    }
}
