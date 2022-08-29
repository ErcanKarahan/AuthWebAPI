using KGGames.CORE.Utilities.Abstract;
using KGGames.CORE.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGGames.CORE.Utilities.Concrete
{
    public class Result : IResult
    {
        public Result(ResultStatus status)
        {
            Status = status;
        }
        public Result(ResultStatus status, string message)
        {
            Status = status;
            Message = message;
        }
        public Result(ResultStatus status, string message, Exception exception)
        {
            Status = status;
            Message = message;
            Exception = exception;
        }

        public ResultStatus Status { get; }

        public string Message { get; }

        public Exception Exception { get; }
    }
}
