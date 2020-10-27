using Ironwood.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ironwood.UI.Common
{
    public class AppJsonSerializer : IJsonSerializer
    {
        public T Deserialize<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }

        public string Serialize<T>(T data)
        {
            var _serializeSettings = new JsonSerializerSettings
            { 
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented
            };

            _serializeSettings.Converters.Add(new StringEnumConverter());

            return JsonConvert.SerializeObject(data, _serializeSettings);
        }
    }
}
