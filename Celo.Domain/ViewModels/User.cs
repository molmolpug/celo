using System;
using System.ComponentModel.DataAnnotations;

namespace Celo.Domain.ViewModels
{
    public class User
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Email { get; set; }
        public string Title { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DoB { get; set; }
        public string PhoneNumber { get; set; }
        public string ProfileImageS { get; set; }
        public string ProfileImageL { get; set; }
    }
}
