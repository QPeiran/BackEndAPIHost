using System.Collections.Generic;
using BackEndAPIHost.Models;

namespace BackEndAPIHost.Data
{
    public interface ICommanderRepo
    {
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
    }
}