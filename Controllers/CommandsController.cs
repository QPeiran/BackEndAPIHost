using System.Collections.Generic;
using BackEndAPIHost.Models;
using Microsoft.AspNetCore.Mvc;
using BackEndAPIHost.Data;

namespace BackEndAPIHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        public CommandsController(ICommanderRepo repository) // dependency injection
        {
            _repository = repository;
        }
        //private readonly MockApiCalls _repository = new MockApiCalls();
        //GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var commandsItems = _repository.GetAppCommands();

            return Ok(commandsItems);
        }
        //GET api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandById(int id)
        {
            var commandsItem = _repository.GetCommandById(id);
            return Ok(commandsItem);
        }
    }
}