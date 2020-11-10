﻿using System.Collections.Generic;

namespace LightCommerce.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public int Rating { get; set; }

        public string ImageFileName { get; set; }

        public IList<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
    }
}