using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAPI.BLL.Common
{
    public class ValidationResponse
    {
        Dictionary<string, List<string>> _errors = new();

        public Dictionary<string, List<string>> Errors { get => _errors; }

        public void AddError(string property, string msg)
        {
            if (!_errors.ContainsKey(property))
                _errors.Add(property, new List<string>());
            _errors[property].Add(msg);
        }

    }
}
