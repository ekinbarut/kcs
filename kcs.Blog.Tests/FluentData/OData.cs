using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kcs.Blog.Tests.FluentData
{
    public class OData<T>
    {
        [JsonProperty("odata.metadata")]
        public string Metadata { get; set; }
        public List<T> Value { get; set; }
    }
}
