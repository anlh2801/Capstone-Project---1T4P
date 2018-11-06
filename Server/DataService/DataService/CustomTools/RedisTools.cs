using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Redis;

namespace DataService.CustomTools
{
    public class RedisTools
    {
        public const string host = "35.197.154.50:6379";

        public bool Save(string key, object value)
        {
            bool isSuccess = false;
            using (RedisClient redisClient = new RedisClient(host))
            {
                if (redisClient.Get<string>(key) == null)
                {
                    isSuccess = redisClient.Set(key, value);
                }
            }
            return isSuccess;
        }

        public object Get(string key)
        {
            using (RedisClient redisClient = new RedisClient(host))
            {
                return redisClient.Get<string>(key);
            }
        }

        public void Clear(string key)
        {
            using (RedisClient redisClient = new RedisClient(host))
            {
                redisClient.Del(key);
            }
        }
    }
}
