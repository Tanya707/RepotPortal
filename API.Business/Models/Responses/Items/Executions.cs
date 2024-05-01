using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Business.Models.Responses.Items
{
    public class Executions
    {
        public int Total { get; set; }
        public int Passed { get; set; }
        public int Failed { get; set; }
    }
}
