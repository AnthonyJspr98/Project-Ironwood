using System;
using System.Threading;
using System.Threading.Tasks;
using Ironwood.Application.Common.Interfaces;
using Ironwood.Domain.Entities;
using MediatR;

namespace Ironwood.Application.Matches.Commands
{
    public class RegisterMatchCategoryCommand : IRequest<Category>
    {
        //
        public string CategoryName { get; set; }
        public string Details { get; set; }
        //
        public class RegisterMatchCategoryCommandHandler : IRequestHandler<RegisterMatchCategoryCommand, Category>
        {
            private readonly IIronwoodDbContext dbContext;
            private readonly IMediator mediator;
            private readonly ICurrentUser currentUser;

            public RegisterMatchCategoryCommandHandler(IIronwoodDbContext dbContext, IMediator mediator, ICurrentUser currentUser)
            {
                this.dbContext = dbContext;
                this.mediator = mediator;
                this.currentUser = currentUser;
            }
            public async Task<Category> Handle(RegisterMatchCategoryCommand request, CancellationToken cancellationToken)
            {
                Category _matchCategory = new Category
                {
                    UID = Guid.NewGuid(),
                    Name = request.CategoryName,
                    Details = request.Details
                };

                dbContext.Categories.Add(_matchCategory);

                return _matchCategory;
            }
        }
    }
}