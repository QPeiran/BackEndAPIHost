using System.Collections.Generic;
using System.Linq;
using BackEndAPIHost.Models;

namespace BackEndAPIHost.Data
{
    public class SQLCommanderRepo : ICommanderRepo
    {
        private readonly CommanderContext _db;
        public SQLCommanderRepo(CommanderContext db)
        {
            _db = db;
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _db.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _db.Commands.FirstOrDefault(dummy => dummy.Id == id);
        }
    }
}