using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoAngular2AspNetCore.BusinessLogic.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using StructureMap.Attributes;

namespace TodoAngular2AspNetCore.Controllers
{
    public abstract class BaseController: Controller
    {
        [SetterProperty]
        public IServiceProvider ServiceProvider { get; set; }
        protected TQuery GetQuery<TQuery>() where TQuery : IQuery
        {
            return ServiceProvider.GetService<TQuery>();
        }

        protected TCommand GetCommand<TCommand>() where TCommand : ICommand
        {
            return ServiceProvider.GetService<TCommand>();
        }
    }
}
