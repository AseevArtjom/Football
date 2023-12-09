using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Position(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
