using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kursach
{
    public class RAMAnalyser : HardwareInfoAnalyser
    {
        public override void Analyse(HardwareInfo hardwareInfo, List<ClientProblems> problems)
        {
            if (hardwareInfo.memoryLoad > 90)
                problems.Add(ClientProblems.RAM_PROBLEM);
        }
    }
}
