using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Celo.Data.Models
{
    public class ProfileImage : BaseEntity
    {
        [Required]
        public byte[] Image { get; set; } // Maximun 1 GB
    }
}
