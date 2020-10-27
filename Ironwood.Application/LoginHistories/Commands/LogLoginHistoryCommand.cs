using Ironwood.Application.Common.Interfaces;
using Ironwood.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ironwood.Application.LoginHistories.Commands
{
    public class LogLoginHistoryCommand : IRequest
    {
        public UserLogin Login { get; set; }
        public string IP { get; set; }

        public class LogLoginHistoryCommandHandler : AsyncRequestHandler<LogLoginHistoryCommand>
        {
            private readonly IIronwoodDbContext dbContext;
            private readonly IMediator mediator;

            public LogLoginHistoryCommandHandler(IMediator mediator, IIronwoodDbContext dbContext)
            {
                this.dbContext = dbContext;
                this.mediator = mediator;
            }
            protected override async Task Handle(LogLoginHistoryCommand request, CancellationToken cancellationToken)
            {
                request.Login.LoginHistory.Add(new LoginHistory
                { 
                    IP = request.IP,
                    LoggedOn = DateTime.Now
                });
            }
        }
    }
}
