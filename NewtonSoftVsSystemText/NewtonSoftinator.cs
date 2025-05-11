using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewtonSoftVsSystemText
{
    public static class NewtonSoftinator
    {
        public static string Serialize<T>(T obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }

        public static string Serialize<T>(T obj, JsonSerializerSettings settings)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj, settings);
        }

        public static T Deserialize<T>(string json)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return default;
            }
        }

        public static T Deserialize<T>(string json, JsonSerializerSettings settings)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json, settings);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return default;
            }
        }
    }
}
