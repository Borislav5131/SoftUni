﻿namespace _04.BorderControl
{
    public class Robot : IDentifible
    {
        public string Model { get; }
        public string Id { get; }

        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
        }
    }
}
