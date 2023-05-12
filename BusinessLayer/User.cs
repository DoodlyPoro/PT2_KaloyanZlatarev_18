using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "First Name must be below 20 characters.")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Last Name must be below 20 characters.")]
        public string LastName { get; set; }

        [Range(10, 80)]
        public int Age { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Username must be below 20 characters.")]
        public string Username { get; set; }

        [Required]
        [MaxLength(70, ErrorMessage = "Password must be below 70 characters.")]
        public string Password { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Email must be below 20 characters.")]
        public string Email { get; set; }

        public List<User> Friends { get; set; } = new List<User>();

        public List<Game> Games { get; set; } = new List<Game>();

        private User()
        {

        }

        public User(string firstname, string lastname, int age, string username, string password, string email, List<User> friends = null, List<Game> games = null)
        {
            FirstName = firstname;
            LastName = lastname;
            Age = age;
            Username = username;
            Password = password;
            Email = email;
            Friends = friends;
            Games = games;
        }
    }
}
