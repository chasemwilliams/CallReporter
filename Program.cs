using System;
using System.Drawing;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml;
using System.Timers;

using Microsoft.Web.Services2;
using Microsoft.Web.Services2.Security;
using Microsoft.Web.Services2.Security.Tokens;

namespace CallReporter
{
    class Program
    {
        /// <summary>
        /// method usage of the web service helper method TestUserAccess
        /// Clients should call this method to check if a user has access to FFIEC public web services
        /// </summary>
        public static void TestUserAccess(Credentials creds)
        {
            string UserID = creds.UserName;
            string UserSecurityToken = creds.Password;

            bool userHasAccess = false;
            try
            {
                FFIECPublicWebService.RetrievalService proxy = new FFIECPublicWebService.RetrievalService();
                UsernameToken userToken = new UsernameToken(UserID, UserSecurityToken, PasswordOption.SendHashed);
                proxy.RequestSoapContext.Security.Tokens.Add(userToken);
                userHasAccess = proxy.TestUserAccess();
            }
            catch (SoapException ex)
            {
                if (ex.Code.Name.Equals("FailedAuthentication"))
                {
                    userHasAccess = false;
                }
                else
                {
                    Console.WriteLine("ERROR", "The Web Service returned an error: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                FFIECPublicWebService.RetrievalService proxy = new FFIECPublicWebService.RetrievalService();
                Console.WriteLine("ERROR accesssing URL - ", proxy.Url);
            }
            finally
            {
                string message;
                if (userHasAccess)
                {
                    message = "User '" + UserID + "' is authorized to access the FFIEC CDR Public Web Service.";
                    Console.WriteLine("OK, " + message);
                }
                else
                {
                    message = "User '" + UserID + "' is NOT authorized to access the FFIEC CDR Public Web Service. Please create a user account using the PDD website.";
                    Console.WriteLine("ERROR, " + message);
                }
            }
        }

        /// <summary>
        /// method usage of the web service helper method RetrieveReportingPeriods
        /// Clients should call this method to obtain a list of available reporting periods in the correct format
        /// to call the other retrieval methods
        /// </summary>
        public static void RetrieveReportingPeriods(Credentials creds)
        {
            string UserID = creds.UserName;
            string UserSecurityToken = creds.Password;

            FFIECPublicWebService.ReportingDataSeriesName dsName = FFIECPublicWebService.ReportingDataSeriesName.Call;

            FFIECPublicWebService.RetrievalService proxy = new FFIECPublicWebService.RetrievalService();
            UsernameToken userToken = new UsernameToken(UserID, UserSecurityToken, PasswordOption.SendHashed);
            proxy.RequestSoapContext.Security.Tokens.Add(userToken);

            string[] reportingPeriodEndList = proxy.RetrieveReportingPeriods(dsName);
            foreach (var item in reportingPeriodEndList)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("OK, " + String.Format("Retrieved available reporting periods for {0}.", dsName));
        }

        /// <summary>
        /// method usage of the web service method RetrievePanelOfReporters
        /// Clients should call this method to obtain a list of all financial institutions who filed Call Report
        /// for a particular reporting period. This method should typically be called once or infrequently to obtain
        /// the complete list of banks in the PoR. Subsequently, the web clients should call RetrieveFilersSinceDate
        /// to find out the list of banks that have filed their original or amended Call Reports.
        public static void RetrievePanelOfReporters(Credentials creds)
        {

            FFIECPublicWebService.ReportingDataSeriesName dsName = FFIECPublicWebService.ReportingDataSeriesName.Call;
            FFIECPublicWebService.RetrievalService proxy = new FFIECPublicWebService.RetrievalService();
            UsernameToken userToken = new UsernameToken(creds.UserName, creds.Password, PasswordOption.SendHashed);
            proxy.RequestSoapContext.Security.Tokens.Add(userToken);
            proxy.Timeout = 400000;

            FFIECPublicWebService.ReportingFinancialInstitution[] reporters =
                proxy.RetrievePanelOfReporters(dsName, creds.Date);

            Console.WriteLine("OK" + "Retrieved panel of reporters. ");
            foreach (FFIECPublicWebService.ReportingFinancialInstitution reporter in reporters)
            {
                Console.WriteLine(reporter.Name.Trim() + "|" + reporter.ID_RSSD + "|" + reporter.State + "|" + reporter.HasFiledForReportingPeriod);
            }

            Console.WriteLine("OK" + "Total members of POR = " + reporters.Length.ToString());
        }

        /// <summary>
        /// method to call webservice that checks the date/time of latest filing
        /// returns DD//MM/YYYY HH:MM
        public static void CheckLatestRunTime()
        {
            /// 
        }

        /// <summary>
        /// This method demonstrates the usage of the web service method RetrieveFilersSinceDate
        /// Clients should call this method to keep up to date with the filings/ammendments filed by financial institutions
        /// after a given date/time until now.
        /// </summary>
        public static void GetFilers(Credentials creds)
        {
            FFIECPublicWebService.ReportingDataSeriesName dsName = FFIECPublicWebService.ReportingDataSeriesName.Call;
            string reportingCycleEndDate = creds.Date;
            // TODO: replace with web service call
            //string filedSinceDate = this.FiledSinceDate.Text;
            //TODO: delete this line and uncomment the line above
            string filedSinceDate = "9/30/2016";
            string user = creds.UserName;
            string password = creds.Password;

            FFIECPublicWebService.RetrievalService proxy = new FFIECPublicWebService.RetrievalService();
            UsernameToken userToken = new UsernameToken(user, password, PasswordOption.SendHashed);
            proxy.RequestSoapContext.Security.Tokens.Add(userToken);

            int[] rssds = proxy.RetrieveFilersSinceDate(dsName, reportingCycleEndDate, filedSinceDate);

            Console.WriteLine("Retrieved filers for reporting cycle {0} who filed since {1}.",
                reportingCycleEndDate, filedSinceDate);
            foreach (int rssd in rssds)
            {
                Console.WriteLine("OK" + "ID_RSSD: " + rssd);
            }
                    
        }

        static void Main(string[] args)
        {
            Credentials creds = new Credentials(args[0], args[1], args[2]);

            Console.WriteLine("Retrieving panel of reporters");

            //RetrievePanelOfReporters(creds);
            //RetrieveReportingPeriods(creds);
            GetFilers(creds);


            Console.WriteLine("Panel of reporters retrieved, press any key to finish");

            Console.ReadLine();
        }
    }
}
