using Microsoft.AspNetCore.Mvc;
using TodoAPI.Repositories;

namespace TodoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly TodoRepository _repository = new TodoRepository();

        [HttpGet]
        public ActionResult<List<TodoItem>> Get()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<TodoItem> Get(int id)
        {
            var todo = _repository.GetById(id);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }

        [HttpPost]
        public ActionResult Post([FromBody] TodoItem todo)
        {
            _repository.Add(todo);
            return CreatedAtAction(nameof(Get), new { id = todo.Id }, todo);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TodoItem todo)
        {
            var existingTodo = _repository.GetById(id);
            if (existingTodo == null)
            {
                return NotFound();
            }

            todo.Id = id;
            _repository.Update(todo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var existingTodo = _repository.GetById(id);
            if (existingTodo == null)
            {
                return NotFound();
            }

            _repository.Delete(id);
            return NoContent();
        }
    }
}
