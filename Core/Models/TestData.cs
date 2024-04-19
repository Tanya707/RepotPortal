using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class TestData
    {
        public IEnumerable<string> LaunchName { get; set; }
        public IEnumerable<string> Passed { get; set; }
        public IEnumerable<string> Total { get; set; }
    }
}
