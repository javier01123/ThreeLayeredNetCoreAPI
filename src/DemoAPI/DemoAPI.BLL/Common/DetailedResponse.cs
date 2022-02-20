using System.Collections.Generic;

namespace DemoAPI.BLL.Common
{
    public class DetailedResponse
    {
        private const string NON_FIELD_ERRORS= "non_field_errors";
        Dictionary<string, List<string>> _errorDict = new();
        public Dictionary<string, List<string>> Errors { get => _errorDict; }

        public DetailedResponse() { }

        /// <summary>
        /// initialize an instace for a single error
        /// </summary>
        /// <param name="message"></param>
        private DetailedResponse(string message)
        {            
            AddError(NON_FIELD_ERRORS, message);        
        }

        /// <summary>
        /// init an instance with one error
        /// </summary>
        /// <param name="message"></param>
        public DetailedResponse(string property,string message)
        {
            AddError(property, message);
        }

        /// <summary>
        /// factory method for single error response
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public static DetailedResponse FromSingleError(string errorMessage)
        {
            return new DetailedResponse(errorMessage);                       
        }

        public void AddError(string property, string msg)
        {
            if (!_errorDict.ContainsKey(property))
                _errorDict.Add(property, new List<string>());
            _errorDict[property].Add(msg);
        }

    }
}
