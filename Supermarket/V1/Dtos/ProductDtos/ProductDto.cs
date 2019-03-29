﻿using Supermarket.V1.Dtos.CategoryDtos;

namespace Supermarket.V1.Dtos.ProductDtos
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int QuantityInPackage { get; set; }

        public string UnitOfMeasurement { get; set; }

        public CategoryDto Category { get; set; }
    }
}
