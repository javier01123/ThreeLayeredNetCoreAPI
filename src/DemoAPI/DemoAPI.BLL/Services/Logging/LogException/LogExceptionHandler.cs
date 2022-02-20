using DemoAPI.DAL;
using DemoAPI.DAL.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DemoAPI.BLL.Services.Logging.LogException
{
    public class LogExceptionHandler : IRequestHandler<LogExceptionCmd>
    {
        DemoAPIContext _ctx;
        public LogExceptionHandler(DemoAPIContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Unit> Handle(LogExceptionCmd request, CancellationToken cancellationToken)
        {
            var newLogEntry = new ExceptionLog()
            {
                ErrorDate = DateTime.Now,
                InnerException = request.InnerException,
                Message = request.Message,
                StackTracker = request.StackTrace,
            };

            _ctx.ChangeTracker.Clear();
            _ctx.Add(newLogEntry);
            await _ctx.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
