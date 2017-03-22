using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAngular2AspNetCore.Public
{
    public class TodoDto
    {
        public int TodoId { get; set; }
        public string Name { get; set; }
        public bool Done { get; set; }
    }
}
