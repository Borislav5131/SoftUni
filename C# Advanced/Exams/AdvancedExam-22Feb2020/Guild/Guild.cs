using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        public List<Player> Roster { get; set; }
        public string Name { get; set; }
        public int  Capacity { get; set; }

        public int Count
        {
            get
            {
                return Roster.Count;
            }
        }


        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Roster = new List<Player>();
        }

        public void AddPlayer(Player player)
        {
            if (Roster.Count < Capacity)
            {
                Roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            return Roster.Remove(Roster.Where(x => x.Name == name).FirstOrDefault());
        }

        public void PromotePlayer(string name)
        {
            foreach (var player in Roster)
            {
                if (player.Name == name)
                {
                    if (player.Rank != "Member")
                    {
                        player.Rank = "Member";
                    }
                }
            }
        }

        public void DemotePlayer(string name)
        {
            foreach (var player in Roster)
            {
                if (player.Name == name)
                {
                    if (player.Rank != "Trial")
                    {
                        player.Rank = "Trial";
                    }
                }
            }
        }

        public Player[] KickPlayersByClass(string cclass)
        {
            var arr = Roster.Where(x => x.Class == cclass).ToArray();

            foreach (var player in arr)
            {
                Roster.Remove(player);
            }

            return arr;
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {Name}");

            foreach (var player in Roster)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }

    }
}
