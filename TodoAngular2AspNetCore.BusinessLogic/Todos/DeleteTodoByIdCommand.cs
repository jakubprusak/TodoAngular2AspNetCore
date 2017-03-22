using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAngular2AspNetCore.BusinessLogic.Infrastructure;

namespace TodoAngular2AspNetCore.BusinessLogic.Todos
{
    public class DeleteTodoByIdCommand : CommandBase<bool,int>
    {
        public override bool Execute(int todoId)
        {
            var item = this.Db.Todo.Find(todoId);
            this.Db.Remove(item);
            this.Db.SaveChanges();

            return true;
        }
    }
}
