using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using NuGet.Protocol;

namespace PostDemo.Api.Filters {
    public class ErrorModel {
        public string SessionID { get; set; }
        public string ErrorReason { get; set; }
        public bool IsCritical { get; set; }
    }

    public class ExceptionHandleAttribute : ExceptionFilterAttribute {
        public override void OnException(ExceptionContext context) {
            var errorModel = new ErrorModel();
            errorModel.SessionID = "1";//context.HttpContext.Session.Id;
            errorModel.ErrorReason = context.Exception.Message;
            errorModel.IsCritical = IsCriticalError(context.Exception);


            LogError(errorModel);


            var result = new JsonResult(errorModel);
            result.StatusCode = GetStatusCode(errorModel);

            LogError(errorModel);
            Log.Fatal($"{result.Value.ToJson()} - Status Code: {result.StatusCode} ");
            context.Result = result;
            context.ExceptionHandled = true;
        }

        private bool IsCriticalError(Exception ex) {

            return ex is InvalidOperationException;
        }

        private void LogError(ErrorModel errorModel) {
            Console.WriteLine($"Error: {errorModel.ErrorReason}");
        }

        private int GetStatusCode(ErrorModel errorModel) {
            return 500;
        }
    }

}
