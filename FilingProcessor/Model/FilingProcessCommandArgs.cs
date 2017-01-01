using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilingProcessor.Model
{
    public class FilingProcessCommandArgs
    {
        /// <summary>
        /// Corresponds to the /FA command line argument which specifies that all filings 
        /// should be fetched and processed rather than just the new filings since the
        /// filedSinceDate
        /// </summary>
        public bool LoadReportingInstitutions { get; set; }
        public Credentials Credentials { get; set; }
        public string ReportingCycleEndDate { get; set; }
    }
}
