using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallReporter.Model
{
    public class FilingProcessorProfile
    {
        #region Azure Mobile Service Properties
        public string Id { get; set; }

        [Version]
        public string Version { get; set; }

        #endregion

        public string FiledSinceDate { get; set; }
    }
}
