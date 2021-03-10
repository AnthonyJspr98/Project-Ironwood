using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ironwood.Application.Common.Interfaces;
using Ironwood.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ironwood.Application.Matches.Queries
{
    public class GetAllMatchCategoriesQuery : IRequest<IEnumerable<Category>>
    {
        public class GetAllMatchCategoriesQueryHandler : IRequestHandler<GetAllMatchCategoriesQuery, IEnumerable<Category>>
        {
            private readonly IIronwoodDbContext dbContext;
            public GetAllMatchCategoriesQueryHandler(IIronwoodDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<IEnumerable<Category>> Handle(GetAllMatchCategoriesQuery request, CancellationToken cancellationToken)
            {
                var _allCategories = await dbContext.Categories.ToListAsync();

                return _allCategories;
            }
        }
    }
}