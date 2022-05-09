using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Br.Com.FactIO.Application.Models
{
    public class OperationResult<T>
    {
        public T Payload { get; set; }
        public bool IsError { get; set; }
        public List<Error> Errors { get; } = new List<Error>();

        public void AddError(int code, string message)
        {
            HandleError(code, message);
        }

        public void ResetIsErrorFlag()
        {
            IsError = false;
        }

        private void HandleError(int code, string message)
        {
            Errors.Add(new Error { ErrorCode = code, Message = message });
        }
    }
}
