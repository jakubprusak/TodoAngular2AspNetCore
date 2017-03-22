using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TodoAngular2AspNetCore.BusinessLogic.Todos;
using TodoAngular2AspNetCore.Public;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoAngular2AspNetCore.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : BaseController
    {
        private  readonly ILogger<TodoController> _logger;
        public TodoController(ILogger<TodoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<TodoDto> Get()
        {
            _logger.LogInformation("Getting todoList");
            return GetQuery<GetTodoListQuery>().Execute(null);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public TodoDto Get(int id)
        {
            var result = base.GetQuery<GetTodoByIdQuery>().Execute(id);

            return result;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]TodoDto todo)
        {
            this.GetCommand<AddTodoCommand>().Execute(todo);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.GetCommand<DeleteTodoByIdCommand>().Execute(id);
        }
    }
}
