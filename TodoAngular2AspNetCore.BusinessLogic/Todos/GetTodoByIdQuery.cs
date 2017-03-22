using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAngular2AspNetCore.BusinessLogic.Infrastructure;
using TodoAngular2AspNetCore.Public;

namespace TodoAngular2AspNetCore.BusinessLogic.Todos
{
    public class GetTodoByIdQuery : QueryBase<TodoDto, int>
    {
        public override TodoDto Execute(int todoId)
        {
            var todo = this.Db.Todo.Find(todoId);

            return new TodoDto
            {
                TodoId = todo.TodoId,
                Done = todo.Done,
                Name = todo.Name
            };
        }
    }
}
