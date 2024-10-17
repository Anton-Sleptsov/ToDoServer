using Microsoft.AspNetCore.Mvc;
using ToDoServer.Data.Repositories;
using ToDoServer.Mappers;
using ToDoServer.Models;

namespace ToDoServer.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ToDoController : Controller
    {
        private readonly ToDoMapper _mapper;
        private readonly ToDoRepository _repository;

        public ToDoController(ToDoMapper mapper, ToDoRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Create(ToDoCreateModel model)
        {
            var dataModel = _mapper.BuildDataModel(model);
            var createdModel = _repository.CreateToDo(dataModel);

            return Ok(createdModel);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var toDos = _repository.GetAllToDos();

            return Ok(toDos);
        }

        [HttpPatch]
        [Route("{id}")]
        public IActionResult UpdateStatus(int id)
        {
            var updatedToDo = _repository.ToggleToDoStatus(id);

            if(updatedToDo is null) 
            {
                return NotFound();
            }

            return Ok(updatedToDo);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var isDeleted = _repository.DeleteToDo(id);

            if (!isDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
