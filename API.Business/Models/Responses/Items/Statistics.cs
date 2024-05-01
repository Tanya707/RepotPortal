using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Business.Models.Responses.Items
{
    public class Statistics
    {
        public Executions Executions { get; set; }
        public Defects Defects { get; set; }
    }
}
