using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kursach
{
    public class CPUAnalyser : HardwareInfoAnalyser
    {
        public override void Analyse(HardwareInfo hardwareInfo, List<ClientProblems> problems)
        {
            if (hardwareInfo.averageCPULoad > 70)
                problems.Add(ClientProblems.CPU_PROBLEM);
        }
    }
}
