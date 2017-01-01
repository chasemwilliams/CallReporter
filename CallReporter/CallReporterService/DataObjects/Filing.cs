using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CallReporterService.DataObjects
{
    public class Filing : EntityData
    {
        public int ID_RSSD { get; set; }
        public string ReportingCycleEndDate { get; set; }
    }
}