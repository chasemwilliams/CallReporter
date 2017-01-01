using System;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace CallReporter.Model
{
    public class ReportingFinancialInstitution
    {
        #region Azure Mobile Service Properties
        public string Id { get; set; }

        [Version]
        public string Version { get; set; }

        #endregion

        public int ID_RSSD { get; set; }

        /// <remarks/>
        public int FDICCertNumber { get; set; }

        /// <remarks/>
        public int OCCChartNumber { get; set; }
        /// <remarks/>
        public int OTSDockNumber { get; set; }

        /// <remarks/>
        public int PrimaryABARoutNumber { get; set; }

        /// <remarks/>
        public string Name { get; set; }

        /// <remarks/>
        public string State { get; set; }

        /// <remarks/>
        public string City { get; set; }

        /// <remarks/>
        public string Address { get; set; }

        /// <remarks/>
        public int ZIP { get; set; }

        /// <remarks/>
        public string FilingType { get; set; }

        /// <remarks/>
        public bool HasFiledForReportingPeriod { get; set; }
    }
}
