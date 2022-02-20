using System;

namespace DemoAPI.BLL.Common.Exceptions
{
    public class BadRequestEx : Exception
    {
        public DetailedResponse DetailedResponse { get; private set; }


        private BadRequestEx() { }

        public BadRequestEx(string message)
        {
            this.DetailedResponse = DetailedResponse.FromSingleError(message);
        }

        public BadRequestEx(DetailedResponse res)
        {
            DetailedResponse = res;
        }
    }
}
