using Ironwood.Application.Common.Interfaces;
using Ironwood.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ironwood.Application.Vouchers.Commands
{
    public class CreateVoucherCodeCommand : IRequest<Voucher>
    {
        public decimal Value { get; set; }
        public class CreateVoucherCodeCommandHandler : IRequestHandler<CreateVoucherCodeCommand, Voucher>
        {
            private readonly IIronwoodDbContext dbContext;
            private readonly IMediator mediator;
            private readonly ICurrentUser currentUser;
            
            public CreateVoucherCodeCommandHandler(IIronwoodDbContext dbContext, IMediator mediator, ICurrentUser currentUser)
            {
                this.mediator = mediator;
                this.dbContext = dbContext;
                this.currentUser = currentUser;
                
            }
            public async Task<Voucher> Handle(CreateVoucherCodeCommand request, CancellationToken cancellationToken)
            {

                var _voucher = new Voucher
                { 
                    Code = GenerateVoucherCode(),
                    IsRedeemed = false,
                    UID = Guid.NewGuid(),
                    Value = request.Value,
                    CreatedOn = DateTime.Now,
                    CreatedBy = currentUser.UID
                };

                dbContext.Vouchers.Add(_voucher);

                return _voucher;
            }

            private string GenerateVoucherCode()
            {
                Random random = new Random();
                var builder = new StringBuilder(10);


                char[] keys = "A0BC1DE2FG3HI4JK5LM6NP7QR8ST9UVW0XYZ".ToCharArray();

                for (int i = 0; i < 10; i++)
                {
                    var randomChar = keys[random.Next(0, keys.Length - 1)];
                    builder.Append(randomChar);
                }

                return builder.ToString();
            }
        }
    }
}
