using Ironwood.Application.Accounts.Commands;
using Ironwood.Application.Users.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ironwood.UI.Models
{
    public class AccountSettingsVM
    {
        public UpdateProfileCommand UpdateProfile { get; set; }
        public ChangePasswordCommand ChangePassword { get; set; }
    }
}
