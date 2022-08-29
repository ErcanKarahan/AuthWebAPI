using KGGames.CORE.Utilities.Abstract;
using KGGames.CORE.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGGames.CORE.Utilities.Concrete
{
    public class DataResult<T> : IDataResult<T>
    {
        public DataResult(ResultStatus status, T data)
        {
            Status = status;
            Data = data;
        }
        public DataResult(ResultStatus status, string message, T data)
        {
            Status = status;
            Message = message;
            Data = data;
        }
        public DataResult(ResultStatus status, Exception ex, string message, T data)
        {
            Status = status;
            Message = message;
            Data = data;
            Exception = ex;
        }
        public T Data { get; }

        public ResultStatus Status { get; }

        public string Message { get; }

        public Exception Exception { get; }

    }

   
}
