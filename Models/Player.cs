using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonsAndDragons
{
    public class Player
    {
        public int Id { get; set; }
        public string PlayerName { get; set; }
        public string Email { get; set; }
        public bool Alive { get; set; }
        public int PageProgress { get; set; }

    }
}
