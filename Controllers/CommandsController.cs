using System.Collections.Generic;
using BackEndAPIHost.Models;
using Microsoft.AspNetCore.Mvc;
using BackEndAPIHost.Data;
using AutoMapper;
using BackEndAPIHost.DTOs;
using Microsoft.AspNetCore.JsonPatch;

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
        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDTO> GetCommandById(int id)
        {
            var commandsItem = _repository.GetCommandById(id);
            if (commandsItem != null)
            {
                var myObj = _mapper.Map<CommandReadDTO>(commandsItem);
                return Ok(myObj);
            }
            return NotFound();
        }
        [HttpPost]
        public ActionResult<CommandCreateDTO> CreateCommand(CommandCreateDTO newcmd)
        {
            var newDTO = _mapper.Map<Command>(newcmd);
            _repository.CreateCommand(newDTO);
            if(_repository.SaveChanges())
            {
                // return Ok();
                var returnObj = _mapper.Map<CommandReadDTO>(newDTO);
                //return Ok(returnObj);
                return CreatedAtRoute(nameof(GetCommandById), new {Id = returnObj.Id}, returnObj);
            }
            return BadRequest();
        }

        /*TODO:
        1.Update repository interface
        2.Update Interface implenmentation
        3.create CommandUpdateDTO
        4.create & return a PUT ActionResult
        */
        [HttpPut("{id}")]
        public ActionResult<CommandUpdateDTO> PutMethodById(int id, CommandUpdateDTO newcmd)
        {
            var commandsItem = _repository.GetCommandById(id);
            if (commandsItem != null)
            {
                var newDTO = _mapper.Map<Command>(newcmd);
                _repository.UpdateCommand(id, newDTO);
                if(_repository.SaveChanges())
                {
                    // return Ok();
                    var returnObj = _mapper.Map<CommandReadDTO>(newDTO);
                    returnObj.Id = id;
                    //return Ok(returnObj);
                    return CreatedAtRoute(nameof(GetCommandById), new {Id = returnObj.Id}, returnObj);
                }
                throw new System.ArgumentException("Save Failed", "original"); 
            }
            /*Option 2:
            _mapper.Map(newcmd, commandsItem);
            _repository.UpdateCommand(commandsItem);
            _repository.SaveChanges();
            */
            return NotFound();           
        }
        // PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult<JsonPatchDocument<CommandUpdateDTO>> PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDTO> patchDoc)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            var commandToPatch = _mapper.Map<CommandUpdateDTO>(commandModelFromRepo); // .Map<target>(source)
            patchDoc.ApplyTo(commandToPatch, ModelState);
            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(commandToPatch, commandModelFromRepo);
            _repository.UpdateCommand(commandModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}