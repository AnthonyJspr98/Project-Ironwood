using Ironwood.Application.Common.Interfaces;
using Ironwood.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ironwood.Application.Users.Commands
{
    public class UpdateProfileCommand : IRequest
    {
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public DateTime? BirthDate { get; set; }
        public Gender? Gender { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string HouseNumAndStreet { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public class UpdateProfileCommandHandler : AsyncRequestHandler<UpdateProfileCommand>
        {
            private readonly IMediator mediator;
            private readonly IIronwoodDbContext dbContext;
            private readonly ICurrentUser currentUser;

            public UpdateProfileCommandHandler(IMediator mediator, IIronwoodDbContext dbContext, ICurrentUser currentUser)
            {
                this.mediator = mediator;
                this.dbContext = dbContext;
                this.currentUser = currentUser;
            }

        
            protected override async Task Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
            {
                var _userData = await dbContext.Users
                     .Include(a => a.UserLogin)
                     .Include(a => a.Wallet)
                     .SingleOrDefaultAsync(a => a.UID == currentUser.UID);

                if (_userData == null)
                {
                    throw new Exception("User not exist");
                }

                _userData.FirstName = request.Firstname;
                _userData.MiddleName = request.Middlename;
                _userData.LastName = request.Lastname;
                _userData.BirthDate = request.BirthDate;
                _userData.Gender = request.Gender;
                _userData.MobileNumber = request.MobileNumber;
                _userData.Address = request.HouseNumAndStreet;
                _userData.City = request.City;
                _userData.Country = request.Country;
            }
        }
    }
}
