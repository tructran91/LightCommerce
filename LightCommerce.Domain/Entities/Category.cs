using System.Collections.Generic;

namespace LightCommerce.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public IList<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
    }
}
