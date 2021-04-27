using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Infrastructure.Dispatchers
{
    public record CommandResult
    {
        public bool Successful { get; init; }
        public string ErrorCode { get; init; }


        private CommandResult(bool successful, string errorCode)
        {
            Successful = successful;
            ErrorCode = errorCode;
        }


        public static CommandResult Succes()
        {
            return new CommandResult(true, string.Empty);
        }

        public static CommandResult Failure(string errorCode)
        {
            return new CommandResult(false, errorCode);
        }
    }
}
