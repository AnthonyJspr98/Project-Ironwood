using Ironwood.Application.Common.Interfaces;
using Ironwood.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ironwood.UI.Common
{
    public class AppUser : ICurrentUser
    {
        public Guid UID { get; private set; }

        public Guid SessionUID { get; private set; }

        public User UserDetails { get; private set; }

        public AppUser(IHttpContextAccessor contextAccessor, IJsonSerializer jsonSerializer)
        {
            if (contextAccessor.HttpContext == null)
            {
                UserDetails = getEmptyUser();
                return;
            }

            var _currentUser = contextAccessor.HttpContext.User;

            if (_currentUser == null)
            {
                UserDetails = getEmptyUser();
                return;
            }

            ClaimsIdentity _claimsIdentity = _currentUser.Identity as ClaimsIdentity;
            Claim _claim = _claimsIdentity?.FindFirst(ClaimTypes.UserData);
            string _userData = _claim?.Value;

            if (string.IsNullOrWhiteSpace(_userData))
            {
                UserDetails = getEmptyUser();
                return;
            }

            try
            {
                UserDetails = jsonSerializer.Deserialize<User>(_userData);
            }
            catch
            {
                UserDetails = getEmptyUser();
            }

            Claim _sid = _claimsIdentity?.FindFirst(ClaimTypes.Sid);
            string _sidData = _sid?.Value;

            if (Guid.TryParse(_sidData, out Guid _sessionUID))
            {
                SessionUID = _sessionUID;
            }

            UID = UserDetails.UID;

        }

        private static User getEmptyUser()
        {
            return new User
            {
                //FirstName = ""
            };
        }

    }
}
