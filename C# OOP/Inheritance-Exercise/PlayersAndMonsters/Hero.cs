﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    public class Hero
    {
        public string Username { get; set; }
        public int Level { get; set; }

        public Hero(string username, int level)
        {
            Username = username;
            Level = level;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Type: {this.GetType().Name} Username: {this.Username} Level: {this.Level}");

            return sb.ToString().TrimEnd();
        }
    }
}
