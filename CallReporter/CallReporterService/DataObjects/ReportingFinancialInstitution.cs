using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CallReporterService.DataObjects
{
    public class ReportingFinancialInstitution : EntityData
    {
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