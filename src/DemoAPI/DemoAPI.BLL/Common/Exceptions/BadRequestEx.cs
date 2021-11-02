using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAPI.BLL.Common.Exceptions
{
    public class BadRequestEx:Exception
    {
        public ValidationResponse Response { get; private set; }
        public BadRequestEx(ValidationResponse res)
        {
            Response = res;
        }
    }
}
