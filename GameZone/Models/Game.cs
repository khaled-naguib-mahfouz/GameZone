﻿using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace GameZone.Models
{
    public class Game : BaseEntity
    {
        [AllowNull] 
        public string Description { get; set; }
        public string Cover { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<GameDevice> Devices { get; set; } = new List<GameDevice>();
    }
}
