using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAPI.DAL.Models
{
    public class ExceptionLog
    {
        public int ExceptionLogId { get; set; }
        public DateTime ErrorDate { get; set; }
        public string Message { get; set; }
        public string InnerException { get; set; }
        public string StackTracker { get; set; }
    }
}
