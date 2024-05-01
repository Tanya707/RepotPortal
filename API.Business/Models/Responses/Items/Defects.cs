using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Business.Models.Responses.Items
{
    public class Defects
    {
        public ProductBug ProductBug { get; set; }
        public ToInvestigate ToInvestigate { get; set; }
        public AutomationBug AutomationBug { get; set; }
    }
}
