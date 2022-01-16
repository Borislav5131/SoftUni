using System;

namespace CommandPattern.Core.Contracts
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] tokens = args.Split();
            string commandName = tokens[0];
            string[] commandsArgs = tokens[1..];

            ICommand command= default;

            if (commandName == "Hello")
            {
                command = new HelloCommand();
            }
            else if (commandName == "Exit")
            {
                command = new ExitCommand();
            }

            //TODO: check for null
            string result = command.Execute(commandsArgs);

            return result;
        }
    }
}    
