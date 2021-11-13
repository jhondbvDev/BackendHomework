using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendHomework.API.Response
{
    public class ResponseMessage<T>
    {
        public ResponseMessage(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
    }
}
