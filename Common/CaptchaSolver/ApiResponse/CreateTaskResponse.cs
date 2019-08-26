using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.CaptchaSolver.Helper;

namespace Common.CaptchaSolver.ApiResponse
{
    public class CreateTaskResponse
    {
        public CreateTaskResponse(dynamic json)
        {
            ErrorId = JsonHelper.ExtractInt(json, "errorId");

            if (ErrorId != null)
            {
                if (ErrorId.Equals(0))
                {
                    TaskId = JsonHelper.ExtractInt(json, "taskId");
                }
                else
                {
                    ErrorCode = JsonHelper.ExtractStr(json, "errorCode");
                    ErrorDescription = JsonHelper.ExtractStr(json, "errorDescription") ?? "(no error description)";
                }
            }
            else
            {
                DebugHelper.Out("Unknown error", DebugHelper.Type.Error);
            }
        }

        public int? ErrorId { get; private set; }
        public string ErrorCode { get; private set; }
        public string ErrorDescription { get; private set; }
        public int? TaskId { get; private set; }
    }
}
