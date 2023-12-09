using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football
{
    public class Match
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FirstTeamId { get; set; }
        public int SecondTeamId { get; set; }
        public int GoalsFirstTeam { get; set; }
        public int GoalsSecondTeam { get; set; }
        public int WhoGoal { get; set; }
        public DateTime PlayingDate { get; set; }

        public Match()
        {

        }
       
        public Match(int id,string name,int firstgoals,int secondgoals,DateTime PlayingDate)
        {
            this.Id = id;
            this.Name = name;
            this.GoalsFirstTeam = firstgoals;
            this.GoalsSecondTeam = secondgoals;
            this.PlayingDate = PlayingDate;
        }
    }
}
