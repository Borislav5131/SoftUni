using System;

namespace _07.ProjectsCreation
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string nameOfArchitect = Console.ReadLine();
            int countOfProjects = int.Parse(Console.ReadLine());

            int needHoursForOneProject = 3;
            int needHoursForProjects = countOfProjects * needHoursForOneProject;

            Console.WriteLine($"The architect {nameOfArchitect} will need {needHoursForProjects} hours to complete {countOfProjects} project/s.");
        }
    }
}
