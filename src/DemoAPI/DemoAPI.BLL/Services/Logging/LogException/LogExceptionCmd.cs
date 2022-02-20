using FluentValidation;
using MediatR;
using System;

namespace DemoAPI.BLL.Services.Logging.LogException
{
    public class LogExceptionCmd : IRequest
    {
        public string Message { get; set; }
        public string InnerException { get; set; }
        public string StackTrace { get; set; }

        public static LogExceptionCmd FromException(Exception ex)
        {
            return new LogExceptionCmd()
            {
                Message = ex.Message,
                InnerException = ex.InnerException?.ToString(),
                StackTrace = ex.StackTrace,
            };
        }
    }

    public class LogExceptionValidator : AbstractValidator<LogExceptionCmd>
    {
        public LogExceptionValidator()
        {
            RuleFor(x => x.Message).NotEmpty();
            RuleFor(x => x.StackTrace).NotEmpty();
        }
    }
}
