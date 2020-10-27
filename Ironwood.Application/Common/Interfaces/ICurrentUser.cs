using Ironwood.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ironwood.Application.Common.Interfaces
{
    public interface ICurrentUser
    {
        Guid UID { get; }

        Guid SessionUID { get; }

        User UserDetails { get; }

    }
}
