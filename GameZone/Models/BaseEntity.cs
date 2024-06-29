using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace GameZone.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        [MaxLength(200)]
        
        public string Name { get; set; }
    }
}
