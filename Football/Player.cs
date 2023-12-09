using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football
{
    public class Player
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Country { get; set; }
        public int Number { get; set; }

        public Player()
        {

        }

        public Player(int id, string fullName, string country, int number)
        {
            Id = id;
            FullName = fullName;
            Country = country;
            Number = number;
        }
    }
}
