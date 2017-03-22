using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAngular2AspNetCore.BusinessLogic.Infrastructure;
using TodoAngular2AspNetCore.Public;

namespace TodoAngular2AspNetCore.BusinessLogic.Todos
{
    public class GetTodoListQuery : QueryBase<List<TodoDto>, bool?>
    {
        public override List<TodoDto> Execute(bool? parameter)
        {
            return this.Db.Todo.Select(t=> new TodoDto
            {
                TodoId = t.TodoId,
                Done = t.Done,
                Name = t.Name
            }).ToList();
        }
    }
}
