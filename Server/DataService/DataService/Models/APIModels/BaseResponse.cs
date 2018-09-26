using DataService.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Models.APIModels
{
    public class BaseResponse<T> where T : class
    {
        [JsonProperty("result-code")]
        public int ResultCode { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("data")]
        public T Data { get; set; }

        public static BaseResponse<string> GetInternalServerError(Exception ex, string messagePrefix)
        {
            return new BaseResponse<string>()
            {
                ResultCode = (int)ResultEnum.InternalError,
                Success = false,
                Message = messagePrefix,
                Data = ex.ToString()
            };
        }

    }
}
