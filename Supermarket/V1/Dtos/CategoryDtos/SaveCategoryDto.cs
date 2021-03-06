﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Supermarket.V1.Dtos.CategoryDtos
{
    public class SaveCategoryDto
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public DateTime DateModified { get; private set; } = DateTime.Now;
    }
}
