using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAngular2AspNetCore.BusinessLogic.Infrastructure
{
    public abstract class CommandBase<TResult, TParam> : SystemFunction, ICommand
    {
        public abstract TResult Execute(TParam parameter);
    }
}
