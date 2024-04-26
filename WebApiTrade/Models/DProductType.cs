using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebApiTrade.Models
{
    public partial class DProductType
    {
        public DProductType()
        {
            DProducts = new HashSet<DProduct>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<DProduct>? DProducts { get; set; } = null;
    }
}
