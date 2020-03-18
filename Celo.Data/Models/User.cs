using System;
using System.ComponentModel.DataAnnotations;
using Celo.Data.Interfaces;

namespace Celo.Data.Models
{
    public class User : BaseEntity
    {
        [Required]
        public string Email { get; set; }
        public string Title { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTime DoB { get; set; }
        public string PhoneNumber { get; set; }
        public Guid? ProfileImageLId { get; set; }
        public virtual ProfileImage ProfileImageL { get; set; }
        public Guid? ProfileImageSId { get; set; }
        public virtual ProfileImage ProfileImageS { get; set; }
    }
}
