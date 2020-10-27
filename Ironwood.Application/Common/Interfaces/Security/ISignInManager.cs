using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ironwood.Application.Common.Interfaces.Security
{
    public interface ISignInManager
    {
        Task PasswordSignInAsync(string usernameOrEmail, string password);

        Task SignInAsync(string usernameOrEmail);

        Task ImpersonateAsync(string userName);

        Task SignOutImpersonateAsync();

        Task SignOutAsync();
    }
}
