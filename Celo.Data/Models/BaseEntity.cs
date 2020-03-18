using Celo.Data.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace Celo.Data.Models
{
    public class BaseEntity : IEntityWithId<Guid>
    {
        [Required]
        public Guid Id { get; set; }
    }
}
