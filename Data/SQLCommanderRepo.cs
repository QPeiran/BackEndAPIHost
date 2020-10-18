using System.Collections.Generic;
using System.Linq;
using BackEndAPIHost.Models;
using System;

namespace BackEndAPIHost.Data
{
    public class SQLCommanderRepo : ICommanderRepo
    {
        private readonly CommanderContext _db;
        public SQLCommanderRepo(CommanderContext db)
        {
            _db = db;
        }

        public void CreateCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _db.Commands.Add(cmd);
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _db.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _db.Commands.FirstOrDefault(dummy => dummy.Id == id);
        }

        public bool SaveChanges()
        {
            return (_db.SaveChanges() >= 0);
        }

        public void UpdateCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            var target = _db.Commands.FirstOrDefault(dummy => dummy.Id == cmd.Id);
            target.HowTo = cmd.HowTo;
            target.Line = cmd.Line;
            target.Platform = cmd.Platform;
        }
    }
}