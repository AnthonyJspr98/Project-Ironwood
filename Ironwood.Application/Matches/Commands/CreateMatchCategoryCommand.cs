using System;
using System.Threading;
using System.Threading.Tasks;
using Ironwood.Application.Common.Interfaces;
using Ironwood.Domain.Entities;
using MediatR;

namespace Ironwood.Application.Matches.Commands
{
    public class CreateMatchCategoryCommand : IRequest<Category>
    {
        //
        public string CategoryName { get; set; }
        public string Details { get; set; }
        //
        public class CreateMatchCategoryCommandHandler : IRequestHandler<CreateMatchCategoryCommand, Category>
        {
            private readonly IIronwoodDbContext dbContext;
            public CreateMatchCategoryCommandHandler(IIronwoodDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<Category> Handle(CreateMatchCategoryCommand request, CancellationToken cancellationToken)
            {
                var _matchCategory = new Category
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