using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Text.RegularExpressions;
using OpenHardwareMonitor.Hardware;

namespace Kursach
{


    public class HardwareInfo
    {
        public Dictionary<int, double> cpuLoad { get; set; }
        public double averageCPULoad { get; set; }
        public double memoryLoad { get; set; }
        // double GPULoad = 0;
    }
}