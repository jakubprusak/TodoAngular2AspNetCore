using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Core;

namespace TodoAngular2AspNetCore.Core.Infrastructure
{
    public static class IoCContainer
    {
        private static Autofac.IContainer _containerField;

        /// <summary>
        /// returns IoC container
        /// </summary>
        public static Autofac.IContainer Container
        {
            get
            {
                return _containerField;
            }
        }
    }
}
