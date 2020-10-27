using System;
using System.Collections.Generic;
using System.Text;

namespace Ironwood.Application.Common.Interfaces.Security
{
    public interface IPasswordHasher
    {
        byte[] GenerateSalt();

        byte[] HashPassword(byte[] salt, string password);

        bool IsPasswordVerified(byte[] salt, byte[] hashedPassword, string password);
    }
}
