using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CallReporterService.DataObjects
{
    public class FilingProcessorProfile : EntityData
    {
        public string FiledSinceDate { get; set; }
    }
}