using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Infrastructure.Dispatchers
{
    public record QueryResult<TResult>
    {
        public bool Successful { get; init; }
        public TResult Result { get; init; }
        public string ErrorCode { get; init; }


        private QueryResult(bool successful, TResult result, string errorCode)
        {
            Successful = successful;
            Result = result;
            ErrorCode = errorCode;
        }


        public static QueryResult<TResult> Succes(TResult result)
        {
            return new QueryResult<TResult>(true, result, string.Empty);
        }

        public static QueryResult<TResult> Failure(string errorCode)
        {
            return new QueryResult<TResult>(false, default, errorCode);
        }
    }
}
