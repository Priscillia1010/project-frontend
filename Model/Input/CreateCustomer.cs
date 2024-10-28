using System.ComponentModel.DataAnnotations;
using CarRent_Frontend.Model;

namespace CarRent_Frontend.Model.Input
{
    public class CreateCustomer
    {
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm your password.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string RePassword { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Alamat { get; set; }
    }
}
