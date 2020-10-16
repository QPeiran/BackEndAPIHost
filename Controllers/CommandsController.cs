using System.Collections.Generic;
using BackEndAPIHost.Models;
using Microsoft.AspNetCore.Mvc;
using BackEndAPIHost.Data;
using AutoMapper;
using BackEndAPIHost.DTOs;

namespace BackEndAPIHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;
        public CommandsController(ICommanderRepo repository, IMapper mapper) // dependency injection
        {
            _repository = repository;
            _mapper = mapper;
        }
        //private readonly MockApiCalls _repository = new MockApiCalls();
        //GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDTO>> GetAllCommands()
        {
            var commandsItems = _repository.GetAllCommands();

            return Ok(_mapper.Map<IEnumerable<CommandReadDTO>>(commandsItems));
        }
        //GET api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult<CommandReadDTO> GetCommandById(int id)
        {
            var commandsItem = _repository.GetCommandById(id);
            if (commandsItem != null)
            {
                return Ok(_mapper.Map<CommandReadDTO>(commandsItem));
            }
            return NotFound();
        }
        [HttpPost]
        public ActionResult<Command> CreateCommand(Command ncmd)
        {
            // _repository.CreateCommand(ncmd);
            // _repository.SaveChanges();
            return NotFound();
        }
    }
}