using System;
using System.Collections.Generic;

namespace _05.TeamworkProjects
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int countOfTeams = int.Parse(Console.ReadLine());

            List<Team> teams = new List<Team>();

            for (int i = 1; i <= countOfTeams; i++)
            {
                string[] tokens = Console.ReadLine().Split("-");
                string user = tokens[0];
                string teamName = tokens[1];
                string creator = tokens[0];

                Team team = new Team();

                team.User = user;
                team.Creator = user;
                team.TeamName = teamName;

                teams.Add(team);

                Console.WriteLine($"Team {team.TeamName} has been created by {team.User}!");
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of assignment")
                {
                    break;
                }

                string[] tokens = input.Split("->");
                string userWantToJoin = tokens[0];
                string wantedTeam = tokens[1];

                if (IfTeamExist(teams, wantedTeam))
                {
                    Console.WriteLine($"Team {wantedTeam} was already created!");
                }
                if (IfCreatorExist(teams, userWantToJoin))
                {
                    Console.WriteLine($"{userWantToJoin} cannot create another team!");
                }
                if (!IfTeamExist(teams,wantedTeam))
                {
                    Console.WriteLine($"Team {wantedTeam} does not exist!");
                }
                if (IfUserExist(teams, userWantToJoin))
                {
                    Console.WriteLine($"Member {userWantToJoin} cannot join team {wantedTeam}!");
                }

            }
        }

        private static bool IfUserExist(List<Team> teams, string userWantToJoin)
        {
            foreach (var kvp in teams)
            {
                if (userWantToJoin == kvp.User)
                {
                    return true;
                }
            }
            return false;
        }

        private static bool IfCreatorExist(List<Team> teams, string userWantToJoin)
        {
            foreach (var kvp in teams)
            {
                if (userWantToJoin == kvp.Creator)
                {
                    return true;
                }
            }
            return false;
        }

        private static bool IfTeamExist(List<Team> teams, string team)
        {
            foreach (var kvp in teams)
            {
                if (team == kvp.TeamName)
                {
                    return true;
                }
            }

            return false;
        }
    }
    class Team
    {
        public string User { get; set; }
        public string TeamName { get; set; }
        public string Creator { get; set; }
    }
}
