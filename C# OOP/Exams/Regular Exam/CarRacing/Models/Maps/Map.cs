using System;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerOne.IsAvailable())
            {
                return "Race cannot be completed because both racers are not available!";
            }
            else if (!racerOne.IsAvailable())
            {
                return $"{racerTwo.Username} wins the race! {racerOne.Username} was not available to race!";
            }
            else if (!racerTwo.IsAvailable())
            {
                return $"{racerOne.Username} wins the race! {racerTwo.Username} was not available to race!";
            }

            

            
            double oneBehavior;
            double twoBehabior;

            if (racerOne.RacingBehavior == "strict")
            {
                oneBehavior = 1.2;
            }
            else 
            {
                oneBehavior = 1.1;
            }

            if (racerTwo.RacingBehavior == "strict")
            {
                twoBehabior = 1.2;
            }
            else 
            {
                twoBehabior = 1.1;
            }

            double chanceOfWinningOne = racerOne.Car.HorsePower * racerOne.DrivingExperience * oneBehavior;
            racerOne.Race();
            double chanceOfWinningTwo = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * twoBehabior;

            racerTwo.Race();

            if (chanceOfWinningOne > chanceOfWinningTwo)
            {
                return $"{racerOne.Username} has just raced against {racerTwo.Username}! {racerOne.Username} is the winner!";
            }
            else 
            {
                return $"{racerOne.Username} has just raced against {racerTwo.Username}! {racerTwo.Username} is the winner!";
            }
        }
    }
}
