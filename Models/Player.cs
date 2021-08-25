using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonsAndDragons
{
    public class Player
    {
        public int Id { get; set; }
        [Required]
        public string PlayerName { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        public bool Alive { get; set; }
        public int PageProgress { get; set; }

    }
}
