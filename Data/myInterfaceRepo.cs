using System.Collections.Generic;
using BackEndAPIHost.Models;

namespace BackEndAPIHost.Data
{
    public interface ICommanderRepo
    {
        bool SaveChanges();
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
        void CreateCommand(Command cmd);
        void UpdateCommand(Command cmd);
    }
}