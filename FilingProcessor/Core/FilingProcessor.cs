using FilingProcessor.Model;
using Microsoft.Web.Services2.Security.Tokens;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Protocols;

namespace FilingProcessor.Core
{
    public class FilingProcessor
    {
        public async Task ProcessFilings(FilingProcessCommandArgs commandLineArgs)
        {
            Console.WriteLine("Retrieving panel of reporters");

            FFIECPublicWebService.RetrievalService proxy = GetRetrievalServiceProxy(commandLineArgs);

            int[] rssds = proxy.RetrieveFilersSinceDate(FFIECPublicWebService.ReportingDataSeriesName.Call,
                                                        commandLineArgs.ReportingCycleEndDate,
                                                        FilingProcessorProfile.FiledSinceDate);

            Console.WriteLine("Retrieved filers for reporting cycle {0} who filed since {1}.",
                               commandLineArgs.ReportingCycleEndDate,
                               FilingProcessorProfile.FiledSinceDate);

            foreach (int rssd in rssds)
            {
                Console.WriteLine("Processing ID_RSSD: " + rssd);

                var reportingInstitution = await ReportingInstitutionTable.Where(riItem => riItem.ID_RSSD == rssd).ToListAsync();

                // Should be rare, but if this is a new reporting institution then add it
                if (reportingInstitution.Count == 0)
                {
                    // ToDo: Because we only get back rssds (not full ReportingFinancialInstitution
                    // record) you will need to find out how to fetch a single 
                    // ReportingFinancialInstitution record that corresponds to rssd so we can add
                    // it to our cached table
                }

                var filings = await FilingTable.Where(f => f.ID_RSSD == rssd &&
                                                          f.ReportingCycleEndDate == commandLineArgs.ReportingCycleEndDate).ToListAsync();

                // If this is a new filing record then add it
                if (filings.Count == 0)
                {
                    CallReporter.Model.Filing filing = new CallReporter.Model.Filing() { ID_RSSD = rssd, ReportingCycleEndDate = commandLineArgs.ReportingCycleEndDate };

                    await FilingTable.InsertAsync(filing);

                    await AlertInterestedParties(filing);
                }
            }

            // Update the FiledSinceDate now that we have successfully processed the filings
            // ToDo: Uncomment this line when you are done finished testing 
            //FilingProcessorProfile.FiledSinceDate = DateTime.Now.ToString("MM/dd/yyyy");

            await FilingProcessorProfileTable.UpdateAsync(FilingProcessorProfile);

            Console.WriteLine("Panel of reporters retrieved, press any key to finish");

            Console.ReadLine();
        }

        public async Task LoadReportingInstitutions()
        {
            // ToDo: Find out how to get all 8,000 reporting institutions

            CallReporter.Model.ReportingFinancialInstitution[] fetchedReportingItems = null;

            foreach (CallReporter.Model.ReportingFinancialInstitution fetchedReportingItem in fetchedReportingItems)
            {
                // Get matching reporting institution from the records we have cached (i.e. "saved") in  our CallReporter service
                var cachedReportingItems = ReportingInstitutionTable.Where(rptInstitution => rptInstitution.ID_RSSD == fetchedReportingItem.ID_RSSD).ToListAsync().GetAwaiter().GetResult();

                // If there wasn't a matching cached reporting institution record
                if (cachedReportingItems.Count == 0)
                    // Use mobile service table to add new reporting institution record to our cache (i.e. database)
                    ReportingInstitutionTable.InsertAsync(fetchedReportingItem).Wait();
                else
                {
                    await UpdateAsync(ReportingInstitutionTable, cachedReportingItems[0], fetchedReportingItem);
                }
            }
        }

        /// <summary>
        /// Private backing member for singleton
        /// </summary>
        MobileServiceClient _MobileService;

        /// <summary>
        /// The CallReporter Azure Mobile Service
        /// </summary>
        /// <remarks>
        /// This mobile service supports all the persistance capabilities for the Call Reporter
        /// service.
        /// 
        /// The property implements the Singleton pattern which provides on-demand creation 
        /// at the point the instance is needed and ensures only one instance is ever created.
        /// </remarks>
        public MobileServiceClient MobileService
        {
            get
            {
                if (_MobileService == null)
                    _MobileService = new MobileServiceClient("https://CallReporter.azurewebsites.net");

                return _MobileService;
            }
        }

        /// <summary>
        /// Private backing member for singleton
        /// </summary>
        IMobileServiceTable<CallReporter.Model.FilingProcessorProfile> _FilingProcessorProfileTable;

        /// <summary>
        /// The Azure Mobile Service table for the FilingProcessor profile
        /// </summary>
        /// <remarks>
        /// The property implements the Singleton pattern which provides on-demand creation 
        /// at the point the instance is needed and ensures only one instance is ever created.
        /// </remarks>
        public IMobileServiceTable<CallReporter.Model.FilingProcessorProfile> FilingProcessorProfileTable
        {
            get
            {
                if (_FilingProcessorProfileTable == null)
                    _FilingProcessorProfileTable = MobileService.GetTable<CallReporter.Model.FilingProcessorProfile>();

                return _FilingProcessorProfileTable;
            }
        }

        /// <summary>
        /// Private backing member for singleton
        /// </summary>
        CallReporter.Model.FilingProcessorProfile _FilingProcessorProfile;

        /// <summary>
        /// The profile for the FilingProcessor
        /// </summary>
        /// <remarks>
        /// This profile will hold all the operational data for the filing processor
        /// 
        /// The property implements the Singleton pattern which provides on-demand creation 
        /// at the point the instance is needed and ensures only one instance is ever created.
        /// </remarks>
        public CallReporter.Model.FilingProcessorProfile FilingProcessorProfile
        {
            get
            {
                // Get filing profiles but there will only every be one
                var filingProcessorProfileList = FilingProcessorProfileTable.ToListAsync().GetAwaiter().GetResult();

                // If a profile does not exist yet, create one
                if (filingProcessorProfileList.Count == 0)
                {
                    _FilingProcessorProfile = new CallReporter.Model.FilingProcessorProfile() { FiledSinceDate = DateTime.Now.ToString("MM/dd/yyyy") };

                    // Use mobile service table to add new profile to the database
                    FilingProcessorProfileTable.InsertAsync(_FilingProcessorProfile).Wait();
                }
                else
                    // Grab the first profile you find since there will only be one
                    _FilingProcessorProfile = FilingProcessorProfileTable.ToListAsync().GetAwaiter().GetResult()[0];

                return _FilingProcessorProfile;
            }
        }

        IMobileServiceTable<CallReporter.Model.Filing> _FilingTable;

        public IMobileServiceTable<CallReporter.Model.Filing> FilingTable
        {
            get
            {
                if (_FilingTable == null)
                    _FilingTable = MobileService.GetTable<CallReporter.Model.Filing>();

                return _FilingTable;
            }
        }

        IMobileServiceTable<CallReporter.Model.ReportingFinancialInstitution> _ReportingInstitutionTable;

        public IMobileServiceTable<CallReporter.Model.ReportingFinancialInstitution> ReportingInstitutionTable
        {
            get
            {
                if (_ReportingInstitutionTable == null)
                    _ReportingInstitutionTable = MobileService.GetTable<CallReporter.Model.ReportingFinancialInstitution>();

                return _ReportingInstitutionTable;
            }
        }

        async Task AlertInterestedParties(CallReporter.Model.Filing filing)
        {
            // Get reporting institution that filed
            var reportingInstitution = await ReportingInstitutionTable.Where(rptInstitution => rptInstitution.ID_RSSD == filing.ID_RSSD).ToListAsync();

            if (reportingInstitution.Count > 0)
            {
                // ToDo: Alert all parties that expressed an interest in this particular filing and
                // use reportingInstitution to get the bank name and any other info that makes sense
                // to include in the alert
            }
            else
            {
                // ToDo: Log the fact that a filing was received for an institution that is
                // not currently in our cached reporting institution table.
                // This could happen if our cached reporting institution table is not kept
                // to to date
            }
        }

        public async Task UpdateAsync(IMobileServiceTable<CallReporter.Model.ReportingFinancialInstitution> reportingInstitutionTable,
                                      CallReporter.Model.ReportingFinancialInstitution cachedReportingItem,
                                      CallReporter.Model.ReportingFinancialInstitution fetchedReportingItem)
        {
            cachedReportingItem.Address = fetchedReportingItem.Address;
            cachedReportingItem.City = fetchedReportingItem.City;
            cachedReportingItem.FDICCertNumber = fetchedReportingItem.FDICCertNumber;
            cachedReportingItem.FilingType = fetchedReportingItem.FilingType;
            cachedReportingItem.HasFiledForReportingPeriod = fetchedReportingItem.HasFiledForReportingPeriod;
            cachedReportingItem.Name = fetchedReportingItem.Name;
            cachedReportingItem.OCCChartNumber = fetchedReportingItem.OCCChartNumber;
            cachedReportingItem.OTSDockNumber = fetchedReportingItem.OTSDockNumber;
            cachedReportingItem.PrimaryABARoutNumber = fetchedReportingItem.PrimaryABARoutNumber;
            cachedReportingItem.State = fetchedReportingItem.State;
            cachedReportingItem.ZIP = fetchedReportingItem.ZIP;

            // Update cached record just in case something changed so our cache will be up to date
            await reportingInstitutionTable.UpdateAsync(cachedReportingItem);
        }

        /// <summary>
        /// This method demonstrates the usage of the web service method RetrieveFilersSinceDate
        /// Clients should call this method to keep up to date with the filings/ammendments filed by financial institutions
        /// after a given date/time until now.
        /// </summary>
        public void GetFilers(FilingProcessCommandArgs commandLineArgs)
        {
            FFIECPublicWebService.RetrievalService proxy = GetRetrievalServiceProxy(commandLineArgs);

            int[] rssds = proxy.RetrieveFilersSinceDate(FFIECPublicWebService.ReportingDataSeriesName.Call,
                                                        commandLineArgs.ReportingCycleEndDate,
                                                        FilingProcessorProfile.FiledSinceDate);

            Console.WriteLine("Retrieved filers for reporting cycle {0} who filed since {1}.",
                               commandLineArgs.ReportingCycleEndDate, 
                               FilingProcessorProfile.FiledSinceDate);

            foreach (int rssd in rssds)
            {
                Console.WriteLine("OK" + "ID_RSSD: " + rssd);
            }
        }

        FFIECPublicWebService.RetrievalService GetRetrievalServiceProxy(FilingProcessCommandArgs commandLineArgs)
        {
            FFIECPublicWebService.RetrievalService proxy = new FFIECPublicWebService.RetrievalService();
            UsernameToken userToken = new UsernameToken(commandLineArgs.Credentials.UserName,
                                                        commandLineArgs.Credentials.Password,
                                                        PasswordOption.SendHashed);

            proxy.RequestSoapContext.Security.Tokens.Add(userToken);

            return proxy;
        }

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
        public static void RetrievePanelOfReporters(FilingProcessCommandArgs commandLineArgs)
        {

            FFIECPublicWebService.ReportingDataSeriesName dsName = FFIECPublicWebService.ReportingDataSeriesName.Call;
            FFIECPublicWebService.RetrievalService proxy = new FFIECPublicWebService.RetrievalService();
            UsernameToken userToken = new UsernameToken(commandLineArgs.Credentials.UserName, commandLineArgs.Credentials.Password, PasswordOption.SendHashed);
            proxy.RequestSoapContext.Security.Tokens.Add(userToken);
            proxy.Timeout = 400000;

            FFIECPublicWebService.ReportingFinancialInstitution[] reporters =
                proxy.RetrievePanelOfReporters(dsName, commandLineArgs.ReportingCycleEndDate);

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
    }
}
