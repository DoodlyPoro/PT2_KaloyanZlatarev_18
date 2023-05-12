using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<User> Users { get; set; } = new List<User>();

        public List<Genre> Genres { get; set; } = new List<Genre>();

        private Game()
        {

        }

        public Game(string name, List<User> users = null, List<Genre> genres = null)
        {
            Name = name;
            Users = users;
            Genres = genres;
        }
    }
}