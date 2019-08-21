using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace LSAutomation.Report
{
    public class ReportManager
    {

        private static ReportManager _instanse;

        private ExtentTest _extentTest;
        private ExtentTest _child;
        private static readonly object LockObj = new object();
        public ExtentTest Test => _child ?? _extentTest;

        public ExtentReports _extentReports;

        ReportManager()
        {
            _extentReports = new ExtentReports();
            var reporter = new ExtentHtmlReporter(Path.Combine(ReportsPathFactory.ReportsFolder, $"index.html"));
            _extentReports.AttachReporter(reporter);
        }

        public static ReportManager Report
        {
            get
            {
                lock (LockObj)
                {
                    if (_instanse == null)
                    {
                        _instanse = new ReportManager();
                    }
                }
                return _instanse;
            }
        }
        private ExtentTest GetExtentTest()
        {
            return _child ?? _extentTest;
        }
        public void StartTest(string name)
        {
            _extentTest = _extentReports.CreateTest(name);
        }

        public void EndTest()
        {
            _extentReports.RemoveTest(_extentTest);
        }
        public void Flush()
        {
            _extentReports.Flush();
        }
        public void Fail(Exception exception)
        {
            Test.Fail(ConvertToHtml(exception));
        }

        public void Error(Exception exception)
        {
            Test.Error(ConvertToHtml(exception));
        }
        public void Warning(Exception exception)
        {
            Test.Warning(ConvertToHtml(exception));
        }
        private static string ConvertToHtml(Exception exception)
        {
            var ex = exception.ToString();
            ex = ex
                .Replace("\"", "&quot;")
                .Replace("&", "&amp;")
                .Replace("<", "&lt;")
                .Replace(">", "&gt;")
                .Replace("\r\n", "<br/>");
            var result = $"{exception.GetType().Name}!<br/>{ex}";
            return result;
        }

        public void Info(string details)
        {
            Test.Info(details);
        }
    }
}
