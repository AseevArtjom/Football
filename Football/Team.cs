using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        public Team()
        {

        }
        
        public Team(int id,string name,string country)
        {
            Id = id;
            Name = name;
            Country = country;
        }
    }
}
