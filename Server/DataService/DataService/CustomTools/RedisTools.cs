using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ServiceStack.Redis;

namespace DataService.CustomTools
{
    public class RedisTools
    {
        public const string host = "35.197.154.50:6379";

        private bool Save(string host, string key, List<object> list)

        {

            bool isSuccess = false;

            var redisClient = new RedisClient();

            if (redisClient.Get<string>(key) == null)
            {

                isSuccess = redisClient.Set(key, list);

            }
            return isSuccess;
        }




        private static string Get(string host, string key)
        {
            var redisClient = new RedisClient(host);
            var list = redisClient.GetValue(key);

            return list;
        }

        public static void Clear(string host, string key)
        {
            var redisClient = new RedisClient(host);
            redisClient.Del(key);
        }
    }

}
