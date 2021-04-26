using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kcs.Blog.Abstraction.HealthChecks
{
    public class HealthCheck
    {
        public string Status { get; set; }
        public string Component { get; set; }
        public string Description { get; set; }
    }
}
