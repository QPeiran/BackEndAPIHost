using System.Collections.Generic;
using BackEndAPIHost.Models;

namespace BackEndAPIHost.Data
{
    public class MockApiCalls : ICommanderRepo
    {
        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
            {
                new Command{Id=0, HowTo="build an API hoster", Line="GET request", Platform = "webapp"},
                new Command{Id=1, HowTo="build API hosters", Line="POST request", Platform = "laptop"},
                new Command{Id=2, HowTo="build APIs hoster", Line="PUT request", Platform = "desktop"}
            };
            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command{Id=0, HowTo="build an API hoster", Line="GET request", Platform = "webapp"};
        }
    }
}