
using System.Web.Services.Protocols;
using Microsoft.Web.Services2.Security.Tokens;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using FilingProcessor.Model;
using System;

namespace FilingProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            FilingProcessCommandArgs commandLineArgs = Program.ProcessCommandLineArgs(args);

            FilingProcessor.Core.FilingProcessor filingProcessor = new FilingProcessor.Core.FilingProcessor();

            // If LoadReportingInstitutions command line arg was specified then load/update
            if (commandLineArgs.LoadReportingInstitutions)
                filingProcessor.LoadReportingInstitutions().Wait();

            //I commented out the line below and wrote the line after that to test
            //filingProcessor.ProcessFilings(commandLineArgs).Wait();
            filingProcessor.RetrievePanelOfReporters(commandLineArgs);

        }

        static FilingProcessCommandArgs ProcessCommandLineArgs(string[] args)
        {
            FilingProcessCommandArgs result = new FilingProcessCommandArgs();

            // ToDo: This is just temporary command line arg processing.  Need to implement 
            // proper processing later that allows for optional and named command line arguments

            result.Credentials = new Credentials(args[0], args[1]);

            result.ReportingCycleEndDate = (args.Length >= 3) ? args[2] : null;

            result.LoadReportingInstitutions = (args.Length >= 4 && args[3].ToLower() == "/l") ? true : false;

            return result;
        }
    }
}
