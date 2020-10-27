using System;
using System.Collections.Generic;
using System.Text;

namespace Ironwood.Application.Common.Interfaces
{
    public interface IJsonSerializer
    {
        T Deserialize<T>(string data);
        string Serialize<T>(T data);
    }
}
