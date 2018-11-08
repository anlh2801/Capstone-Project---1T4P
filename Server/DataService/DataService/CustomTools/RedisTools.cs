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

        public bool Save(string key, Queue<RenderITSupporterListWithWeight> queue)
        {
            bool isSuccess = false;

            using (RedisClient redisClient = new RedisClient(host))
            {
                isSuccess = redisClient.Set(key, queue);
            }

            return isSuccess;
        }


        public string Get(string key)
        {
            using (RedisClient redisClient = new RedisClient(host))
            {
                var list = redisClient.GetValue(key);

                return list;
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
