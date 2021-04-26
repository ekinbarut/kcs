using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kcs.Blog.Abstraction.HealthChecks
{
    public class HealthCheckResponse
    {
        public string Status { get; set; }
        public IEnumerable<HealthCheck> Checks { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
