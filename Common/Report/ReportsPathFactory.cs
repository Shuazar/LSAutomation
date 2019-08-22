using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Report
{
    public static class ReportsPathFactory
    {
        private const string ImagesFolderName = @"Images";
        static string _pathSubFolderForReport = string.Empty;

        public static string ReportsFolder => _pathSubFolderForReport;

        public static string CreateTestFolderForReport(string testName, string reportsFolder)
        {
            _pathSubFolderForReport =
                    $@"{reportsFolder}\AutomationReports\{testName}_{DateTime.Now:yyyy.MM.dd.hh.mm}";

            var imagesDirectory = Path.Combine(_pathSubFolderForReport, ImagesFolderName);

            Directory.CreateDirectory(imagesDirectory);
            Console.WriteLine("Report location: " + _pathSubFolderForReport);

            return _pathSubFolderForReport;
        }
    }
}
