﻿using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class FastUserName
    {
        [Required]
        public string? UserName { get; set; }
    }
}
