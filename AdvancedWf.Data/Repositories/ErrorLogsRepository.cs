using AdvancedWf.Entities.Common;
 using Newtonsoft.Json;
using System;
using System.Web;

namespace AdvancedWf.Data.Repositories
{
    /// <summary>
    /// Repository resposible  for saving the error messages that occurs  durring  runing the system
    /// </summary>
    public class ErrorLogsRepository
    {

        /// <summary>
        /// Save new error message in database
        /// </summary>
        /// <param name="executionPath">Error Execution Path</param>
        /// <param name="param">Parameters if exist</param>
        /// <param name="exception">the exception that caused error</param>
        public void AddErrorLog(string executionPath, object param, Exception exception)
        {
            SaveLog(executionPath, param, exception);
        }

        /// <summary>
        /// Save new error message in database
        /// </summary>
        /// <param name="request">Current execution request</param>
        /// <param name="param">Parameters if exist</param>
        /// <param name="exception">the exception that caused error</param>
        public void AddErrorLog(HttpRequestBase request, object param, Exception exception)
        {
            SaveLog($"{request.HttpMethod}:{request.Path}", param, exception,request.UserHostAddress);
        }

        private string GetError(Exception e)
        {
            try
            {
                return JsonConvert.SerializeObject(e,
                    new JsonSerializerSettings {ReferenceLoopHandling = ReferenceLoopHandling.Ignore});
            }
            catch
            {
                return e.Message;
            }
        }

        private void SaveLog(string executionPath, object param, Exception exception,string extraData="")
        {
            try
            {
                var db = new AdvancedWfContext();
                db.ErrorLogs.Add(new ErrorLog
                {
                    Method = executionPath,
                    Exception = GetError(exception),
                    Param = JsonConvert.SerializeObject(param, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }),
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now,
                    AddtionalData = extraData ?? "Empty" 
              


            });
                db.SaveChanges();
            }
            catch (Exception)
            {
                try
                {
                    var db = new AdvancedWfContext();
                    db.ErrorLogs.Add(new ErrorLog
                    {
                        Method = executionPath,
                        Param = "EMPTY",
                        Exception = GetError(exception),
                        CreationDate = DateTime.Now,
                        ModificationDate = DateTime.Now,
                        AddtionalData = extraData ?? "Empty"
                    });
                    db.SaveChanges();
                }
                catch
                {
                    //Ignore
                }
            }
        }
    }
}
