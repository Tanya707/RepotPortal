using Framework.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.Pages
{
    public class BaseContext(Browser browser)
    {
        protected readonly Browser browser = browser;
    }
}
