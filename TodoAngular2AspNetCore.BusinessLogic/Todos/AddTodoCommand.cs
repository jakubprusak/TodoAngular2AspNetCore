using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAngular2AspNetCore.BusinessLogic.Infrastructure;
using TodoAngular2AspNetCore.Data.Entities;
using TodoAngular2AspNetCore.Public;

namespace TodoAngular2AspNetCore.BusinessLogic.Todos
{
    public class AddTodoCommand : CommandBase<TodoDto, TodoDto>
    {

        public override TodoDto Execute(TodoDto parameter)
        {
            var entity = new Todo
            {
                TodoId = parameter.TodoId,
                Name = parameter.Name,
                Done = parameter.Done
            };
            this.Db.Todo.Add(entity);

            this.Db.SaveChanges();

            parameter.TodoId = entity.TodoId;

            return parameter;
        }
    }
}
