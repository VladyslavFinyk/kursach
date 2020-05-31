using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Text.RegularExpressions;
using OpenHardwareMonitor.Hardware;

namespace Client
{
    public class HardwareInfo : IVisitor
    {
        public Dictionary<int, double> CPULoad { get; set; }
        public double AverafeCPULoad { get; set; }
        public double MemoryLoad { get; set; }
        // double GPULoad = 0;
        /*public HardwareInfo()
        {
            InitialiseAll();
        }*/
        public override string ToString()
        {
            string result = "";
            foreach(var core in CPULoad)
            {
                result += "Core #" + core.Key.ToString() + ":\t" + core.Value.ToString() + '\n';
            }
            result += "Average CPU Load:\t" + AverafeCPULoad.ToString() + '\n';
            result += "Memory Load:\t" + MemoryLoad.ToString() + '\n';
            return result;
        }
        public void InitialiseAll()
        {
            CPULoad = InitialiseCPULoad();
            AverafeCPULoad = InitialiseAverageCPULoad();
            MemoryLoad = InitialiseMemoryLoad();
        }
        Dictionary<int, double> InitialiseCPULoad()
        {
            Computer computer = new Computer()
            {
                CPUEnabled = true
            };

            computer.Open();
            //computer.Accept(new HardwareInfo());
            string cpuCoreName = @"CPU Core #(\d)";
            string cpuNum = @"\d";


            // TODO delete foreach
            Dictionary<int, double> keyValuePairs = new Dictionary<int, double>();
            foreach (var hardware in computer.Hardware)
            {
                if (hardware.HardwareType == HardwareType.CPU)
                {
                    foreach (var sensor in hardware.Sensors)
                    {
                        if (Regex.IsMatch(sensor.Name, cpuCoreName, RegexOptions.IgnoreCase) && sensor.SensorType == SensorType.Load)
                        {
                            Match match = Regex.Match(sensor.Name, cpuNum);
                            if (match.Success)
                            {
                                keyValuePairs.Add(Convert.ToInt32(Char.GetNumericValue(sensor.Name[match.Index])), Convert.ToDouble(sensor.Value));
                            }
                        }
                    }
                    break;
                }
            }
            computer.Close();
            return keyValuePairs;
        }
        public double InitialiseAverageCPULoad()
        {
            if(CPULoad.Count != 0)
            {
                double average = 0;
                foreach (double load in CPULoad.Values)
                {
                    average += load;
                }
                average /= (CPULoad.Values.Count);
                return average;
            }
            return 0;
        }
        double InitialiseMemoryLoad()
        {
            Computer computer = new Computer()
            {
                RAMEnabled = true
            };
            computer.Open();
            //computer.Accept(new HardwareInfo());
            foreach (var memory in computer.Hardware[0].Sensors)
            {
                if (memory.Name == "Memory")
                {
                    computer.Close();
                    return Convert.ToDouble(memory.Value);
                }
            }
            return 0;
            
        }
        /*void InitialiseCPULoad()
        {
            Computer computer = new Computer()
            {
                CPUEnabled = true
            };

            computer.Open();
            //computer.Accept(new HardwareInfo());
            string cpuCoreName = @"CPU Core #(\d)";
            string cpuNum = @"\d";
            

            // TODO delete foreach

            foreach(var hardware in computer.Hardware)
            {
                if(hardware.HardwareType == HardwareType.CPU)
                {
                    foreach(var sensor in hardware.Sensors)
                    {
                        if(Regex.IsMatch(sensor.Name, cpuCoreName, RegexOptions.IgnoreCase) && sensor.SensorType == SensorType.Load)
                        {
                            Match match = Regex.Match(sensor.Name, cpuNum);
                            if (match.Success)
                            {
                                this.cpuLoad.Add(Convert.ToInt32(Char.GetNumericValue(sensor.Name[match.Index])), Convert.ToDouble(sensor.Value));
                            }
                        }
                    }
                    break;
                }
            }
            computer.Close();
        }
        public void InitialiseAverageCPULoad()
        {
            if(cpuLoad.Count != 0)
            {
                foreach (double load in cpuLoad.Values)
                {
                    averageCPULoad += load;
                }
                averageCPULoad = averageCPULoad / (cpuLoad.Values.Count);
            }
        }
        void InitialiseMemoryLoad()
        {
            Computer computer = new Computer()
            {
                RAMEnabled = true
            };
            computer.Open();
            //computer.Accept(new HardwareInfo());
            foreach (var memory in computer.Hardware[0].Sensors)
            {
                if (memory.Name == "Memory")
                {
                    memoryLoad = Convert.ToDouble(memory.Value);
                }
            }
            computer.Close();
        }*/
        public void VisitComputer(IComputer computer)
        {
            computer.Traverse(this);
        }
        public void VisitHardware(IHardware hardware)
        {
            hardware.Update();
            foreach (IHardware subHardware in hardware.SubHardware) subHardware.Accept(this);
        }
        public void VisitSensor(ISensor sensor) { }
        public void VisitParameter(IParameter parameter) { }
    }
}