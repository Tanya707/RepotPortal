using API.Business.Models.Requests.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Business.Models
{
    public class ApiRequest
    {
        public string NameOfProject { get; set; }
        public int LaunchNumber { get; set; }
        public object BodyOfRequest { get; set; }
    }
}
