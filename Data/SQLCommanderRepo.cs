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

        public void DeleteCommand(int id)
        {
            //Option 1: find the record first then remove
            //Pros: safe -- Identify whether it exist(or can be duplicate) first
            //Cons: slow -- searched all Id fields 
            // var targetToRemove = _db.Commands.SingleOrDefault(dummy => dummy.Id == id);
            // if (targetToRemove != null)
            // {
            //     _db.Commands.Remove(targetToRemove);
            //     return;
            // }
            // throw new ArgumentNullException(nameof(targetToRemove));
            // BTW, it is the same as using GetCommandById(id) defined in the controller
            //Option 2: specify the Id and just remove
            // How it works: 1. creat a null object Command except its Id set by id
            // 2. replace the old object with the newly created object -- resolve by input id 
            // 3. remove this newly created object, the the new DbSet is not containing the object with the specified Id
            // Con: Fast 
            var targetToRemove = new Command {Id = id};
            _db.Commands.Attach(targetToRemove);
            _db.Commands.Remove(targetToRemove);
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

        public void UpdateCommand(int id, Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            var target = _db.Commands.FirstOrDefault(dummy => dummy.Id == id);
            target.HowTo = cmd.HowTo;
            target.Line = cmd.Line;
            target.Platform = cmd.Platform;
        }
        public void UpdateCommand(Command cmd)
        {
            //it can be empty because options been automatically handled by Controller AutoMapper
        }
    }
}