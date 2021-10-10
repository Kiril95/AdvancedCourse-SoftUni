using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        public List<Player> Roster;
        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Roster = new List<Player>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        
        public int Count => this.Roster.Count;

        public void AddPlayer(Player player)
        {
            if (Capacity > Count)
            {
                this.Roster.Add(player);
            }
        }
        public bool RemovePlayer(string name)
        {
            if (Roster.Any(x => x.Name == name))
            {
                var target = Roster.FirstOrDefault(x => x.Name == name);
                Roster.Remove(target);
                return true;
            }

            return false;
        }
        public void PromotePlayer(string name)
        {
            if (Roster.Any(x => x.Name == name))
            {
                var target = Roster.Find(x => x.Name == name);
                if (target.Rank != "Member")
                {
                    target.Rank = "Member";
                }
            }
        }
        public void DemotePlayer(string name)
        {
            if (Roster.Any(x => x.Name == name))
            {
                var target = Roster.Find(x => x.Name == name);
                if (target.Rank != "Trial")
                {
                    target.Rank = "Trial";
                }
            }
        }
        public Player[] KickPlayersByClass(string @class)
        {
            Player[] targetPlayers = Roster.Where(x => x.Class == @class).ToArray();

            foreach (var target in targetPlayers)
            {
                Roster.Remove(target);
            }

            return targetPlayers;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {this.Name}");

            foreach (var player in this.Roster)
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
