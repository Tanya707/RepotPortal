using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Settings
    {
        public ReportPortalUrl ReportPortalUrl { get; set; }
        public UserCredentials SuperadminUser { get; set; }
        public UserCredentials DefaultUser { get; set; }
    }
}
