using Microsoft.AspNetCore.Mvc;
using TodoAPI.Models;
using TodoAPI.Repositories;

namespace TodoAPI.Controllers
{
    [ApiController]
    [Route("api/todo")]
    public class TodoController : ControllerBase
    {
        private readonly TodoRepository _repository = new TodoRepository();

        [HttpGet]
        public async Task<ActionResult<List<TodoItem>>> Get()
        {
            await Task.Delay(3000); // 3-second delay just if you want to show loader in screen :)
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
            Int64 todoId = _repository.Add(todo);
            todo.Id = todoId;
            return CreatedAtAction(nameof(Get), new { id = todoId }, todo);
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
            TodoItem updated = _repository.Update(todo);
            return Ok(updated);
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
