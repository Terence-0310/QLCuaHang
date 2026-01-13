using System.Collections.Generic;

namespace QuanLyCuaHangRuou.BUS
{ 
    public class BusResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public static BusResult Ok(string msg = null) => new BusResult { Success = true, Message = msg };
        public static BusResult Fail(string msg) => new BusResult { Success = false, Message = msg };
    }


    public class BusResult<T> : BusResult
    {
        public T Data { get; set; }

        public static BusResult<T> Ok(T data, string msg = null) => new BusResult<T> { Success = true, Data = data, Message = msg };
        public new static BusResult<T> Fail(string msg) => new BusResult<T> { Success = false, Message = msg };
    }
}
