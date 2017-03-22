using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TodoAngular2AspNetCore.Data;
using StructureMap.Attributes;

namespace TodoAngular2AspNetCore.BusinessLogic.Infrastructure
{
    public abstract class SystemFunction
    {
        [SetterProperty]
        public TodoDbContext Db { get; set; }

        public ILogger Logger { get; set; }
    }
}
